import Vue from 'vue'
import { sync } from 'vuex-router-sync'
import app from './app.vue'
import router from './router/router'
import store from './store/store'
import vueToasted from 'vue-toasted';

var signalR = require('./scripts/signalr-client-1.0.0-alpha2-final.min.js');

/**
* expose signalR
*/
Vue.prototype.$signalR = signalR;

Vue.config.productionTip = false //removes console output
Vue.config.devtools = false //Might cause problems??

/**
* vue-toasted plugin + options
*/
Vue.use(vueToasted, {
    duration: 2500,
    position: 'bottom-right',
    iconPack: 'fontawesome'
})

/**
* effortlessly keep vue- router and vuex store in sync.
*/ 
sync(store, router) 

const appVue = new Vue({
    el: '#app',
    store: store,
    router: router, 
    render: r => r(app)
})


export { appVue }


/** Tasks todo:
* Materialize instead of bootstrap
*/