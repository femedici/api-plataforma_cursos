<template>
  <section class="bg-gray-900 lg:pt-[120px] pb-10 lg:pb-20"
    style="background-image: url('https://images.unsplash.com/photo-1690046793092-f8d634523264?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'); background-size: cover; background-position: center;">
    <div class="grid max-w-screen-xl px-4 py-8 mx-auto lg:gap-8 xl:gap-0 lg:py-16 lg:grid-cols-12">
      <div class="mr-auto place-self-center lg:col-span-7">
        <h1
          class="max-w-2xl mb-4 text-4xl font-extrabold tracking-tight leading-none md:text-5xl xl:text-6xl dark:text-white">
          Bem vindo a La Moon</h1>
        <br>
        <p class="max-w-2xl mb-6 font-light text-teal-100 lg:mb-8 md:text-lg lg:text-xl">Bem-vindo ao nosso universo de
          aprendizagem! Aqui, você encontrará a porta de entrada para uma jornada de conhecimento e crescimento.
          Navegue pelos nossos cursos abrangentes e inspiradores, projetados para moldar o seu futuro e aprimorar as suas
          habilidades.
          Seja qual for o seu objetivo, estamos prontos para ajudá-lo a trilhar o caminho do sucesso. Junte-se a nós e
          comece a sua jornada de aprendizado hoje!</p>
        <br>
        <p class="max-w-2xl mb-6 font-light text-teal-100 lg:mb-8 md:text-lg lg:text-xl">Para começar crie sua conta.</p>
        <br><br>
        <a href="/create-user"
          class="inline-flex items-center  justify-center px-5 py-3 text-base font-medium text-center text-white border border-gray-300 rounded-lg hover:bg-teal-400 focus:ring-4 focus:ring-gray-100">
          Criar Conta
          <svg class="w-5 h-5 ml-2 -mr-1" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
            <path fill-rule="evenodd"
              d="M10.293 3.293a1 1 0 011.414 0l6 6a1 1 0 010 1.414l-6 6a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-4.293-4.293a1 1 0 010-1.414z"
              clip-rule="evenodd"></path>
          </svg>
        </a>
        <br><br><br><br>
      </div>
    </div>
  </section>
  <section class="pt-20 lg:pt-[120px] pb-10 lg:pb-20 bg-slate-200">
    <div class="container mx-auto">
      <div class="flex flex-wrap justify-center -mx-4">
        <div class="w-full px-4">
          <div class="text-center mx-auto mb-[60px] lg:mb-20 max-w-[610px]">
            <div class="text-5xl font-extrabold ...">
              <span class="bg-clip-text text-transparent bg-gradient-to-r from-sky-900 to-emerald-300">
                Explore a Plataforma
              </span>
            </div>
            <br>
            <p class="text-cyan-900 text-xl text-body-color">
              Existem inúmeras formas de interagir com a La Moon. Veja alguns exemplos
            </p>
            <br>
            <br>
          </div>
        </div>
      </div>
      <div class="flex flex-wrap justify-center -mx-4">
        <div class="flex flex-wrap -mx-4" data-aos="fade-up">
          <div class="w-full md:w-1/2 lg:w-1/3 px-4 hover:translate-y-[-0.3rem] hover:shadow-md" v-for="item in Cards"
            :key="item.id">
            <a :href="item.link">
              <div class="max-w-[370px] mx-auto mb-10 flex flex-col items-center">
                <div class="rounded overflow-hidden mb-8">
                  <img :src="item.image" :alt="item.title" class="w-full" />
                </div>
                <div>
                  <h3 class="font-semibold
                                    text-xl
                                    sm:text-2xl
                                    lg:text-xl
                                    xl:text-2xl
                                    mb-4
                                    inline-block
                                    text-dark
                                    hover:text-primary">
                    {{ item.title }}
                  </h3>
                  <p class="text-base text-body-color">
                    {{ item.description }}
                  </p>
                </div>
              </div>
            </a>
          </div>
        </div>
      </div>
      <br><br>
    </div>
  </section>
  <v-divider></v-divider>
  <section>
    <div class="github-users" data-aos="fade-left">
      <h2 class="text-2xl sm:text-4xl file:md:text-[40px]">Equipe La Moon</h2>
      <div class="github-user" v-for="(user, userIndex) in Users" :key="userIndex">
        <img :src="user.image">
        <div class="user-details">
          <a :href="`https://github.com/${user.githubUsername}`" target="_blank"><img
              src="https://cdn-icons-png.flaticon.com/512/25/25231.png" /></a>
          <p>{{ user.name }}</p>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: "App",
  data() {
    return {
      Users: [
        {
          name: "Felipe Augusto Medici",
          image: "https://avatars.githubusercontent.com/u/111476568?v=4",
          githubUsername: "femedici",
        },
        {
          name: "Felipe Roskosz Moran",
          image: "https://avatars.githubusercontent.com/u/105233020?v=4",
          githubUsername: "feliperm17",
        },
        {
          name: "Felipe Martins Sanches",
          image: "https://avatars.githubusercontent.com/u/79864909?s=400&u=0bd727ea4080ae444b74f08fac8cad2d17912821&v=4",
          githubUsername: "mattokgit44",
        },
        {
          name: "Caio Ducati Castilho",
          image: "https://avatars.githubusercontent.com/u/101857288?v=4",
          githubUsername: "Cast43",
        },
      ],
      Cards: [
        {
          title: "Cursos Diversos",
          description: " Este é o ponto de partida para personalizar sua nova jornada de aprendizado. Explore todos os cursos disponíveis no sistema",
          image: "https://images.pexels.com/photos/374897/pexels-photo-374897.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
          link: "/list-courses"
        },
        {
          title: "Torne-se um criador na LaMoon",
          description: "Acha que seu conhecimento tem valor e pode ser agregado a mais pessoas? Veja mais como publicar um curso no La Moon",
          image: "https://images.pexels.com/photos/4974920/pexels-photo-4974920.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
          link: "/becameCreator"
        },
        {
          title: "Seu espaço de aprendizagem",
          description: "Todos seus cursos inscritos e seu progresso particular em cada um deles em um só espaço.",
          image: "https://images.pexels.com/photos/3747156/pexels-photo-3747156.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
          link: "/coursesSub"
        }
      ]
    };
  },
  mounted() {
    this.$AOS.init(); // Initialize AOS for this component
  },
  computed: {
    ...mapGetters('user', ['getUserID']), // Mapeando os getters do módulo 'user'
  },
};
</script>

<style scoped>
.github-users {
  display: flex;
  justify-content: space-around;
  margin-top: 20px;
  color: #fff;
}

.github-user {
  text-align: center;
  margin-bottom: 30px;
  margin-top: 20px;
  color: #fff;
}

.github-user img {
  width: 100px;
  height: 100px;
  border-radius: 50%;
}

.user-details img {
  width: 24px;
  height: 24px;
}

.user-details p {
  margin-top: 10px;
}
</style>