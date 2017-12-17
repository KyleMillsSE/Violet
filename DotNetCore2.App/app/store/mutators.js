/* mutators have to be sync */

import * as TYPES from './types'


export default {

    [TYPES.AUTH.SET_USER](state, obj) {
        state.user.name = obj.username;
        state.user.token = obj.token;
    },

    [TYPES.AUTH.SET_TOKEN](state, obj) {
        state.user.token = obj.token;
    }

}