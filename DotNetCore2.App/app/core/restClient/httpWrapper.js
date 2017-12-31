import restClient from './restClient'

class httpWrapper {
    constructor() { }

    submit(requestType, url, data) {
        return new Promise((resolve, reject) => {
            restClient[requestType](url, data)
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

const http = new httpWrapper()
    

export default {

    get(endpoint, data = null) {
        return http.submit('get', endpoint, data);
    }
}