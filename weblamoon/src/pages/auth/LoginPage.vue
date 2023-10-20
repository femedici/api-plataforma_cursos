<template>
    <section class="min-h-screen flex items-stretch text-white ">
        <div class="lg:flex w-1/2 hidden bg-gray-500 bg-no-repeat bg-cover relative items-center"
            style="background-image: url(https://images.unsplash.com/photo-1601933513556-7926c45d1c49?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80);">
            <div class="absolute bg-black opacity-60 inset-0 z-0"></div>
            <div class="w-full px-24 z-10">
                <h1 class="text-5xl font-bold text-left tracking-wide font-sans">Entre na sua conta já existente </h1>
            </div>
        </div>
        <div
            class="lg:w-1/2 w-full flex items-center justify-center text-center md:px-16 px-0 z-0 bg-gradient-to-r from-[#6591cb]">
            <div class="w-full py-6 z-20">
                <h1 class="flex justify-center items-center">
                    <v-img src="@/assets/newlogo.png" class="object-cover h-48 w-96"></v-img>
                </h1>
                <form @submit.prevent="submit()">
                    <v-card class="mx-auto pa-12 pb-8" elevation="8" max-width="448" rounded="lg">
                        <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
                            Email</div>
                        <v-text-field density="compact" placeholder="Email cadastrado"
                            prepend-inner-icon="mdi-email-outline" variant="outlined" v-model="form.email"></v-text-field>

                        <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
                            Senha
                        </div>

                        <v-text-field :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
                            :type="visible ? 'text' : 'password'" density="compact" placeholder="Coloque sua senha"
                            prepend-inner-icon="mdi-lock-outline" variant="outlined" v-model="form.password"
                            @click:append-inner="visible = !visible"></v-text-field>

                        <v-card-text class="text-center">
                            <a @click="submit" class="relative inline-block text-lg group">
                                <span
                                    class="relative z-10 block px-5 py-3 overflow-hidden font-medium leading-tight text-gray-800 transition-colors duration-300 ease-out border-2 border-gray-900 rounded-lg group-hover:text-white">
                                    <span class="absolute inset-0 w-full h-full px-5 py-3 rounded-lg bg-gray-50"></span>
                                    <span
                                        class="absolute left-0 w-48 h-48 -ml-2 transition-all duration-300 origin-top-right -rotate-90 -translate-x-full translate-y-12 bg-gray-900 group-hover:-rotate-180 ease"></span>
                                    <span class="relative">Login</span>
                                </span>
                                <span
                                    class="absolute bottom-0 right-0 w-full h-12 -mb-1 -mr-1 transition-all duration-200 ease-linear bg-gray-900 rounded-lg group-hover:mb-0 group-hover:mr-0"
                                    data-rounded="rounded-lg"></span>
                            </a>
                        </v-card-text>

                        <v-card-text class="text-center">
                            <a href="/create-user" class="relative inline-block text-lg group">
                                <span
                                    class="relative z-10 block px-5 py-3 overflow-hidden font-medium leading-tight text-gray-800 transition-colors duration-300 ease-out border-2 border-gray-900 rounded-lg group-hover:text-white">
                                    <span class="absolute inset-0 w-full h-full px-5 py-3 rounded-lg bg-gray-50"></span>
                                    <span
                                        class="absolute left-0 w-48 h-48 -ml-2 transition-all duration-300 origin-top-right -rotate-90 -translate-x-full translate-y-12 bg-gray-900 group-hover:-rotate-180 ease"></span>
                                    <span class="relative">Cadastre-se</span>
                                </span>
                                <span
                                    class="absolute bottom-0 right-0 w-full h-12 -mb-1 -mr-1 transition-all duration-200 ease-linear bg-gray-900 rounded-lg group-hover:mb-0 group-hover:mr-0"
                                    data-rounded="rounded-lg"></span>
                            </a>
                        </v-card-text>
                    </v-card>
                </form>
                <div class="fixed top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2">
                    <LoginWarning ref="loginWarning" />
                </div>
            </div>
        </div>
    </section>
</template>


<script>
import axios from '@/../src/axios';
import { mapActions } from 'vuex';
import LoginWarning from '@/components/LoginAlert.vue';

export default {
    components: {
        LoginWarning, // Adicione o componente à seção de componentes
    },
    data: () => ({
        visible: false,
        form: {
            email: '',
            password: ''
        },
        loggedInUser: null // Para armazenar o usuário logado
    }),
    methods: {
        ...mapActions('user', ['setUser']), // Mapeando a action setUser do módulo 'user'
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
                    this.$store.dispatch('user/setUser', response.data);
                    this.$refs.loginWarning.openLoginWarning('Pronto! ' + response.data.name);
                })
                .catch(error => {
                    window.alert('Login não realizado, revise o login e senha!',error);
                });
        }
    }
}
</script>
