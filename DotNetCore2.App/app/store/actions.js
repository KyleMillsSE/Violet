/* actions can be async */
import * as types from './mutator-types'

export default {

    login({ commit }, obj) {
        commit(types.AUTH.LOGIN, obj)
    },

    logout({ commit }, obj) {
        commit(types.AUTH.LOGOUT, { username: null, token: null })
    },

    refreshToken({ commit }, obj) {
        commit(types.AUTH.TOKEN, obj)
    },

    updateNav({ commit }, obj) {

    },
}