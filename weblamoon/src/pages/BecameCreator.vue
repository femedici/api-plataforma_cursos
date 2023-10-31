<template>
    <div
        style="background-image:url(https://images.unsplash.com/photo-1618397746666-63405ce5d015?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D)">
        <section class="bg-violet lg:pt-[120px] pb-10 lg:pb-20"
            style="background-image:url(https://images.unsplash.com/photo-1618397746666-63405ce5d015?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);">
            <div class="grid max-w-screen-xl px-4 py-8 mx-auto lg:gap-8 xl:gap-0 lg:py-16 lg:grid-cols-12">
                <div class="lg:col-span-7" style="margin-top: 140px;">
                    <h1 style="margin-right: 10px;"
                        class="max-w-2xl mb-4 text-4xl font-extrabold tracking-tight leading-none md:text-5xl xl:text-6xl dark:text-blue-950">
                        Tornar-se um Criador!
                    </h1>
                    <p style="margin-right: 10px;"
                        class="max-w-2xl mb-6 font-light text-blue-900-100 lg:mb-8 md:text-lg lg:text-xl dark:text-blue-900">
                        <strong>Aqui te mostraremos o que significa ser um Criador LaMoon, no que isso te ajuda e no impacto
                            que
                            isso traz ao seu negócio.</strong>
                    </p>
                    <p style="margin-right: 10px;"
                        class="max-w-2xl mb-6 font-light text-blue-900-100 lg:mb-8 md:text-lg lg:text-xl dark:text-blue-900">
                        <strong>Continue scrollando e se torne um Criador.</strong>
                    </p>
                </div>
                <div class="lg:col-span-5 flex justify-end">
                    <v-img src="@/assets/BecomeCreator/1.png" class="float-right"></v-img>
                </div>
            </div>
        </section>

        <div
            style="background-image:url(https://images.unsplash.com/photo-1618397746666-63405ce5d015?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);">
            <section id="section1" class="section">
                <div class="section-content">
                    <div class="section-text">
                        <span class="large-text bg-clip-text text-transparent bg-gradient-to-r to-sky-700 from-sky-700">
                            <strong>Demonstração de conhecimentos</strong>
                        </span>
                        <p class="medium-text">
                            Ao se tornar um Criador LaMoon, você não só está repassando diversas experiencias
                            que alavancam a carreira de outras pessoas, como também está contribuindo para o seu
                            auto-reconhecimento, permitindo que diversos profissionais e chefes de empresas se interessem
                            nos seus conhecimentos e experiencias.
                        </p>
                    </div>
                    <div class="section-image">
                        <v-img src="@/assets/BecomeCreator/2.png"></v-img>
                    </div>
                </div>
            </section>
            <section id="section2" class="section">
                <div class="section-content">
                    <div class="section-image">
                        <v-img src="@/assets/BecomeCreator/3.png"></v-img>
                    </div>
                    <div class="section-text">
                        <span class="large-textl bg-clip-text text-transparent bg-gradient-to-r to-sky-600 from-sky-600">
                            <strong>Ótimo para o seu negócio</strong>
                        </span>
                        <p class="medium-textl">
                            Imagine, contratar novos desenvolvedores para o seu projeto, técnicos para sua empresa, ou mão
                            de obra para algum sistema mecânico. Com a LaMoon, você pode providenciar os cursos
                            preparatórios facilmente com todo sistema de gerenciamento e infraestrutura de nossa aplicação.
                        </p>
                    </div>
                </div>
            </section>
            <section id="section3" class="section">
                <div class="section-content">
                    <div class="section-text">
                        <span class="large-text bg-clip-text text-transparent bg-gradient-to-r to-sky-500 from-sky-500"
                            style="margin-left:-120px;">
                            <strong>Recompensas</strong>
                        </span>
                        <p class="medium-text" style="margin-left:-120px;">
                            É possível obter lucros de acordo com a forma que você vende cursos. Ministre aulas
                            interessantes e que chamem atenção, aulas essas que você tem um manejo especializado e de fácil
                            compreensão.
                        </p>
                    </div>
                    <div class="section-image">
                        <v-img src="@/assets/BecomeCreator/4.png" style="margin-left:-300px"></v-img>
                    </div>
                </div>
            </section>
        </div>
        <section class="tam-dir bg-cover bg-center py-32 section-divider"
            style=" background-image: url('https://images.unsplash.com/photo-1586809797289-ae54d86fe28b?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D');">
            <div class="container mx-auto text-center text-gray-800">
                <h1 class="text-5xl font-medium mb-6 text-blue-950 bottommargin">Não perca tempo.</h1>
                <p class="text-xl mb-12 text-sky-950">Junte-se ao nosso universo de conhecimento.</p>
                <v-btn @click="beCreator" size="large" prepend-icon="mdi-check-decagram"
                    class="bg-gradient-to-r from-sky-700 to-emerald-600 text-white py-3 px-12 rounded-full hover:bg-emerald-600">
                    Tornar-se um Criador
                </v-btn>
            </div>
        </section>
    </div>
</template>

<script>
import axios from '@/../src/axios';
import { mapGetters } from 'vuex';

export default {
    name: "PageWithSections",
    computed: {
        ...mapGetters('user', ['getUserID', 'getUserName', 'getUserBecameCreator']),
    },
    methods: {
        beCreator() {
            axios.put(`/User/becameCreator?id=${this.getUserID}`, true, {
                headers: {
                    'Content-Type': 'application/json',
                },
            })
                .then(response => {
                    // Handle the successful response here
                    console.log('Data sent successfully:', response.data);
                    window.alert('Requisitado com sucesso!');
                    this.subNow = true;
                    this.show = true;
                })
                .catch(error => {
                    // Handle errors here
                    console.error('Registration not completed, please try again', error);
                });
        },
    },
}
</script>


<style scoped>
.bottommargin {
    margin-top: -50px;
}

.tam-dir {
    background-position: center;
    padding-top: -100px;
}

.margem {
    margin-top: 30px;
    margin-left: 30px;
}

.margem-dir {
    /* margin-top: 20px; */
    margin-right: 30px;
}

h1 {
    margin: 0;
}

nav {
    background-color: #48008b;
    padding: 10px;
    text-align: center;
}

nav a {
    text-decoration: none;
    color: #dffdff;
    margin: 10px;
}

.section {
    padding: 20px;
    margin: 20px;
    background-color: #ffffff;
    border: 1px solid #ddd;
    border-radius: 15px;
    height: 20%;
    max-width: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
    flex-direction: row-reverse;
}

.section-content {
    display: flex;
    justify-content: space-between;
    align-items: center;
    flex-direction: row-reverse;
}

.section-text {
    flex: 1;
}

.section-image {
    max-width: 400px;
    margin-right: 20px;
    flex: 1;
    text-align: center;
}

.large-text {
    font-size: 30px;
    margin-left: 20%;

}

.medium-text {
    font-size: 15px;
    margin-left: 20%;
}

.large-textl {
    font-size: 30px;
    text-align: left;
    margin-left: 30px;

}

.medium-textl {
    font-size: 15px;
    max-width: 70%;
    margin-left: 30px;
}
</style>