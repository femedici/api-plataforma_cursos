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
            <div class="mb-10 sm:mb-0 mt-10 grid gap-4 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
                <div v-for="(item, index) in data" :key="index"
                    class="relative group bg-gray-900 py-10 sm:py-20 px-4 flex flex-col space-y-2 items-center cursor-pointer rounded-md ">
                    <img class="w-20 h-20 object-cover object-center rounded-full" :src="item.icon" alt="icon" />
                    <a :href="'/course/' + item.id">
                        <h4
                            class="text-white text-2xl font-bold capitalize text-center rounded-full py-2 px-4 hover:bg-cyan-900 focus:ring-4 focus:ring-gray-100">
                            {{ item.title }}</h4>
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