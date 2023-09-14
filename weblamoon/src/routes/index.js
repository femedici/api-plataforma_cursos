import { createRouter, createWebHistory} from "vue-router";

const Home = () => import('../pages/Home/HomePage.vue');
const About = () => import('../pages/About/AboutPage.vue');
const Login = () => import('../pages/Login/LoginPage.vue');
const CreateUser = () => import('../pages/User/Create/UserCreate.vue');
const ListUsers = () => import('../pages/User/List/UserList.vue');
const ViewUser = () => import('../pages/User/View/UserView.vue');
const AlterUser = () => import('../pages/User/Alter/UserAlter.vue');
const CreateCourse = () => import('../pages/Courses/Create/CoursesCreate.vue');
const ListCourses = () => import('../pages/Courses/List/CoursesList.vue');
const ViewCourse = () => import('../pages/Courses/View/CoursesView.vue');

const routes = [
    { path: '/', component: Home},
    { path: '/about', component: About},
    { path: '/login', component: Login},
    { path: '/create-user', component: CreateUser},
    { path: '/list-users', component: ListUsers},
    { path: '/view-user', component: ViewUser},
    { path: '/alter-user', component: AlterUser},
    { path: '/list-courses', component: ListCourses},
    { path: '/create-course', component: CreateCourse},
    { path: '/view-course', component: ViewCourse},
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;