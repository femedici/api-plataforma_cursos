<template>
  <v-container fluid class="bg-sky-950/60 flex flex-col">
    <div class="flex items-end">
      <v-card-title class="text-md-h6 text-lg-h3 text-zinc-50">Cursos Disponíveis</v-card-title>
    </div>
    <v-card-text class="font-sans text-zinc-50 text-xl">Explore todos os cursos presentes na plataforma
      LaMoon.</v-card-text>
    <a href="/about"
      class="ml-auto relative inline-flex items-center justify-center p-4 px-6 py-3 overflow-hidden font-medium text-indigo-600 transition duration-300 ease-out border-2 border-purple-500 rounded-full shadow-md group">
      <span
        class="absolute inset-0 flex items-center justify-center w-full h-full text-white duration-300 -translate-x-full bg-purple-500 group-hover:translate-x-0 ease">
        <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M14 5l7 7m0 0l-7 7m7-7H3"></path>
        </svg>
      </span>
      <span
        class="absolute flex items-center justify-center w-full h-full text-purple-500 transition-all duration-300 transform group-hover:translate-x-full ease">Crie seu curso</span>
      <span class="relative invisible">Crie seu curso</span>
    </a>
  </v-container>

  <v-divider></v-divider>

  <v-container fluid>
    <div class="grid-cols-1 sm:grid md:grid-cols-3 ">
      <div v-for="(item, index) in data" :key="index"
        class="mx-3 mt-6 flex shadow-2xl flex-col rounded-lg bg-transparent transform translate-y-0 transition-transform hover:translate-y-[-1rem] hover:shadow-md">
        <a :href="'/view-course/' + item.id">
          <img class="rounded-t-lg"
            src="https://cdn.elearningindustry.com/wp-content/uploads/2020/08/5-ways-to-improve-your-course-cover-design-1024x575.png"
            alt="Course" />
          =
        </a>
        <div class="p-6">
          <h5 class="mb-2 text-xl font-medium leading-tight text-neutral-100">
            {{ item.title }}
          </h5>
          <p class="mb-4 text-base text-neutral-100">
            {{ item.description }}
          </p>
        </div>
        <div class="mt-auto border-t-2 border-neutral-100 px-6 py-3 text-center dark:border-neutral-100 text-neutral-100">
          <small>Criado por {{ item.creator }}</small>
        </div>
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

