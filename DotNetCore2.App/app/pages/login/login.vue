<template>
    <div class="core-login">
        <div class="off-centered">
            <div class="row">
                <div class="col-md-6">
                    <img style="padding-top: 35px;" src="/assets/lars-logo.png" alt="Lars logo">
                </div>
                <div class="col-md-6">
                    <div class="input-group pb-sm">
                        <label>
                            Username
                        </label>
                        <input v-model="username" type="text" class="form-control" />
                    </div>
                    <div class="input-group pb-sm">
                        <label>
                            Password
                        </label>
                        <input v-model="password" type="password" class="form-control" />
                    </div>
                    <button v-on:click="submit()" class="btn btn-core pull-right" style="margin-right: 7px;">Sign in</button>
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
                http.get('token?username=' + this.username + '&password=' + this.password + '&grantType=password').then(result => {
                    this.$store.dispatch('setAuth', { username: result.username, token: result.token });
                    this.$router.push({
                        name: 'dashboard'
                    });
                    notification.success(this, "Successfully logged in");
                }).catch(err => {
                    notification.error(this, "Invalid username or password");
                });
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