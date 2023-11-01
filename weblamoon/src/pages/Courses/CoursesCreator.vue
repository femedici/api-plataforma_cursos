<template>
    <v-container fluid class="flex flex-col">
        <div class="flex items-end justify-between">
            <span
                class="max-w-2xl mb-4 text-4xl font-bold tracking-tight leading-none md:text-5xl xl:text-4xl text-cyan-100">
                Seus Cursos Publicados
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
                                <!-- Edit button at the top right -->
                                <v-btn class="absolute top-2 right-2" fab dark large color="cyan"
                                    :href="'/edit-course/' + item.id">
                                    <v-icon dark>
                                        mdi-pencil
                                    </v-icon>
                                </v-btn>

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
        };
    },
    created() {
        axios.get(`/Courses/creatorId/${this.getUserID}`)
            .then(response => {
                this.data = response.data;
                this.error = null;

                this.data.forEach(course => {
                    course.icon = 'data:image;base64,' + course.icon;
                });
            })
            .catch(error => {
                this.data = [];
                this.error = error.message;
            });
    },
    computed: {
        ...mapGetters('user', ['getUserID']), // Mapeando os getters do módulo 'user'
    },
};
</script>