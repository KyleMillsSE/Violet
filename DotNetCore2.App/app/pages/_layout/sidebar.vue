<template>
    <aside class="main-sidebar" style="padding-top: 80px;">
        <section class="sidebar">
            <ul class="sidebar-menu" data-widget="tree">
                <li v-bind:class="{ active: item.isActive }" v-on:click="selectNavItem(index)" v-for="(item, index) in navItems">
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
                ],
                currentSelected: 0 //vuex this
            }
        },
        methods: {
            selectNavItem(index) {

                this.navItems[this.currentSelected].isActive = false;
                this.navItems[index].isActive = true;
                

                this.$router.push({
                    name: this.navItems[index].state
                });

                this.currentSelected = index;
                localStorage.setItem("currentSelectedSideNav", this.currentSelected);
            }
        },
        created() {
            this.navItems[this.currentSelected].isActive = true;
        }
    }
</script>
