import { createRouter, createWebHistory} from "vue-router";

// import Home from '../views/HomePage.vue';
// import About from '../views/AboutPage.vue';
// import Login from '../views/LoginPage.vue';

const Home = () => import('../views/HomePage.vue');
const About = () => import('../views/AboutPage.vue');
const Login = () => import('../views/LoginPage.vue');
const Create = () => import('../views/CreatePage.vue');

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