import Vue from 'vue'
import VueRouter from 'vue-router'
import Hello from './hello.vue'

Vue.use(VueRouter)

const routes = [
    { path: '/', name: 'Hello', component: Hello },
];


const router = new VueRouter({ routes });

export default router 
