var Vue = require('vue')
var App = require('./app.vue')
//var router = require('./router/router')
import router from './router/router'

const vue = new Vue({
    el: '#app',
    router,
    //render: h => h(App)
    render: function (createElement) {
        return createElement(App)
    }
}).$mount('#app');


export { vue }