/* mutators have to be sync */

import * as types from './mutator-types'


export default {

    [types.AUTH.LOGIN](state, obj) {
        state.auth.username = obj.username;
        state.auth.token = obj.token;
    },

    [types.AUTH.LOGOUT](state, obj) {
        state.auth.username = obj.username;
        state.auth.token = obj.token;
    }

}