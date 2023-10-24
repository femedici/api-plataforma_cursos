<template>
  <v-container fluid class="bg-sky-950/60 flex flex-col">
    <div class="flex items-end justify-between">
      <span
        class="max-w-2xl mb-4 text-4xl font-bold tracking-tight leading-none md:text-5xl xl:text-6xl text-cyan-100">
        Cursos Disponíveis
      </span>
      <v-btn to="/create-course" prepend-icon="mdi-plus-circle"
        class="bg-gradient-to-r from-sky-700 to-emerald-600 text-neutral-50">
        Criar curso
      </v-btn>
    </div>
    <v-card-text class="font-sans text-zinc-50 text-xl">
      <p></p><a class="underline decoration-teal-300">Explore</a> todos os cursos presentes na plataforma
      LaMoon.
    </v-card-text>
  </v-container>

  <v-divider></v-divider>

  <v-container fluid>
    <div class="grid-cols-1 sm:grid md:grid-cols-3 ">
      <div v-for="(item, index) in data" :key="index"
        class="mx-3 mt-6 flex shadow-2xl flex-col rounded-lg bg-transparent transform translate-y-0 transition-transform hover:translate-y-[-1rem] hover:shadow-md">
        <a :href="'/view-course/' + item.id">
          <img class="rounded-t-lg"
            src="https://scontent.ftow4-1.fna.fbcdn.net/v/t39.30808-6/278019551_7535454386494767_1280416841719107481_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_ohc=wsbo1RcAzIwAX-cqktj&_nc_oc=AQlWIsPE0G0udDQZaenHc3hvfsDwd9OrQrCNT2S1ceYfbCEeZvGsb3UxTvZI0pNhwkE&_nc_ht=scontent.ftow4-1.fna&cb_e2o_trans=t&oh=00_AfA-yBPXphpq7FdHTMCsWIiPUnWywgngWcF9W5gvFmf42A&oe=653C66EC"
            alt="Course" />
          =

          <div class="p-6">
            <h5 class="mb-2 text-xl font-medium leading-tight text-neutral-100">
              {{ item.title }}
            </h5>
            <p class="mb-4 text-base text-neutral-100">
              {{ item.description }}
            </p>
          </div>
          <div
            class="mt-auto border-t-2 border-neutral-100 px-6 py-3 text-center dark:border-neutral-100 text-neutral-100">
            <small>Criado por {{ item.creator }}</small>
          </div>
        </a>
      </div>
    </div>
  </v-container>
</template>

<script>
import axios from '@/../src/axios';

export default {
  data() {
    return {
      data: [],
      error: null,
    };
  },
  created() {
    axios.get('/Courses')
      .then(response => {
        this.data = response.data;
        this.error = null;
      })
      .catch(error => {
        this.data = [];
        this.error = error.message;
      });
  },
};
</script>

