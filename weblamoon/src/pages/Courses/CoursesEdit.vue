<template>
    <v-container fluid class="flex flex-col">
        <div class="flex items-end justify-between">
            <span
                class="max-w-2xl mb-4 text-4xl font-bold tracking-tight leading-none md:text-5xl xl:text-4xl text-cyan-100">
                Edite seu Curso
            </span>
        </div>
        <v-divider></v-divider>
    </v-container>


    <div class="ml-20 mr-20 mt-5 mb-8 bg-slate-300 border-solid border-2 rounded-md">
        <div class="ml-20 mr-20 mt-5">
            <div class="mt-6 mb-4 flex items-center justify-between">
                <div>
                    <h2 class="text-2xl font-bold tracking-tight text-gray-800 text-left m:text-3xl">
                        - Inscrições: <a class="underline decoration-emerald-500">{{this.qtdUsers}}</a>
                    </h2>
                    <h2 class="text-2xl font-bold tracking-tight text-gray-800 text-center m:text-3xl">
                        - Total arrecadado em vendas: <a class="underline decoration-emerald-500">R$ {{ totalAmount }}</a>
                    </h2>
                </div>
                <div class="flex items-center gap-x-6">
                    <a :href="'/edit-topics/' + this.$route.params.id">
                        <v-btn prepend-icon="mdi-pencil"
                            class="rounded-md bg-cyan-800 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Ver
                            Tópicos
                            Existentes</v-btn>
                    </a>
                    <a :href="'/create-topic/' + this.$route.params.id">
                        <v-btn prepend-icon="mdi-plus-circle"
                            class="rounded-md bg-cyan-800 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Adicionar
                            Tópicos
                        </v-btn>
                    </a>
                </div>
            </div>
            <h2 class="text-2xl font-bold tracking-tight text-gray-800 text-center m:text-3xl">Altere as informações
                principais do seu curso
            </h2>
            <br>
            <form @submit.prevent="submitCourse">
                <div class="space-y-12">
                    <div class="border-b border-white-900/10 pb-12">
                        <div class="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 m:grid-cols-6">
                            <div class="m:col-span-4">
                                <label for="username"
                                    class="block text-m font-medium leading-6 text-white-900">Titulo</label>
                                <div class="mt-2">
                                    <div
                                        class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                                        <input type="text" v-model="formData.title" id="title"
                                            class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6">
                                    </div>
                                </div>
                            </div>

                            <div class="m:col-span-4">
                                <label for="username" class="block text-m font-medium leading-6 text-white-900">Breve
                                    Descrição</label>
                                <div class="mt-2">
                                    <div
                                        class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                                        <input type="text" v-model="formData.description" id="description"
                                            class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                                            placeholder="Curso de ...">
                                    </div>
                                </div>
                            </div>

                            <div class="col-span-full">
                                <label for="about" class="block text-m font-medium leading-6 text-white-900">Sobre o
                                    curso</label>
                                <p class="mt-3 text-sm leading-6 text-white-600">Descreva um pouco sobre oque vai ser
                                    trabalhado no
                                    decorrer do curso. Ideias, teorias, conhecimentos, etc.</p>
                                <div class="mt-2">
                                    <textarea id="about" name="about" rows="3" v-model="formData.bodyText"
                                        class="block w-full rounded-md border-0 py-1.5 text-white-900 shadow-sm ring-1 ring-inset ring-white-300 placeholder:text-white-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 m:text-sm m:leading-6"></textarea>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div>
                        <label for="courseIcon" class="block text-m font-medium leading-6 text-white-900 mb-2">
                            Icone do Curso
                        </label>
                        <input ref="iconInput" type="file" id="courseIcon" @change="handleIconChange"
                            class="block w-full text-sm text-slate-500 file:mr-4 file:py-2 file:px-4 file:rounded-full file:border-0 file:text-sm file:font-semibold file:bg-violet-50 file:text-cyan-700 hover:file:bg-violet-100" />
                        <br>
                        <label for="courseBanner" class="block text-m font-medium leading-6 text-white-900 mb-2">
                            Capa Principal do Curso
                        </label>
                        <input ref="bannerInput" type="file" id="banner" @change="handleBannerChange"
                            class="block w-full text-sm text-slate-500 file:mr-4 file:py-2 file:px-4 file:rounded-full file:border-0 file:text-sm file:font-semibold file:bg-violet-50 file:text-cyan-700 hover:file:bg-violet-100" />
                    </div>
                    <div>
                        <div class="m:col-span-4">
                            <label for="username" class="block text-m font-medium leading-6 text-white-900">Adicione a URL
                                do Vídeo de
                                Apresentação do curso</label>
                            <div class="mt-2">
                                <div
                                    class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                                    <input type="text" v-model="formData.mainVideo" id="video"
                                        class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                                        placeholder="drive.com/">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="mt-6 mb-4 flex items-center justify-end gap-x-6">
                    <button type="submit"
                        class="rounded-md bg-teal-400 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Alterar
                        Informações</button>
                </div>
            </form>

        </div>
    </div>
