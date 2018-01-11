import axios from 'axios'
import store from '../../store/store'

const restClient = new axios.create({
    baseURL: 'http://localhost:55799/api/',
   // timeout: 5000,
    headers: {
        'Content-Type': 'application/json'
    }
})

restClient.interceptors.request.use(function (config) {
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
restClient.interceptors.response.use(undefined, function (err) {
    if (err.response.status === 401) {
        
        //return getRefreshToken()
        //    .then(function (success) {
        //        setTokens(success.access_token, success.refresh_token);
        //        err.config.__isRetryRequest = true;
        //        err.config.headers.Authorization = 'Bearer ' + getAccessToken();
        //        return axios(err.config);
        //    })
        //    .catch(function (error) {
        //        console.log('Refresh login error: ', error);
        //        throw error;
        //    });
    }

    throw err;
});

export default restClient 
