var Vue = require('vue')
var App = require('./app.vue')
//var router = require('./router/router')
import router from './router/router'

const vue = new Vue({
    el: '#app',
    router,
    render: h => h(App)
}).$mount('#app');


export { vue }