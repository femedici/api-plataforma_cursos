import { createRouter, createWebHistory} from "vue-router";

const Home = () => import('../pages/Home/HomePage.vue');
const About = () => import('../pages/About/AboutPage.vue');
const Login = () => import('../pages/Login/LoginPage.vue');
const Create = () => import('../pages/Create/CreatePage.vue');

const routes = [
    { path: '/', component: Home},
    { path: '/about', component: About},
    { path: '/login', component: Login},
    { path: '/create', component: Create},
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;