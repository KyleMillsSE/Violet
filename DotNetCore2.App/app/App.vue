<template>
    <div>
        <layout-navbar v-show="displayNav"></layout-navbar>
        <layout-sidebar v-show="displayNav"></layout-sidebar>
        <section>
            <router-view></router-view>
        </section>
        <layout-footer v-show="displayNav"></layout-footer>
    </div>
</template>

<script>
    import layoutNavbar from './pages/_layout/nav.vue'
    import layoutFooter from './pages/_layout/footer.vue'
    import layoutSidebar from './pages/_layout/sidebar.vue'
    export default {
        name: 'app',
        components: {
            layoutNavbar,
            layoutFooter,
            layoutSidebar
        },
        computed: {
            displayNav() {
                return this.$store.getters.shouldDisplayNav;
            }
        }
    }
</script>