import axios from 'axios'
import store from '../../store/store'
import router from '../../router/router'

const axiosWrapper = new axios.create({
    baseURL: localStorage.getItem("webHost") + '/api/',
    headers: {
        'Content-Type': 'application/json'
    }
})

axiosWrapper.interceptors.request.use(function (config) {
    // append auth token to header if exists
    if (!config.headers.Authorization) {
        config.headers.Authorization = 'Bearer ' + store.getters.getToken;
    }
    return config;
}, function (error) {
    // Do something with request error
    return Promise.reject(error);
});

// Add a response interceptor
axiosWrapper.interceptors.response.use(undefined, function (err) {
    if (err.response.status === 401) { //handle refresh of token if it expires err.config && err.response && 
        return axiosWrapper.post("/token?expiredToken=" + store.getters.getToken).then(
            success => {
                store.dispatch('refreshToken', { token: success.data.token });

                err.config.headers.Authorization = 'Bearer ' + store.getters.getToken;

                return axios.request(err.config);
            },
            err => {
                store.dispatch('logout');

                router.push({
                    name: 'login'
                });

                return Promise.reject(err);
            });
    }
    else {
        return Promise.reject(err);
    }
});

class RestClient {
    constructor() { }

    submit(requestType, url, data) {
        return new Promise((resolve, reject) => {
            axiosWrapper[requestType](url, data)
                .then((response) => {
                    //hacky way to handle async and sync returns
                    if (response.data.value !== undefined) {
                        resolve(response.data.value.result);
                    } else {
                        resolve(response.data);
                    }
                })
                .catch(({ response }) => {
                    if (response) {
                        reject(response.data);
                    } else {
                        reject();
                    }
                });
        });
    }
}

const restClient = new RestClient()
    
export default {

    get(endpoint, data = null) {
        return restClient.submit('get', endpoint, data);
    }
}