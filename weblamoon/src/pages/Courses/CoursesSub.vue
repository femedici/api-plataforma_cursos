<template>
    <v-container fluid class="flex flex-col">
        <div class="flex items-end justify-between">
            <span
                class="max-w-2xl mb-4 text-4xl font-bold tracking-tight leading-none md:text-5xl xl:text-4xl text-cyan-100">
                Cursos Inscrito
            </span>
        </div>
        <v-divider></v-divider>
    </v-container>

    <v-container fluid>
        <div class="flex-1 px-2 sm:px-0">
            <div class="mb-10 sm:mb-0 mt-10 grid gap-4 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
                <div v-for="(item, index) in data" :key="index"
                    class="relative group bg-gray-900 py-10 sm:py-20 px-4 flex flex-col space-y-2 items-center cursor-pointer rounded-md ">
                    <img class="w-20 h-20 object-cover object-center rounded-full" :src="item.icon" alt="icon"/>
                    <a :href="'/course/' + item.id">
                        <h4 class="text-white text-2xl font-bold capitalize text-center rounded-full py-2 px-4 hover:bg-cyan-900 focus:ring-4 focus:ring-gray-100">{{ item.title }}</h4>
                    </a>
                </div>
            </div>
        </div>
    </v-container>
</template>


<script>
import axios from '@/../src/axios';
import { mapGetters } from 'vuex';


export default {
    data() {
        return {
            data: [],
            error: null,
            userSubs: [], //lista de inscrições do usuário
        };
    },
    created() {
        axios.get(`/Subscription/idUser/${this.getUserID}`)
            .then(response => {
                this.userSubs = response.data;
                this.error = null;
                console.log(this.userSubs);

                // Create an array of promises for each course request
                const coursePromises = [];

                for (const subscription of this.userSubs) {
                    coursePromises.push(
                        axios.get(`/Courses/id/${subscription.idCourse}`)
                            .then(courseResponse => {
                                const course = courseResponse.data;
                                if (course.icon) {
                                    course.icon = 'data:image;base64,' + course.icon;
                                } else {
                                    course.icon = "https://e7.pngegg.com/pngimages/23/412/png-clipart-computer-icons-professional-certification-business-course-certificates-blue-people.png";
                                }
                                return course;
                            })
                            .catch(error => {
                                console.error("Erro ao carregar curso", error);
                                return null; // Handle the error gracefully
                            })
                    );
                }

                // Wait for all promises to resolve
                Promise.all(coursePromises)
                    .then(courses => {
                        this.data = courses.filter(course => course !== null);
                        console.log(this.data); // Print the data to the console
                    });
            })
            .catch(error => {
                this.error = error.message;
                console.error("Erro ao carregar inscrições", error);
            });
    },
    computed: {
        ...mapGetters('user', ['getUserID', 'getUserName']), // Mapeando os getters do módulo 'user'
    },
};
</script>