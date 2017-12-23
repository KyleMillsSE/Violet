import vue from 'vue'
import vueRouter from 'vue-router'
import loginPage from '../pages/login/login.vue'
import dashboardPage from '../pages/dashboard/dashboard.vue'

vue.use(vueRouter)

const routes = [
    {
        path: '/login',
        name: 'login',
        component: loginPage
    },
    {
        path: '/dashboard',
        name: 'dashboard',
        component: dashboardPage
    },
    {
        path: '*', redirect: '/login'
    }
];


const router = new vueRouter({ routes });

export default router 
