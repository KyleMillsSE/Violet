<style>
    .red {
        color: #f00;
    }
</style>

<template>
    <div>
        <!--<navbar></navbar>
        <sidebar></sidebar>-->

            <router-view></router-view>
    
    </div>
</template>

<script>
    import navbar from './components/_layout/nav.vue'
    import sidebar from './components/_layout/sidebar.vue'

    export default {
        name: 'app',
        components: {
            navbar,
            sidebar
        },
    }
</script>