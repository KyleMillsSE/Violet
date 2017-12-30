import vue from 'vue'
import vueRouter from 'vue-router'
import loginPage from '../pages/login/login.vue'
import usersPage from '../pages/users/users.vue'
import dashboardPage from '../pages/dashboard/dashboard.vue'
import store from '../store/store'

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
        component: dashboardPage,
        meta: { requiresAuth: true }
    },
    {
        path: '/users',
        name: 'users',
        component: usersPage,
        meta: { requiresAuth: true }
    },
    {
        path: '*', redirect: '/dashboard'
    }
];

const router = new vueRouter({ routes });

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
        // this route requires auth, check if has token
        // if not, redirect to login page.
        if (!store.getters.isAuthenticated) {
            next({
                path: '/login'
            })
        } else {
            next()
        }
    } else {
        next() // make sure to always call next()!
    }
})

export default router 
