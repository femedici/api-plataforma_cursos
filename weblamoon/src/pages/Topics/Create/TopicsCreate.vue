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
            <h2 class="text-2xl font-bold tracking-tight text-gray-800 m:text-2xl text-center">
                Crie / Acrescente tópicos para o seu curso
            </h2>
            <br>
            <form @submit.prevent="submitTopics">
                <!-- Use v-for to render forms for each topic -->
                <div v-for="(topic, index) in formData.topics" :key="index">
                    <h2 class="text-2xl mt-3 font-bold tracking-tight text-gray-800 m:text-2xl">
                        Tópico {{ index + 1 }}.
                    </h2>
                    <div class="space-y-12">
                        <div class="border-b border-white-900/10 pb-12">
                            <div class="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 m:grid-cols-6">
                                <div class="m:col-span-4">
                                    <label for="topicTitle" class="block text-m font-medium leading-6 text-white-900">
                                        Título do Tópico
                                    </label>
                                    <!-- Use v-model to bind to the topic object -->
                                    <div class="mt-2">
                                        <div
                                            class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                                            <input v-model="topic.title" type="text" name="topicTitle" id="topicTitle"
                                                autocomplete="username"
                                                class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                                                placeholder="Iniciando ...">
                                        </div>
                                    </div>
                                </div>

                                <div class="m:col-span-4">
                                    <label for="username" class="block text-m font-medium leading-6 text-white-900">Breve
                                        Descrição</label>
                                    <div class="mt-2">
                                        <div
                                            class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                                            <input v-model="topic.description" type="text" name="description"
                                                id="description" autocomplete="username"
                                                class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                                                placeholder="Nesse tópico vamos trabalhar ...">
                                        </div>
                                    </div>
                                </div>

                                <div>
                                    <div class="m:col-span-4">
                                        <label for="video"
                                            class="block text-m font-medium leading-6 text-white-900">Adicione a URL do
                                            Vídeo desse tópico</label>
                                        <div class="mt-2">
                                            <div
                                                class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                                                <input v-model="topic.video" type="text" name="video" id="video"
                                                    autocomplete="username"
                                                    class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                                                    placeholder="drive.com/">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Delete Topic Button -->
                    <div class="mt-6 mb-4 flex items-center justify-end gap-x-6">
                        <button @click="deleteTopic(index)" type="button"
                            class="text-m font-semibold leading-6 text-red-500">Deletar
                            Tópico</button>
                    </div>
                </div>
                <!-- Add Topic Button -->
                <div class="mt-6 mb-4 flex items-center justify-end gap-x-6">
                    <v-alert  v-if="created" closable icon="mdi-check-all" class=" text-center"
                        text="Tópicos criados/adicionados ao curso com sucesso! Apenas navegar para 'Curso Publicados'."
                        type="success"></v-alert>
                    <v-btn @click="addTopic" type="button" prepend-icon="mdi-plus-circle"
                        class="text-m font-semibold leading-6 text-white-900">Adicionar
                        Tópico</v-btn>
                    <button type="submit"
                        class="rounded-md bg-teal-400 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">
                        Criar Tópicos
                    </button>
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
            created: false,
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
        };
    },
    methods: {
        addTopic() {
            // Add a new topic object to the array
            this.formData.topics.push({
                referenceCourse: this.$route.params.id,
                title: '',
                description: '',
                video: ''
            });
        },
        deleteTopic(index) {
            // Remove the specified topic from the array
            this.formData.topics.splice(index, 1);
        },
        async submitTopics() {
            try {
                const topicData = this.formData.topics;

                // Use Promise.all to make multiple POST requests for each topic
                const responses = await Promise.all(
                    topicData.map(topic => axios.post('/Topic', topic))
                );

                // Check if all requests were successful
                if (responses.every(response => response.status === 200)) {
                    // All topics were successfully created
                    console.log('All topics were created successfully.');
                    this.created = true;

                    // Clear the form after successful submission
                    this.formData.topics = topicData.map(topic => ({
                        referenceCourse: topic.referenceCourse,
                        title: '',
                        description: '',
                        video: ''
                    }));
                } else {
                    // Handle errors or notify the user of any failed topics
                    console.error('Some topics could not be created.');
                    window.alert('Some topics could not be created.');
                }
            } catch (error) {
                // Handle errors here, such as network issues
                console.error('Error sending data:', error);
                window.alert('Error creating topics. Please try again.');
            }
        },
    },
};
</script>