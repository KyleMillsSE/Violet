import axios from 'axios'

const restClient = new axios.create({
    baseURL: 'http://localhost:52694/api/',
    timeout: 5000,
    headers: {
        'Content-Type': 'application/json'
    }
})

restClient.interceptors.request.use(function (config) {
    // Do something before request is sent
    console.log(config);
    return config;
}, function (error) {
    console.log(error);
    // Do something with request error
    return Promise.reject(error);
});

// Add a response interceptor
restClient.interceptors.response.use(function (response) {
    // Do something with response data
    console.log(reponse);
    return response;
}, function (error) {
    // Do something with response error
    console.log(error);
    return Promise.reject(error);
});

/**
* Helper method to set the header with the token
*/
restClient.setToken = () => {
    restClient.defaults.headers.common.Authorization = `Bearer ${token}`
}

export default restClient 
