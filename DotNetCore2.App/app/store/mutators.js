/* mutators have to be sync */

import * as types from './mutator-types'


export default {

    [types.AUTH.SET](state, obj) {
        state.auth.username = obj.username;
        state.auth.token = obj.token;
    }

}