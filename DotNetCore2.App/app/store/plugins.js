import * as types from './mutator-types'

const localStoragePlugin = store => {

    // when the application is refreshed use persistent storage 
    // on reinitialize of application if token is not null
    var token = localStorage.getItem('token');
    var username = localStorage.getItem('username');
    if (token !== null && username !== null) {
        store.dispatch('login', { username: username, token: token });
    }

    // called when the store is initialized
    store.subscribe((mutation, state) => {

        if (mutation.type === types.AUTH.LOGIN) {
            localStorage.setItem('username', state.auth.username)
            localStorage.setItem('token', state.auth.token)
        }

        if (mutation.type === types.AUTH.LOGOUT) {
            localStorage.removeItem('username')
            localStorage.removeItem('token')
        }

        if (mutation.type === types.AUTH.TOKEN) {
            localStorage.setItem('token', state.auth.token)
        }
    })
}

export default localStoragePlugin 