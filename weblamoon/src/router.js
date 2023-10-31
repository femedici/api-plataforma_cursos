import { createRouter, createWebHistory } from 'vue-router';
import Home from './pages/HomePage.vue'
import About from './pages/AboutPage.vue'
import Login from './pages/auth/LoginPage.vue'
import CreateUser from './pages/User/UserCreate.vue'
import ViewUser from './pages/User/UserView.vue'
import AlterUser from './pages/User/UserAlter.vue'
import CreateCourse from './pages/Courses/CoursesCreate.vue'
import ListCourses from './pages/Courses/CoursesList.vue'
import ViewCourse from './pages/Courses/CoursesPreview.vue'
import AlterCourse from './pages/Courses/Alter/CoursesAlter.vue'
import CreateTopic from './pages/Topics/Create/TopicsCreate.vue'
import EditTopic from './pages/Topics/Alter/TopicsEdit.vue'
import ViewTopic from './pages/Topics/View/TopicView.vue'
import AdminView from './pages/User/UserList.vue'
import Course from './pages/Courses/CourseAcess.vue'
import CourseSubscription from './pages/Courses/CoursesSub.vue'
import BecameCreator from './pages/BecameCreator.vue'
import CreatorCourses from './pages/Courses/CoursesCreator.vue'
import EditCourse from './pages/Courses/CoursesEdit.vue'

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
            path: '/view-course/:id',
            component: ViewCourse
        },
        {
            path: '/edit-course/:id',
            component: EditCourse
        },
        {
            path: '/alter-course',
            component: AlterCourse
        },
        {
            path: '/create-topic/:id',
            component: CreateTopic
        },
        {
            path: '/view-topic',
            component: ViewTopic
        },
        {
            path: '/edit-topics/:id',
            component: EditTopic
        },
        {
            path: '/admin-users',
            component: AdminView
        },
        {
            path: '/about',
            name: 'about',
            component: About
        },
        {
            path: '/course/:id',
            name: 'course',
            component: Course
        },
        {
            path: '/coursesSub',
            component: CourseSubscription
        },
        {
            path: '/becameCreator',
            component: BecameCreator
        },
        {
            path: '/creator-page',
            component: CreatorCourses
        }
    ]
});

export default router;