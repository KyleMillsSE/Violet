<template>
    <div class="core-login">
        <div class="off-centered">
            <div class="row">
                <div class="col-md-6">
                    <img style="padding-top: 30px;" src="/assets/lars-logo.png" alt="Lars logo">
                </div>
                <div class="col-md-6">
                    <div class="input-group pd-sm">
                        <label>
                            Username
                        </label>
                        <input v-model="username" type="text" class="form-control" />
                    </div>
                    <div class="input-group pd-sm">
                        <label>
                            Password
                        </label>
                        <input v-model="password" type="password" class="form-control" />
                    </div>
                    <button v-on:click="submit()" class="btn btn-core pull-right mr-sm">Sign in</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import http from '../../core/restClient/httpWrapper'
    import notification from '../../core/notification/notification'

    export default {

        name: 'login',
        data() {
            return {
                username: 'KyleMills',
                password: 'Voiteqadmin1'
            }
        },
        methods: {
            submit() {
                http.get('token?username=' + this.username + '&password=' + this.password + '&grantType=password', null).then(result => {
                    console.log(result);
                    this.$store.dispatch('setAuth', { username: result.username, token: result.token });

                    http.get('test', null).then(result => { }).catch(err => { });
                }).catch(err => {
                    console.log(err);
                });
                //restClient.get('token?username=' + this.username + '&password=' + this.password + '&grantType=password')
                //    .then(response => {
                //        console.log(response);
                //       
                //    })
                //    .catch(e => {
                //        notification.error(this, "Invalid username or password")
                //    })
            }
        }
    }

</script>

<style scoped>
    .off-centered {
        position: fixed; /* or absolute */
        top: 35%;
        left: 35%;
    }

    label {
        font-weight: 100;
        font-size: 16px;
        color: #ffffff;
    }

    .input-group > .form-control:last-child {
        -webkit-border-radius: 3px !important;
        -moz-border-radius: 3px !important;
        border-radius: 3px !important;
    }

    input:focus {
        border-color: #e7ae64;
    }
</style>