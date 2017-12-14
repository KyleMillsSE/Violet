<template>
    <div style="height: 100vh; width: 100vw; background-color: #0082c8;">
        <div class="off-centered">
            <div class="row">
                <div class="col-md-6">
                    <img style="padding-top: 30px;" src="/assets/lars-logo.png" alt="Lars logo">
                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <label>
                            Username
                        </label>
                        <input type="email" class="form-control" />
                    </div>
                    <div class="input-group pt-sm">
                        <label>
                            Password
                        </label>
                        <input type="password" class="form-control" />
                    </div>
                </div>
            </div>
         
        </div>
    </div>
</template>

<script>


    export default {

      name: 'login',
     
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
        font-size: 14px;
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