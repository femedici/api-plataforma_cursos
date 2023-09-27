import { createRouter, createWebHistory } from 'vue-router';
import Home from './pages/HomePage.vue'
import About from './pages/AboutPage.vue'

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home
        },
        {
            path: '/about',
            name: 'about',
            component: About
        }
    ]
});

export default router;