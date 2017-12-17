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
                console.log(this.$store.getters.shouldDisplayNav)
                return this.$store.getters.shouldDisplayNav;
            }
        },
    }
</script>