import { createRouter, createWebHistory } from 'vue-router';
import Home from './pages/HomePage.vue'
import About from './pages/AboutPage.vue'
import Login from './pages/LoginPage.vue'
import CreateUser from './pages/User/UserCreate.vue'
import ViewUser from './pages/User/UserView.vue'
import AlterUser from './pages/User/UserAlter.vue'
import CreateCourse from './pages/Courses/Create/CoursesCreate.vue'
import ListCourses from './pages/Courses/List/CoursesList.vue'
import ViewCourse from './pages/Courses/View/CoursesView.vue'
import AlterCourse from './pages/Courses/Alter/CoursesAlter.vue'
import CreateTopic from './pages/Topics/Create/TopicsCreate.vue'
import ViewTopic from './pages/Topics/View/TopicView.vue'

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home
        },
        {
            path: '/login',
            name: 'login',
            component: Login
        },
        {
            path: '/create-user',
            name: 'create-user',
            component: CreateUser
        },
        {
            path: '/view-user',
            component: ViewUser
        },
        {
            path: '/alter-user',
            component: AlterUser
        },
        {
            path: '/create-course',
            component: CreateCourse
        },
        {
            path: '/list-courses',
            component: ListCourses
        },
        {
            path: '/view-course',
            component: ViewCourse
        },
        {
            path: '/alter-course',
            component: AlterCourse
        },
        {
            path: '/create-topic',
            component: CreateTopic
        },
        {
            path: '/view-topic',
            component: ViewTopic
        },
        {
            path: '/about',
            name: 'about',
            component: About
        }
    ]
});

export default router;