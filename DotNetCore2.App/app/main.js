import Vue from 'vue'
import { sync } from 'vuex-router-sync'
import app from './app.vue'
import router from './router/router'
import store from './store/store'
import Toasted from 'vue-toasted';


Vue.config.productionTip = false //removes console output
Vue.config.devtools = false //Might cause problems?? hopefully just removes console output

/**
* vue-toasted plugin + options
*/

Vue.use(Toasted, {
    duration: 2500,
    position: 'bottom-right',
    iconPack: 'fontawesome'
})

/**
* Effortlessly keep vue- router and vuex store in sync.
*/ 
sync(store, router) 


const appVue = new Vue({
    el: '#app',
    router: router, 
    store: store,
    render: r => r(app)
})


export { appVue }