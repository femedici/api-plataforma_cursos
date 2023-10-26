<template>
    <div class="bg-white">
        <section class="bg-gray-900 lg:pt-[120px] pb-10 lg:pb-20"
            style="background-color:white; background-image: url('https://img.freepik.com/vetores-gratis/ilustracao-do-conceito-de-formula_114360-8367.jpg?w=826&t=st=1698271990~exp=1698272590~hmac=d846b4602f1a22ece92a6c4e1dc47b2f83f591732fb25ec8dfba83c0b7cb099d'); background-size:50%; background-position: right;">
            <div class="grid max-w-screen-xl px-4 py-8 mx-auto lg:gap-8 xl:gap-0 lg:py-16 lg:grid-cols-12">
                <div class="mr-auto place-self-center lg:col-span-7">
                    <h1
                        class="max-w-2xl mb-4 text-4xl font-extrabold tracking-tight leading-none md:text-5xl xl:text-6xl dark:text-black ">
                        Tornar-se um Criador!</h1>
                    <br>
                    <p class="max-w-2xl mb-6 font-light text-black-100 lg:mb-8 md:text-lg lg:text-xl dark:text-black">Aqui
                        te
                        mostraremos o que significa ser um Criador LaMoon, no que isso te ajuda e no impacto que isso traz
                        ao
                        seu negócio.</p>
                    <br>
                    <p class="max-w-2xl mb-6 font-light text-black-100 lg:mb-8 md:text-lg lg:text-xl dark:text-black">
                        Continue
                        scrollando e se torne um Criador.</p>
                    <br><br>
                    <path fill-rule="evenodd"
                        d="M10.293 3.293a1 1 0 011.414 0l6 6a1 1 0 010 1.414l-6 6a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-4.293-4.293a1 1 0 010-1.414z"
                        clip-rule="evenodd"></path>
                    <br><br><br><br>
                </div>
            </div>
        </section>
        <div>
            <section id="section1" class="section">
                <div class="section-content">
                    <div class="section-text">
                        <h2 class="large-text">Demonstração de conhecimentos!</h2>
                        <p class="medium-text">
                            Ao se tornar um Criador LaMoon, você não só está repassando diversas experiencias
                            que alavancam a carreira de outras pessoas, como também está contribuindo para o seu
                            auto-reconhecimento, permitindo que diversos profissionais e chefes de empresas se interessem
                            nos seus conhecimentos e experiencias.
                        </p>
                    </div>
                    <div class="section-image">
                        <img src="https://img.freepik.com/vetores-gratis/ilustracao-do-conceito-de-qualidade-do-produto_114360-7301.jpg?w=826&t=st=1698295802~exp=1698296402~hmac=7abb8f6c0f84e1d12b111d9541e9f5f384e0154df49899c6fef951ba46d08fbd"
                            alt="Imagem 1">
                    </div>
                </div>
            </section>
            <section id="section2" class="section">
                <div class="section-content">
                    <div class="section-image">
                        <img src="https://img.freepik.com/vetores-gratis/ilustracao-do-conceito-de-webinar_114360-4764.jpg?w=1380&t=st=1698296266~exp=1698296866~hmac=b10cea87438da7010970106f7445f3e38325271d48f2a51c572b890e3f6c201b"
                            alt="Imagem 2">
                    </div>
                    <div class="section-text">
                        <h2 class="large-text">Ótimo para o seu negócio.</h2>
                        <p>
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
                        <h2 class="large-text">Recompensas</h2>
                        <p>
                            É possível obter lucros de acordo com a forma que você vende cursos. Ministre aulas
                            interessantes e que chamem atenção, aulas essas que você tem um manejo especializado e de fácil
                            compreensão.
                        </p>
                    </div>
                    <div class="section-image">
                        <img src="https://img.freepik.com/vetores-gratis/poupar-dinheiro-conceito-fundo_23-2148146453.jpg?w=826&t=st=1698296505~exp=1698297105~hmac=e060b428a028b791d2906c09df9736b5d4eceb37168abdd7c6954b1d47ee216f"
                            alt="Imagem 3">
                    </div>
                </div>
            </section>
        </div>
        <section class="tam-dir bg-cover bg-center py-32"
            style="background-image: url('https://img.freepik.com/vetores-gratis/design-de-banner-ondulado-de-luz-neon_1017-32706.jpg?w=1380&t=st=1698305118~exp=1698305718~hmac=d9a0f6e6585e0c79ea8ee76dd7eceb67d780277d254469e6fb95ba0a2ddc704e');">
            <div class="container mx-auto text-center text-white">
                <h1 class="text-5xl font-medium mb-6 text-black bottommargin">Não perca tempo.</h1>
                <p class="text-xl mb-12 text-black">Junte-se ao nosso universo de conhecimento.</p>
                <v-btn @click="beCreator" size="large" prepend-icon="mdi-check-decagram"
                    class="bg-indigo-500 text-white py-4 px-12 rounded-full hover:bg-indigo-600" :disabled="show">
                    Tornar-se um
                    Criador
                </v-btn>
            </div>
        </section>
    </div>
</template>
<script>
import axios from '@/../src/axios';
import { mapGetters } from 'vuex';
//Falta adequar o script pra criador
export default {
    name: "PageWithSections",
    computed: {
        ...mapGetters('user', ['getUserID', 'getUserName']), // Mapeando os getters do módulo 'user'
    },
    methods: {
        beCreator() {
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
}
</script>
<style scoped>
.bottommargin {
    margin-top: -50px;
}

.tam-dir {
    flex: 1;
    background-position: center;
    text-align: right;
    align-self: flex;
    max-width: 100%;
    max-height: 14%;
}

.margem {
    margin-top: 30px;
    margin-left: 30px;
}

.margem-dir {
    /* margin-top: 20px; */
    margin-right: 30px;
}

header {
    background-color: #333;
    color: #fff;
    padding: 20px;
    text-align: center;
}

h1 {
    margin: 0;
}

nav {
    background-color: #444;
    padding: 10px;
    text-align: center;
}

nav a {
    text-decoration: none;
    color: #fff;
    margin: 10px;
}

.section {
    padding: 20px;
    margin: 20px;
    background-color: #f9f9f9;
    border: 1px solid #ddd;
    border-radius: 5px;
    height: 25%;
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
    font-size: 20px;
}

footer {
    background-color: #333;
    color: #fff;
    text-align: center;
    padding: 10px;
}
</style>