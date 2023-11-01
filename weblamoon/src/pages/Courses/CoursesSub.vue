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
            <div class="mb-10 sm:mb-0 mt-10 grid gap-4 grid-cols-1 sm:grid-cols-2 md:grid-cols-2 lg:grid-cols-3">
                <div v-for="(item, index) in data" :key="index"
                    class="relative group bg-slate-950 py-10 sm:py-20 px-4 flex flex-col space-y-2 items-center cursor-pointerrounded-md rounded-lg hover:translate-y-[-0.5rem] hover:shadow-md">
                    <a :href="'/course/' + item.id" class="w-full">
                        <v-row no-gutters>
                            <!-- Left half for the icon -->
                            <v-col cols="6">
                                <img class="w-full h-38 object-cover rounded-tl-md rounded-bl-md" :src="item.icon"
                                    alt="icon" />
                            </v-col>

                            <!-- Right half for the title and edit button -->
                            <v-col cols="6" class="relative">

                                <!-- Title in the right half -->
                                <h4
                                    class="text-white mt-12 text-2xl font-bold capitalize text-center rounded-tr-md rounded-br-md py-2 px-4">
                                    {{ item.title }}
                                </h4>
                            </v-col>
                        </v-row>
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
    watch: {
        getUserID: {
            immediate: true, // Trigger the watch immediately when the component is created
            handler(newValue) {
                if (!newValue) {
                    this.$router.push('/login'); // Redirect to the login page
                }
            },
        },
    },
};
</script>