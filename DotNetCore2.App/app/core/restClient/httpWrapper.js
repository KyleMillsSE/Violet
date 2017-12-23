import restClient from './restClient'

class httpWrapper {
    constructor() { }

    submit(requestType, url, data) {
        return new Promise((resolve, reject) => {
            restClient[requestType](url, data)
                .then((response) => {
                   resolve(response.data.value.result);
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

const http = new httpWrapper()
    

export default {

    get(endpoint, data) {
        return http.submit('get', endpoint, data);
    }
}