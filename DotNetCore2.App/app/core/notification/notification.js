export default {

    error(vm, msg) {
        vm.$toasted.error(msg, { icon: 'exclamation-circle' })
    },

    info(vm, msg) {
        vm.$toasted.info(msg, { icon: 'info' })
    },

    success(vm, msg) {
        vm.$toasted.success(msg, { icon: 'check' })
    },

    warning(vm, msg) {
        vm.$toasted.show(msg, { icon: 'exclamation', className: 'warning-toast' })
    }

};