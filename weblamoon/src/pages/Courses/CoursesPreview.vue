<template>
    <div class=" isolate overflow-hidden bg-zinc-200 px-6 py-24 sm:py-32 lg:overflow-visible lg:px-0">
        <v-btn to="/list-courses" prepend-icon="mdi-format-horizontal-align-left" variant="text" class="text-sky-900">
            VOLTAR
        </v-btn>
        <div class="absolute inset-0 -z-10 overflow-hidden">
            <svg class="absolute left-[max(50%,25rem)] top-0 h-[64rem] w-[128rem] -translate-x-1/2 stroke-gray-300 [mask-image:radial-gradient(64rem_64rem_at_top,white,transparent)]"
                aria-hidden="true">
                <defs>
                    <pattern id="e813992c-7d03-4cc4-a2bd-151760b470a0" width="200" height="200" x="50%" y="-1"
                        patternUnits="userSpaceOnUse">
                        <path d="M100 200V.5M.5 .5H200" fill="none" />
                    </pattern>
                </defs>
                <rect width="100%" height="100%" stroke-width="0" fill="url(#e813992c-7d03-4cc4-a2bd-151760b470a0)" />
            </svg>
        </div>
        <div
            class="mx-auto grid max-w-2xl grid-cols-1 gap-x-8 gap-y-16 lg:mx-0 lg:max-w-none lg:grid-cols-2 lg:items-start lg:gap-y-10">
            <div
                class="lg:col-span-2 lg:col-start-1 lg:row-start-1 lg:mx-auto lg:grid lg:w-full lg:max-w-7xl lg:grid-cols-2 lg:gap-x-8 lg:px-8">
                <div class="lg:pr-4">
                    <div class="lg:max-w-lg">
                        <div class="text-5xl font-extrabold ...">
                            <span class="bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-300">
                                {{ course.title }}
                            </span>
                        </div>
                        <p class="text-base font-semibold leading-7 text-sky-900">Criado por {{ course.creator }}</p>
                        <p class="mt-6 text-xl leading-8 text-gray-700" style="word-wrap: break-word;">{{
                            course.description }}</p>
                    </div>
                </div>
            </div>
            <div
                class="-ml-12 -mt-12 p-12 lg:sticky lg:top-4 lg:col-start-2 lg:row-span-2 lg:row-start-1 lg:overflow-hidden">
                <h1 class="mt-2 text-1x font-bold tracking-tight text-gray-900 sm:text-2xl">Vídeo Introdutório</h1>
                <br>
                <div v-if="course.mainVideo != null">
                    <VideoPlayer :videoSource="course.mainVideo" />
                    <span
                        class="text-5xl bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-600">___________________________</span>
                </div>
                <div v-else>
                    <p>Sem video de apresentação</p>
                </div>
                <br><br><br><br><br><br><br><br><br>
                <v-btn @click="subscribeCourse" size="large" prepend-icon="mdi-check-decagram"
                    class="bg-gradient-to-r from-sky-700 to-emerald-600 text-neutral-50" :disabled="isDisabled">
                    Inscrever-se
                </v-btn>
                <br>
                <br>
                <v-btn :href="'/course/' + course.id" size="large" append-icon="mdi-arrow-right-bold-box-outline"
                    class="bg-gradient-to-r from-sky-700 to-emerald-600 text-neutral-50" :disabled="!show">
                    Acessar Curso
                </v-btn>
                <v-alert v-if="subNow" closable icon="mdi-check-all"
                    text="Inscrito com sucesso! Acesse o curso clicando no botão acima" type="success"
                    variant="tonal"></v-alert>
            </div>
            <div
                class="lg:col-span-2 lg:col-start-1 lg:row-start-2 lg:mx-auto lg:grid lg:w-full lg:max-w-7xl lg:grid-cols-2 lg:gap-x-8 lg:px-8">
                <div class="lg:pr-4">
                    <div class="max-w-xl text-base leading-7 text-gray-700 lg:max-w-lg" style="word-wrap: break-word;">
                        <h1 class="mt-2 text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">
                            <span
                                class="text-7xl bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-600">_</span>
                            Sobre o curso
                        </h1>
                        <br>
                        <p>{{ course.bodyText }}</p>
                        <br>
                    </div>
                </div>
            </div>
        </div>
        <h1 class="mt-2 text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl ml-8">
            <span class="text-7xl bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-600">_</span>
            Tópicos abordados
        </h1>
        <div class="flex flex-wrap lg:w-4/5 sm:mx-auto sm:mb-2 -mx-2 p-4">
            <div v-for="(item, index) in reversedTopics" :key="index" class="p-2 sm:w-1/2 w-full">
                <div
                    class="bg-gray-100 rounded flex p-4 h-full items-center shadow-2xl  hover:translate-y-[-0.3rem] hover:shadow-md">
                    <svg fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="3"
                        class="text-sky-900 w-6 h-6 flex-shrink-0 mr-4" viewBox="0 0 24 24">
                        <path d="M22 11.08V12a10 10 0 11-5.93-9.14"></path>
                        <path d="M22 4L12 14.01l-3-3"></path>
                    </svg>
                    <span class="font-medium">{{ item.title }}</span>
                </div>
            </div>
        </div>
    </div>
    <pop-payment v-if="showPayment" @close="closePayment"></pop-payment>
