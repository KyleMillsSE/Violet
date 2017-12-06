var Vue = require('vue')
var VueRouter = require('vue-router')
var Hello = require('./hello.vue')

Vue.use(VueRouter)

const routes = [
    { path: '/', component: Hello },
];

// fix
const router = new VueRouter({ routes });

export { router };
//const routes = [
//    { path: '/', component: Hello },
//    { path: '/join', component: Join },
//];

//// fix
//const router = new VueRouter({ routes });

//new Router({
//    routes: [
//        {
//            path: '/',
//            name: 'Hello',
//            component: Hello
//        }
//    ]
//}) 
