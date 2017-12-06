var Vue = require('vue')
var App = require('./app.vue')
var router = require('./router/router')

console.log(router)

new Vue({
    el: '#app',
    router,
    render: h => h(App)
})