</template>

<script>
import axios from '@/../src/axios';
import { mapGetters } from 'vuex';
import VideoPlayer from '@/components/VideoPlayer.vue';
import PopPayment from '@/pages/PopPayment.vue';

export default {
    components: {
        'pop-payment': PopPayment,
        VideoPlayer, // Adicione o componente à seção de componentes
    },
    data() {
        return {
            showPayment: false,
            course: {
                id: null,
            },
            subData: {
                idCourse: '',
                idUser: '',
                progression: 0,
            },
            imageCourse: "",
            topics: [],
            error: null,
            userSubs: [],
            show: false,
            subNow: false,
        };
    },
    created() {
        const courseId = this.$route.params.id;
        this.subData.idCourse = courseId;

        // Busque os detalhes do curso
        axios.get(`/Courses/id/${courseId}`)
            .then(response => {
                this.course = response.data;
                this.imageCourse = 'data:image;base64,' + this.course.icon;
                if (this.course.icon == null || this.course.icon == '')
                    this.imageCourse = "https://blogassets.leverageedu.com/blog/wp-content/uploads/2019/10/23170101/List-of-Professional-Courses-after-Graduation.gif"
            })
            .catch(error => {
                console.error("Erro ao buscar detalhes do curso:", error);
            });

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

        // Buscando se o usuário é inscrito nesse curso
        // 1° pega todos as subscrições do usuário
        axios.get(`/Subscription/idUser/${this.getUserID}`)
            .then(response => {
                this.userSubs = response.data;
                console.log('Inscrições do usuário resgatadas.');

                console.log("User Subscriptions:", this.userSubs);
                console.log("Course ID to check:", this.subData.idCourse);

                for (const subscription of this.userSubs) {
                    console.log("Subscription ID Course:", subscription.idCourse);
                    if (parseInt(subscription.idCourse) === parseInt(this.subData.idCourse)) {
                        console.log(`User is subscribed to course with ID: ${this.subData.idCourse}`);
                        this.show = true;
                        break; // Break out of the loop since we found a match
                    }
                }
            }).catch(error => {
                this.error = error.message;
                console.error("Erro ao carregar inscrições", error);
            });
    },
    computed: {
        ...mapGetters('user', ['getUserID', 'getUserName']), // Mapeando os getters do módulo 'user'
        isDisabled() {
            // Use a computed property to return true if either of the conditions is met
            return this.show || !this.getUserID;
        },
        reversedTopics() {
            // Reverse the topics array
            return this.topics.slice().reverse();
        },
    },
    methods: {
        closePayment() {
            this.showPayment = false;
        },
        openPayment() {
            this.showPayment = true;
        },
        subscribeCourse() {
            this.openPayment();
            this.subData.idUser = this.getUserID;

            axios.post('/Subscription', this.subData, {
                headers: {
                    'Content-Type': 'application/json', // Set the content type to JSON
                },
            })
                .then(response => {
                    console.log('Data sent successfully:', response.data);

                    console.log('Inscrito com sucesso!' + this.getUserName);
                    this.subNow = true;
                    this.show = true;
                })
                .catch(error => {
                    console.error('Registration not completed, please try again', error);
                    // Handle the error appropriately
                });
        },
    },
};

// REFERENCIAS OLD CODES
//-------------------------------------------------------------
// deleteCourse(id) {
//     axios.delete(`/Courses/${id}`)
//         .then(response => {
//             this.course = response.data;
//             window.alert('Curso deletado com sucesso!');
//             router.push(`/list-courses`);
//         })
//         .catch(error => {
//             console.error("Erro ao deletar curso:", error);
//         });
// },
// confirmDeleteCourse() {
//     const shouldDelete = window.confirm("Tem certeza de que deseja deletar este curso?");

//     if (shouldDelete) {
//         this.deleteCourse(this.course.id);
//     }
// },
</script>
