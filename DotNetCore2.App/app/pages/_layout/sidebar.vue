<template>
    <aside class="main-sidebar" style="padding-top: 80px;">
        <!-- sidebar: style can be found in sidebar.less -->
        <section class="sidebar">
            <!-- Sidebar user panel -->
            <!--<div class="user-panel">
                <div class="pull-left image">
                    <img src="dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">
                </div>
                <div class="pull-left info">
                    <p>Alexander Pierce</p>
                    <a href="#"><i class="fa fa-circle text-success"></i> Online</a>
                </div>
            </div>-->
            <!-- sidebar menu: : style can be found in sidebar.less -->
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
                    { icon: 'fa fa-users', name: 'Users', isActive: false },
                    { icon: 'fa fa-question', name: 'Nav Item?', isActive: false },
                    { icon: 'fa fa-question', name: 'Nav Item?', isActive: false },
                    { icon: 'fa fa-question', name: 'Nav Item?', isActive: false },
                    { icon: 'fa fa-question', name: 'Nav Item?', isActive: false },
                    { icon: 'fa fa-question', name: 'Nav Item?', isActive: false },
                    { icon: 'fa fa-question', name: 'Nav Item?', isActive: false }
                ],
                currentSelected: 0
            }
        },
        methods: {
            selectNavItem(index) {
                
                this.navItems[this.currentSelected].isActive = false;
                this.navItems[index].isActive = true;
                this.currentSelected = index;
            }
        },
        created() {
            this.navItems[this.currentSelected].isActive = true;
        }
    }
</script>
