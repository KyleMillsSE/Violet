<style>
    .red {
        color: #f00;
    }
</style>

<template>
    <div>
        <navbar v-show="displayNav"></navbar>

        
            <router-view></router-view>
     
    </div>
</template>

<script>
    import navbar from './pages/_layout/nav.vue'


    export default {
        name: 'app',
        components: {
            navbar
        },
        computed: {
            displayNav() {
                return this.$store.getters.shouldDisplayNav;
            }
        },
    }
</script>