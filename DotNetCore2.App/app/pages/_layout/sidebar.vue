<template>
    <aside class="main-sidebar" style="padding-top: 80px;">
        <section class="sidebar">
            <ul class="sidebar-menu" data-widget="tree">
                <li v-bind:class="{ active: item.isActive }" v-on:click="navSelected(index)" v-for="(item, index) in navItems">
                    <a>
                        <i v-bind:class="item.icon"></i> <span>{{item.name}}</span>
                    </a>
                </li>

            </ul>
        </section>
        <!-- /.sidebar -->
    </aside>
</template>

<script>
    export default {
        name: 'sidebar',
        data() {
            return {
                navItems: [
                    { icon: 'fa fa-home', name: 'Dashboard', state: 'dashboard', isActive: false },
                    { icon: 'fa fa-users', name: 'Users', state: 'users', isActive: false },
                ]
            }
        },
        methods: {
            navSelected(index) {
                //change state
                this.$router.push({
                    name: this.navItems[index].state
                });             
            }
        },
        created() {
            //eval current route and set to active, on create - handles all refreshing of app 
            this.navItems.filter((item) => { return item.state === this.currentRoute; })[0].isActive = true;
        },
        computed: {
            currentRoute() {
                return this.$route.name;
            }
        },
        watch: {
            // watch current route if any changes reflect changes for nav
            currentRoute: function () {
                this.navItems.forEach((item) => { (item.state === this.currentRoute) ? item.isActive = true : item.isActive = false; });
            }
        }
    }
</script>
