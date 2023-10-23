<template>
  <section class="bg-gray-900 lg:pt-[120px] pb-10 lg:pb-20"
    style="background-image: url('https://images.unsplash.com/photo-1423784346385-c1d4dac9893a?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'); background-size: cover; background-position: center;">
    <div class="grid max-w-screen-xl px-4 py-8 mx-auto lg:gap-8 xl:gap-0 lg:py-16 lg:grid-cols-12">
      <div class="mr-auto place-self-center lg:col-span-7">
        <h1
          class="max-w-2xl mb-4 text-4xl font-extrabold tracking-tight leading-none md:text-5xl xl:text-6xl dark:text-white">
          Bem vindo a La Moon</h1>
        <br>
        <p class="max-w-2xl mb-6 font-light text-gray-500 lg:mb-8 md:text-lg lg:text-xl dark:text-gray-400">Welcome to
          [Company Name], your gateway to unforgettable travel experiences. We are a leading travel and tour company
          dedicated to creating exceptional journeys for adventurers, explorers, and wanderers like you.</p>
        <br><br><br><br><br><br>
        <a href="/list-courses"
          class="inline-flex items-center justify-center px-5 py-3 text-base font-medium text-center text-gray-900 border border-gray-300 rounded-lg hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 dark:text-white dark:border-gray-700 dark:hover:bg-gray-700 dark:focus:ring-gray-800">
          Cursos Disponíveis
          <svg class="w-5 h-5 ml-2 -mr-1" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
            <path fill-rule="evenodd"
              d="M10.293 3.293a1 1 0 011.414 0l6 6a1 1 0 010 1.414l-6 6a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-4.293-4.293a1 1 0 010-1.414z"
              clip-rule="evenodd"></path>
          </svg>
        </a>
        <a href="/create-user"
          class="inline-flex items-center justify-center px-5 py-3 text-base font-medium text-center text-gray-900 border border-gray-300 rounded-lg hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 dark:text-white dark:border-gray-700 dark:hover:bg-gray-700 dark:focus:ring-gray-800">
          Criar Conta
        </a>
      </div>
    </div>
  </section>
  <section class="pt-20 lg:pt-[120px] pb-10 lg:pb-20 bg-slate-200">
    <div class="container">
      <div class="flex flex-wrap justify-center -mx-4">
        <div class="w-full px-4">
          <div class="text-center mx-auto mb-[60px] lg:mb-20 max-w-[510px]">
            <h2 class="
                font-bold
                text-3xl
                sm:text-4xl
                md:text-[40px]
                text-dark
                mb-4
                ">
              Our Recent News
            </h2>
            <p class="text-base text-body-color">
              There are many variations of passages of Lorem Ipsum available
              but the majority have suffered alteration in some form.
            </p>
            <br>
            <br>
          </div>
        </div>
      </div>
      <div class="flex flex-wrap justify-center -mx-4">
        <div class="flex flex-wrap -mx-4">
          <div class="w-full md:w-1/2 lg:w-1/3 px-4 hover:translate-y-[-0.3rem] hover:shadow-md"
            v-for="course in courseCards" :key="course.id">
            <a :href="course.link">
              <div class="max-w-[370px] mx-auto mb-10 flex flex-col items-center">
                <div class="rounded overflow-hidden mb-8">
                  <img :src="course.image" :alt="course.title" class="w-full" />
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
                    {{ course.title }}
                  </h3>
                  <p class="text-base text-body-color">
                    {{ course.description }}
                  </p>
                </div>
              </div>
            </a>
          </div>
        </div>
      </div>
      <br><br>
      <div class="flex flex-wrap justify-center -mx-4">
        <div class="w-full px-4">
          <div class="text-center mx-auto mb-[60px] lg:mb-20 max-w-[510px]">
            <a href="#" class="no-underline hover:underline justify-center">
              <h2 class="
                text-2xl
                sm:text-2xl
                md:text-[40px]
                text-dark
                mb-4
                ">
                Quero publicar um curso!
              </h2>
            </a>
            <br>
            <br>
          </div>
        </div>
      </div>
    </div>
  </section>
  <section class="bg-cover bg-center py-32 w-full">
    <div class="container mx-auto text-left text-white">
      <div class="flex items-center">
        <div class="">
          <div data-aos="fade-down">
            <h1 class="text-5xl font-medium mb-6 text-neutral-50">Sobre Nós</h1>
            <p class="text-xl mb-12 text-white break-all">Nossa plataforma vai permitir que você compre cursos sobre os
              tópicos que mais lhe interessam.
              Mas a melhor parte é que, se você é um especialista ou tem conhecimento valioso a compartilhar, você pode
              criar seu próprio curso e vendê-lo.
              É uma oportunidade única para todos, sejam alunos ávidos ou futuros instrutores. Mas claro, todos os cursos
              são verificados antes de aprovados,
              além dos usuarios avaliarem a qualidade dos mesmos.
              Estamos desenvolvendo essa plataforma como parte de nosso projeto para a matéria de Projeto Integrador da
              UTFPR-CM no segundo semestre de 2023.</p>
            <p class="text-xl mb-12 text-white break-all text-left">Nossa missão é capacitar indivíduos através da
              educação, tornando o conhecimento e as habilidades acessíveis a todos.
              Acreditamos que a educação é a chave para desbloquear oportunidades ilimitadas e estamos comprometidos em
              tornar a
              aprendizagem online eficaz e envolvente.</p>
          </div>
        </div>
      </div>
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
      courseCards: [
        {
          title: "Curso",
          description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          image: "https://images.pexels.com/photos/374897/pexels-photo-374897.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
          link: "/view-course/11750"
        },
        {
          title: "How to earn more money as a wellness coach",
          description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          image: "https://images.pexels.com/photos/4974920/pexels-photo-4974920.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
          link: "/view-course/77238"
        },
        {
          title: "The no-fuss guide to upselling and cross selling",
          description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          image: "https://images.pexels.com/photos/3747156/pexels-photo-3747156.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
          link: "/view-course/50938"
        }
      ]
    };
  },
  mounted() {
    this.$AOS.init(); // Initialize AOS for this component
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