</template>
  
<script>
import axios from '@/../src/axios';
import { mapGetters } from 'vuex';


export default {
    data() {
        return {
            formData: {
                id: '',
                title: '',
                description: '',
                mainVideo: '',
                bodyText: '',
                icon: '',
                banner: '',
                creator: '',
                creatorID: '',
                price: 0,
            },
            error: null,
            totalValue: 0,
            qtdUsers: null,
        };
    },
    computed: {
        ...mapGetters('user', ['getUserID', 'getUserName']), // Mapeando os getters do módulo 'user'
        totalAmount() {
            // Assuming formData.price is already a number
            return this.formData.price * this.qtdUsers;
        },
    },
    created() {
        const courseId = this.$route.params.id;
        this.formData.id = courseId;

        // Busque os detalhes do curso
        axios.get(`/Courses/id/${courseId}`)
            .then(response => {
                this.formData.title = response.data.title;
                this.formData.description = response.data.description;
                this.formData.mainVideo = response.data.mainVideo;
                this.formData.bodyText = response.data.bodyText;
                this.formData.icon = response.data.icon;
                this.formData.banner = response.data.banner;

                // Convert the price to an integer using parseInt
                this.formData.price = parseInt(response.data.price, 10);

                this.course = response.data;
            })
            .catch(error => {
                console.error("Erro ao buscar detalhes do curso:", error);
            });

        axios.get(`/Subscription/CountUsers`, {
            params: {
                idCourse: this.formData.id
            }
        })
            .then(response => {
                this.qtdUsers = response.data;
            })
            .catch(error => {
                console.error("Erro ao buscar detalhes do curso:", error);
            });
    },
    methods: {
        async handleIconChange(event) {
            const selectedIcon = event.target.files[0];
            if (selectedIcon) {
                // Read the selected icon file and convert it to a Base64 string
                const reader = new FileReader();
                reader.onload = (e) => {
                    this.formData.icon = e.target.result.split(',')[1]; // Extract the base64 part
                };
                reader.readAsDataURL(selectedIcon);
            }
        },
        async handleBannerChange(event) {
            const selectedBanner = event.target.files[0];
            if (selectedBanner) {
                const reader = new FileReader();
                reader.onload = (e) => {
                    this.formData.banner = e.target.result.split(',')[1]; // Extract the base64 part
                };
                reader.readAsDataURL(selectedBanner);
            }
        },
        async submitCourse() {
            this.formData.creator = this.getUserName;
            this.formData.creatorID = this.getUserID;
            try {
                const response = axios.put(`/Courses/${this.formData.id}`, this.formData);
                // Lide com a resposta aqui, por exemplo, exiba uma mensagem de sucesso
                console.log('Dados enviados com sucesso:', response.data);
                // Limpe o formulário após o envio
                this.formData.title = '';
                this.formData.body = '';
                this.formData.attachments = '';
                this.formData.password = '';
                this.error = false;

                window.alert('Curso alterado com sucesso!');
            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
                window.alert('Erro ao criar o curso. Por favor, tente novamente.');
            }
        },
    },
};
</script>