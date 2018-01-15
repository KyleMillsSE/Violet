<template>
    <nav class="navbar navbar-light navbar-fixed-top">
        <a class="navbar-brand" href="#/dashboard">
            <img src="/assets/lars-logo.png" style="height: 50px;" alt="Lars logo">
        </a>

        <div class="collapse navbar-collapse">
            <ul class="navbar-nav navbar-items  pull-right">
                <li v-on:click="signOut()">
                    <a><i style="font-size: 26px;" class="fa fa-sign-out" aria-hidden="true"></i><span class="sr-only">(current)</span></a>
                </li>
            </ul>
        </div>
    </nav>

</template>

<script>
    import notification from '../../core/notification/notification'

    export default {
        name: 'nav',
        methods: {
            signOut() {
                this.$store.dispatch('logout');
                this.$router.push({
                    name: 'login'
                });
                notification.success("Successfully logged out");
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    nav {
        height: 80px;
        background-color: #0082c8;
        border-bottom-color: #f0981a;
        border-bottom-width: 3px;
        box-shadow: 0 2px 1px -1px gray;
    }

    .navbar-items {
        padding-top: 27px;
    }
    ul {
        list-style-type: none;
        padding-right: 25px;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

        li > a {
            font-size: 16px;
            color: #ffffff;
        }

    a:active {
        color: #e7ae64
    }

    a:hover {
        cursor: pointer;
        color: #e7ae64;
        text-decoration: none;
    }   
         
    a > i {
        padding-right:2px;
    }

</style> 