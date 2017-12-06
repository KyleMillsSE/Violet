<style>
    .red {
        color: #f00;
    }
</style>

<template>
    <div>
        <h1 class="red">{{msg}}</h1>
        <div>
            <router-view></router-view>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                msg: 'Hello world!'
            }
        }
    }
</script>