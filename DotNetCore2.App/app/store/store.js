import Vue from 'vue'
import Vuex from 'vuex'
import State from './state'
import * as Accessors from './accessors'
import Mutators from './mutators'
import Actions from './actions'
import Plugins from './plugins'

Vue.use(Vuex)

const store = new Vuex.Store({
    state:State,
    getters: Accessors,
    actions: Actions,
    mutations: Mutators,
    plugins: [Plugins]
});

export default store 
