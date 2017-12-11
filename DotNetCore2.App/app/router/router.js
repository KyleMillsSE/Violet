import vue from 'vue'
import vueRouter from 'vue-router'
import loginPage from '../pages/login/login.vue'

vue.use(vueRouter)

const routes = [
    {
        path: '/login',
        name: 'login',
        component: loginPage
    },
];


const router = new vueRouter({ routes });

export default router 
