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
                Agora crie os tópicos do seu curso:
            </h2>
            <br>
            <form @submit="submitTopics">
                <!-- Use v-for to render forms for each topic -->
                <div v-for="(topic, index) in formData.topics" :key="index">
                    <h2 class="text-2xl font-bold tracking-tight text-gray-800 m:text-2xl">
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
                                            <input type="text" name="username" id="username" autocomplete="username"
                                                class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                                                placeholder="Nesse topico vamos trabalhar ...">
                                        </div>
                                    </div>
                                </div>

                                <div>
                                    <div class="m:col-span-4">
                                        <label for="username"
                                            class="block text-m font-medium leading-6 text-white-900">Adicione
                                            a URL do Vídeo desse tópico</label>
                                        <div class="mt-2">
                                            <div
                                                class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                                                <input type="text" name="username" id="username" autocomplete="username"
                                                    class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                                                    placeholder="drive.com/">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>

            <!-- Add Topic Button -->
            <div class="mt-6 mb-4 flex items-center justify-end gap-x-6">
                <button @click="addTopic" class="text-m font-semibold leading-6 text-white-900">Adicionar Tópico</button>
                <button @click="submitTopics" type=""
                    class="rounded-md bg-teal-400 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">
                    Publicar Curso
                </button>
            </div>
        </div>
    </div>
</template>
  
<script>
export default {
    data() {
        return {
            step: 1, // Initial step
            formData: {
                topics: [ // Initialize with one topic object
                    {
                        title: '',
                        description: '',
                        videoUrl: ''
                    }
                ]
            },
        };
    },
    methods: {
        addTopic() {
            // Add a new topic object to the array
            this.formData.topics.push({
                title: '',
                description: '',
                videoUrl: ''
            });
        },
        submitTopics() {
            // Handle form submission
            console.log(this.formData.topics);
        }
    },
};
</script>