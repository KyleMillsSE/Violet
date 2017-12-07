import Vue from 'vue'
import App from './app.vue'
import router from './router/router'

Vue.config.productionTip = false //removes console output
//Vue.config.devtools = false //Might cause problems?? hopefully just removes console output

const vue = new Vue({
    el: '#app',
    router,
    render: r => r(App)
})


export { vue }