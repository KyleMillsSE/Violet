/* actions can be async */

import * as TYPES from './types'

export default {

    setUser({ commit }, obj) {
        commit(TYPES.AUTH.SET_USER, obj)
    },

    setToken({ commit }, obj) {
        commit(TYPES.AUTH.SET_TOKEN, obj)
    },

}