<template>
    <div class=" isolate overflow-hidden bg-zinc-200 px-6 py-24 sm:py-32 lg:overflow-visible lg:px-0">
        <v-btn to="/coursesSub" prepend-icon="mdi-format-horizontal-align-left" variant="text" class="text-sky-900">
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
        <v-progress-linear color="green" :model-value="calculateCompletionPercentage()" :height="8"></v-progress-linear>
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
                    </div>
                </div>
            </div>
            <div
                class="lg:col-span-2 lg:col-start-1 lg:row-start-2 lg:mx-auto lg:grid lg:w-full lg:max-w-7xl lg:grid-cols-2 lg:gap-x-8 lg:px-8">
                <div class="lg:pr-4">
                    <div class="max-w-xl text-base leading-7 text-gray-700 lg:max-w-lg">
                        <div class="text-3xl font-extrabold items-center justify-center">
                            <h1 v-if="checkConclusion()" class="bg-clip-text text-emerald-400"><a class="underline decoration-emerald-500">Curso concluido com sucesso!</a></h1>
                        </div>
                        <h1 class="mt-2 text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">
                            <span
                                class="text-7xl bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-600">_</span>
                            Sobre o Curso
                        </h1>
                        <br>
                        <p>{{ course.bodyText }}</p>
                        <h1 class="mt-2 text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">
                            <span
                                class="text-7xl bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-600">_</span>
                            Tópicos
                        </h1>
                    </div>
                </div>
            </div>
        </div>
        <div class="flex flex-wrap lg:w-4/5 sm:mx-auto sm:mb-2 -mx-2 p-4">
            <v-expansion-panels class="mb-6">
                <v-expansion-panel v-for="(item, index) in reversedTopics" :key="index"
                    class="rounded-lg mb-4 border-inherit">
                    <v-expansion-panel-title expand-icon="mdi-menu-down">
                        <div class="text-2xl mt-2 font-bold tracking-tight">
                            <span class="bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-600">
                                {{ item.title }}
                            </span>
                        </div>
                    </v-expansion-panel-title>
                    <v-expansion-panel-text>
                        <v-row no-gutters>
                            <v-col cols="4">
                                <h1 class="mt-2 font-bold tracking-tight text-gray-900 sm:text-2xl">
                                    <span
                                        class="text-5xl bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-600">_</span>
                                    Neste video:
                                </h1>
                                <v-sheet class="pa-2 ma-2 break-all" v-html="item.description"></v-sheet>
                            </v-col>
                            <v-col cols="8">
                                <v-sheet class="pa-2 ma-2">
                                    <!-- Pass the progressData as a prop to the VideoPlayer component -->
                                    <VideoPlayer :videoSource="item.video" :progressData="getProgressData(item.id)" />
                                    <span
                                        class="text-5xl bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-600">____________________________</span>
                                </v-sheet>
                            </v-col>
                        </v-row>
                        <div class="ml-3">
                            <v-switch color="success" :model-value="getProgressData(item.id).progress" label="Concluído"
                                :key="`switch-${item.id}`"
                                @change="handleSwitchChange(getProgressData(item.id))"></v-switch>
                        </div>
                    </v-expansion-panel-text>
                </v-expansion-panel>
            </v-expansion-panels>
        </div>
    </div>
    <v-divider></v-divider>
</template>

<script>
import axios from '@/../src/axios';
import VideoPlayer from '@/components/VideoPlayer.vue';
import { mapGetters } from 'vuex';

export default {
    components: {
        VideoPlayer, // Adicione o componente à seção de componentes
    },
    data() {
        return {
            course: {
                id: null,
            },
            subData: {
                idCourse: '',
                idUser: '',
                progression: 0,
            },
            imageCourse: "",
            progressData: [],
            subscription: "",
            topics: [],
            error: null,
            userSubs: [],
            progressionValue: "",
        };
    },
    computed: {
        ...mapGetters('user', ['getUserID', 'getUserName']), // Mapeando os getters do módulo 'user'
        reversedTopics() {
            // Reverse the topics array
            return this.topics;
        },
        progressDataMap() {
            const map = {};
            this.progressData.forEach(data => {
                map[data.idTopic] = data;
            });
            return map;
        },
    },
    watch: {
        progressData: {
            handler() {
                // Check conclusion whenever progressData changes
                this.checkConclusion();
            },
            deep: true,
        },
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

        axios.get(`/Subscription/user/${this.getUserID}/course/${courseId}`)
            .then(response => {
                this.subscription = response.data;
                console.log("Subscription:", response.data[0].id);

                // Make the second request only after the first request is completed
                return axios.get(`/Progression/idSubscription/${this.subscription[0].id}`);
            })
            .then(response => {
                this.progressData = response.data;
                console.log("Progressions:", response.data);
                this.error = null;
            })
            .catch(error => {
                this.subscription = [];
                this.progressData = [];
                this.error = error.message;
                console.error("Error:", error);
            });
    },
    methods: {
        // Get progress data for a specific topic id
        getProgressData(topicId) {
            return this.progressData.find(data => data.idTopic === topicId) || { idSubscription: '', idTopic: topicId, progress: false, id: null };
        },
        checkConclusion() {
            return this.progressData.every(data => data.progress);
        },
        handleSwitchChange(progressData) {
            if (progressData.progress !== undefined) {
                const progressId = progressData.id;
                const newProgressValue = !progressData.progress;

                axios.put(`/Progression/${progressId}/ChangeProgress`, newProgressValue, {
                    headers: {
                        'Content-Type': 'application/json',
                    },
                })
                    .then(response => {
                        console.log('Progression updated successfully', response.data);

                        // Update progressData without directly modifying it
                        const updatedProgressData = this.progressData.map(data => {
                            if (data.id === progressId) {
                                return { ...data, progress: newProgressValue };
                            }
                            return data;
                        });

                        // Assign the updated array to trigger reactivity
                        this.progressData = updatedProgressData;
                    })
                    .catch(error => {
                        console.error('Error updating progression', error);
                        // Handle the error appropriately
                    });
            } else {
                console.error('Invalid progressData:', progressData);
            }
        },
        calculateCompletionPercentage() {
            // Calculate the percentage of completion based on the progressData
            const totalTopics = this.progressData.length;
            const completedTopics = this.progressData.filter(data => data.progress).length;

            // Ensure totalTopics is not zero to avoid division by zero
            const completionPercentage = totalTopics > 0 ? (completedTopics / totalTopics) * 100 : 0;

            return completionPercentage;
        },
    },
};
</script>