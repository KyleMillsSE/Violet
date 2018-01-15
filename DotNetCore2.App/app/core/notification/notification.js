import Vue from 'vue'

export default {

    error(msg) {
        Vue.prototype.$toasted.error(msg, { icon: 'exclamation-circle' })
    },

    info(msg) {
        Vue.prototype.$toasted.info(msg, { icon: 'info' })
    },

    success(msg) {
        Vue.prototype.$toasted.success(msg, { icon: 'check' })
    },

    warning(msg) {
        Vue.prototype.$toasted.show(msg, { icon: 'exclamation', className: 'warning-toast' })
    }

};