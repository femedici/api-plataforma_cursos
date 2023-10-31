<template>
    <v-container fluid class="flex flex-col">
        <div class="flex items-end justify-between">
            <span
                class="max-w-2xl mb-4 text-4xl font-bold tracking-tight leading-none md:text-5xl xl:text-4xl text-cyan-100">
                Publique seu curso
            </span>
        </div>
        <v-divider></v-divider>
    </v-container>

    <div class="ml-20 mr-20 mt-5 mb-8 bg-slate-300 border-solid border-2 rounded-md">
        <div class="ml-20 mr-20 mt-5">
            <div class="mt-6 mb-4 flex items-center justify-end gap-x-6">
                <a :href="'/edit-course/' + this.$route.params.id">
                    <v-btn prepend-icon="mdi-pencil"
                        class="rounded-md bg-cyan-800 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Editar
                        Informações Curso</v-btn>
                </a>
                <a :href="'/create-topic/' + this.$route.params.id">
                    <v-btn prepend-icon="mdi-plus-circle"
                        class="rounded-md bg-cyan-800 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Adicionar
                        Tópicos</v-btn>
                </a>
            </div>
            <h2 class="text-2xl font-bold tracking-tight text-gray-800 m:text-2xl text-center">
                Edite as informações dos tópicos já existentes
            </h2>
            <br>
            <form @submit="submitTopics">
                <div class="flex flex-wrap lg:w-4/5 sm:mx-auto sm:mb-2 -mx-2 p-4">
                    <div v-for="(item, index) in topics" :key="index" class="p-2 mt-1 w-full">
                        <h2 class="text-2xl mt-3 font-bold tracking-tight text-gray-800 m:text-2xl">
                            Tópico {{ index + 1 }}.
                        </h2>
                        <div class="bg-gray-100 rounded flex p-4 items-center shadow-2xl">
                            <svg fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round"
                                stroke-width="3" class="text-sky-900 w-6 h-6 flex-shrink-0 mr-4" viewBox="0 0 24 24">
                                <path d="M22 11.08V12a10 10 0 11-5.93-9.14"></path>
                                <path d="M22 4L12 14.01l-3-3"></path>
                            </svg>
                            <span class="font-medium">{{ item.title }}</span>
                        </div>
                        <div class="mt-6 mb-4 flex items-center justify-end gap-x-6">
                            <button @click="deleteTopic(index)" type="button"
                                class="rounded-md bg-rose-600 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-rose-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">
                                Deletar Tópico
                            </button>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import axios from '@/../src/axios';

export default {
    data() {
        const courseId = this.$route.params.id;
        return {
            formData: {
                topics: [ // Initialize with one topic object
                    {
                        referenceCourse: courseId,
                        title: '',
                        description: '',
                        video: ''
                    }
                ]
            },
            topics: [],
        };
    },
    created() {
        const courseId = this.$route.params.id;

        // Busque os tópicos relacionados ao curso'
        axios.get(`/Topic/referencecourse/${courseId}`)
            .then(response => {
                this.topics = response.data;
                this.error = null;
            })
            .catch(error => {
                this.topics = [];
                this.error = error.message;
                console.error("Erro ao buscar tópicos:", error);
            });
    },
    methods: {
        deleteTopic(index) {
            // Set the topic to delete
            this.topicToDelete = this.topics[index];
            if (window.confirm("Tem certeza que deseja deletar esse tópico?")) {
                // User confirmed, proceed with deletion
                this.confirmDelete();
            }
        },
        confirmDelete() {
            if (this.topicToDelete) {
                // Send an API request to delete the topic
                axios
                    .delete(`/Topic/${this.topicToDelete.title}`)
                    .then((response) => {
                        // Topic successfully deleted
                        console.log('Topic deleted:', this.topicToDelete.title);
                        console.log(response);
                        // Remove the topic from the list
                        this.topics = this.topics.filter(
                            (topic) => topic.title !== this.topicToDelete.title
                        );
                        // Reset the topicToDelete variable
                        this.topicToDelete = null;
                        // Refresh the page
                        window.location.reload();
                    })
                    .catch((error) => {
                        // Handle errors or notify the user
                        console.error('Error deleting the topic:', error);
                    });
            }
            // Reset the topicToDelete variable
            this.topicToDelete = null;
        },
    },
};
</script>