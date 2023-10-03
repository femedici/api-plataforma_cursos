<template>
    <div class="flex flex-wrap">
        <div class="w-full md:w-1/2 p-4">
            <v-img :width="600" cover class=""
                src="https://images.unsplash.com/photo-1526657782461-9fe13402a841?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1984&q=80"></v-img>
        </div>
        <div class="w-full md:w-1/2 p-4">
            <form @submit.prevent="submit()">
                <v-card class="mx-auto pa-12 pb-8" elevation="8" max-width="448" rounded="lg">
                    <h2 class="text-base font-semibold leading-7 text-indigo-600 lg:text-center">Login</h2>
                    <p class="mt-2 text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl lg:text-center">La Moon</p>
                    <v-img src="../assets/newlogo.png" class="object-cover h-48 w-96"></v-img>
                    <div class="text-subtitle-1 text-medium-emphasis">Account</div>

                    <v-text-field density="compact" placeholder="Email address" prepend-inner-icon="mdi-email-outline"
                        variant="outlined" v-model="form.email"></v-text-field>

                    <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
                        Password
                    </div>

                    <v-text-field :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
                        :type="visible ? 'text' : 'password'" density="compact" placeholder="Enter your password"
                        prepend-inner-icon="mdi-lock-outline" variant="outlined" v-model="form.password"
                        @click:append-inner="visible = !visible"></v-text-field>

                    <v-card-text class="text-center">
                        <a
                            class="size relative inline-flex items-center justify-start py-4 pl-10 pr-12 overflow-hidden font-semibold text-indigo-600 transition-all duration-150 ease-in-out rounded hover:pl-10 hover:pr-6 bg-gray-50 group">
                            <span
                                class="absolute bottom-0 left-0 w-full h-1 transition-all duration-150 ease-in-out bg-indigo-600 group-hover:h-full"></span>
                            <span class="absolute right-0 pr-4 duration-200 ease-out group-hover:translate-x-12">
                                <svg class="w-5 h-5 text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M14 5l7 7m0 0l-7 7m7-7H3"></path>
                                </svg>
                            </span>
                            <span
                                class="absolute left-0 pl-2.5 -translate-x-12 group-hover:translate-x-0 ease-out duration-200">
                                <svg class="w-5 h-5 text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M14 5l7 7m0 0l-7 7m7-7H3"></path>
                                </svg>
                            </span>
                            <span
                            type="submit" class="relative w-full text-left transition-colors duration-200 ease-in-out group-hover:text-white">Login</span>
                        </a>
                    </v-card-text>

                    <v-card-text class="text-center">
                        <a href="/create-user"
                            class="size relative inline-flex items-center justify-start py-4 pl-10 pr-12 overflow-hidden font-semibold text-indigo-600 transition-all duration-150 ease-in-out rounded hover:pl-10 hover:pr-6 bg-gray-50 group">
                            <span
                                class="absolute bottom-0 left-0 w-full h-1 transition-all duration-150 ease-in-out bg-indigo-600 group-hover:h-full"></span>
                            <span class="absolute right-0 pr-4 duration-200 ease-out group-hover:translate-x-12">
                                <svg class="w-5 h-5 text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M14 5l7 7m0 0l-7 7m7-7H3"></path>
                                </svg>
                            </span>
                            <span
                                class="absolute left-0 pl-2.5 -translate-x-12 group-hover:translate-x-0 ease-out duration-200">
                                <svg class="w-5 h-5 text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                                    xmlns="http://www.w3.org/2000/svg">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M14 5l7 7m0 0l-7 7m7-7H3"></path>
                                </svg>
                            </span>
                            <span
                                class="relative w-full text-left transition-colors duration-200 ease-in-out group-hover:text-white">Cadastrar</span>
                        </a>
                    </v-card-text>
                </v-card>
            </form>
        </div>
    </div>
</template>


<script>
import axios from '@/../src/axios';


export default {
    data: () => ({
        visible: false,
        form: {
            email: '',
            password: ''
        },
        loggedInUser: null // Para armazenar o usuário logado
    }),
    methods: {
        submit() {
            const user = this.form;
            console.log('Dados do formulário:', user);

            axios.get('/User/auth', {
                params: {
                    EmailRequest: user.email,
                    PasswordRequest: user.password
                }
            })
                .then(response => {
                    this.loggedInUser = response.data;
                    window.alert('Usuário logado: ' + this.loggedInUser.name);
                })
                .catch(error => {
                    console.error('Erro ao fazer a solicitação:', error);
                });
        }
    }
}
</script>