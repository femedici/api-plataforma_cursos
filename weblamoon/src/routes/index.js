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
const CreateTopics = () => import('../pages/Topics/Create/TopicsCreate.vue');
const ViewTopic = () => import('../pages/Topics/View/TopicView.vue');
const AlterTopic = () => import('../pages/Topics/Alter/TopicsAlter.vue');
const AlterCourse = () => import('../pages/Courses/Alter/CoursesAlter.vue');

const routes = [
    { path: '/', component: Home},
    { path: '/about', component: About},
    { path: '/login', component: Login},
    { path: '/create-user', component: CreateUser},
    { path: '/list-users', component: ListUsers},
    { path: '/view-user/:email', component: ViewUser},
    { path: '/alter-user/:cpf', component: AlterUser},
    { path: '/list-courses', component: ListCourses},
    { path: '/create-course', component: CreateCourse},
    { path: '/view-course/:id', component: ViewCourse},
    { path: '/create-topic/:id', component: CreateTopics},
    { path: '/view-topic/:title', component: ViewTopic},
    { path: '/alter-topic/:courseid/:title', component: AlterTopic},
    { path: '/alter-course/:id', component: AlterCourse},
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;