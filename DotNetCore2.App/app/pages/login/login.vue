<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
    </div>
</template>

<script>

    //import restClient from '../components/restClient/restClient.js'

    export default {

      name: 'hello',
      data () {
        return {
          msg: 'Welcome to Your Vue.js App'
        }
      }
    }

</script>
