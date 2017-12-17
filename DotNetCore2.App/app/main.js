import Vue from 'vue'
import { sync } from 'vuex-router-sync'
import app from './app.vue'
import router from './router/router'
import store from './store/store'

Vue.config.productionTip = false //removes console output
//Vue.config.devtools = false //Might cause problems?? hopefully just removes console output

// Effortlessly keep vue- router and vuex store in sync.
sync(store, router) 



/**
* $http plugin based on axios
*/
//import httpPlugin from './plugins/http'
/**
* Make $http avaible to all components
* Send store and router to httpPlugin (injection)
*/

//Vue.use(httpPlugin, { Store, Router })

const appVue = new Vue({
    el: '#app',
    router: router, // make Router work with the application
    store: store, // injects the Store into all components
    render: r => r(app)
})


export { appVue }