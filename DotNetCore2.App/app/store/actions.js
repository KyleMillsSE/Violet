/* actions can be async */
import * as types from './mutator-types'

export default {

    setAuth({ commit }, obj) {
        commit(types.AUTH.SET, obj)
    }
}