<template>
    <div class="core-page">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3>Users</h3>
            </div>

            <div class="panel-body">
                <ul>
                    <li v-for="user in users">{{user.email}}</li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
    import http from '../../core/restClient/httpWrapper'
    import notification from '../../core/notification/notification'

    export default {
        name: 'users',
        data() {
            return {
                users: [],
            }
        },
        methods: {
            loadData() {
                http.get('users').then(result => {
                    this.users = result;
                }).catch(err => {
                    notification.error(this, "Error occurred retreiving users");
                });
            }
        },
        created() {
            this.loadData();
        }
    }
</script>

<style scoped>
    .core-page {
        padding-top: 90px;
        padding-left: 210px;
        padding-right: 10px;
    }
</style>