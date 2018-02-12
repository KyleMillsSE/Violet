<template>

    <div class="core-page fadeInRightt">
        <div class="slider" v-bind:class="{ 'slide-in': !showModal, 'slide-out pr-md': showModal }">
            <div class="box">
                <div class="box-header with-border">
                    <div class="col-sm-6">
                        <h1>Users</h1>
                    </div>
                </div>
                <div class="box-body pl-sm pr-sm pt-sm">
                    <div class="col-sm-12">
                        <div class="table-responsive-md" style="max-height: 555px; overflow-y: auto">
                            <table class="table table-striped">
                                <thead class="thead-light">
                                    <tr>
                                        <th>Username</th>
                                        <th>Email address</th>
                                        <th>Activity</th>
                                        <th class="text-right"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="user in users">
                                        <td>{{user.username}}</td>
                                        <td>{{user.email}}</td>
                                        <td>Logged out</td>
                                        <td class="text-right">
                                            <span>
                                                <button v-on:click="showModal = !showModal" class="btn btn-default btn-sm">Edit</button>
                                            </span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="pull-right pt-lg">
                            <nav aria-label="...">
                                <ul class="pagination">
                                    <li class="page-item disabled">
                                        <a class="page-link" href="#" tabindex="-1">Previous</a>
                                    </li>
                                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item active">
                                        <a class="page-link" href="#">2 <span class="sr-only">(current)</span></a>
                                    </li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item">
                                        <a class="page-link" href="#">Next</a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="slider-sub" v-bind:class="{ 'slide-in-sub': showModal, 'slide-out-sub': !showModal }">
            <div class="box" v-if="showModal">
                <div class="core-sub-page" v-bind:class="{ 'fadeInRightt': showModal}">


                    <div class="box-header with-border">
                        <div class="col-sm-12">
                            <h1>Edit User</h1>
                        </div>
                    </div>
                    <div class="box-body pl-sm pr-sm pt-sm">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label>Username</label>
                                <input type="text" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label>Email</label>
                                <input type="email" class="form-control" />
                            </div>
                        </div>
                        <div class="box-footer pb-md">
                            <div class="col-sm-12">
                                <button class="btn btn-danger btn-sm pull-left" v-on:click="deleteUser = true">Delete</button>
                                <div class="pull-right">
                                    <button class="btn btn-warning btn-sm" @click="showModal = false">Cancel</button>
                                    <button class="btn btn-success btn-sm">Save</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <warning-modal v-if="deleteUser" title="Delete user" message="Are you sure you want to delete user?"></warning-modal>
    </div>

</template>

<script>
    import restClient from '../../core/restClient/restClient'
    import notification from '../../core/notification/notification'
    import warningModal from '../../components/warningModal.vue'

    export default {
        name: 'users',
        data() {
            return {
                users: [],
                securityProfiles: [],
                showModal: false,
                deleteUser: false
            }
        },
        components: {
            warningModal
        },
        methods: {
            loadData() {
                restClient.get('users').then(success => {
                    this.users = success;
                }).catch(err => {
                    notification.error("Error occurred retreiving users");
                });

                restClient.get('securityprofiles').then(success => {
                    this.securityProfiles = success;
                }).catch(err => {
                    notification.error("Error occurred retreiving security profiles");
                });
            },
            edit() {
                this.showModal = true;
            },
            cancel() {
                this.showModal = false;
            }
        },
        created() { },
        mounted() {
            this.loadData();
        }
    }
</script>

<style scoped>
    .core-page {
        padding-top: 90px;
        padding-left: 210px;
        padding-right: 10px;
        height: 775px;

    }
    .core-sub-page {
        -webkit-animation-duration: 1.5s;
        animation-duration: 1.5s;
        -webkit-animation-fill-mode: both;
        animation-fill-mode: both;
    }

    .sub-form-footer {
        border-radius: 0;
        bottom: 0px;
        position: absolute;
        width: 100%;
    }

    .slider-sub {
        width: 10%;
        float: left;
    }

    .slide-in-sub {
        width: 39%;
        transition: width 1s ease 0.1s;
    }

    .slide-out-sub {
        width: 10%;
        transition: width 1s ease;
    }

    .slider {
        width: 99%;
        float: left;
    }

    .slide-in {
        width: 99%;
        transition: width 1s ease;
    }

    .slide-out {
        width: 60%;
        transition: width 1s ease;
    }


    @-webkit-keyframes fadeInRightt {
        0% {
            opacity: 0;
            -webkit-transform: translateX(20px);
        }

        100% {
            opacity: 1;
            -webkit-transform: translateX(0);
        }
    }

    @keyframes fadeInRightt {
        0% {
            opacity: 0;
            transform: translateX(20px);
        }

        100% {
            opacity: 1;
            transform: translateX(0);
        }
    }

    .fadeInRightt {
        -webkit-animation-name: fadeInRightt;
        animation-name: fadeInRightt;
    }

</style>