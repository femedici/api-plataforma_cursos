<template>
  <v-container fluid>
    <v-card-title class="text-h6 text-md-h5 text-lg-h4 text-zinc-50">Cursos Disponiveis</v-card-title>
    <v-card-text class="font-sans text-zinc-50 text-xl">Explore todos os cursos presentes na plataforma LaMoon</v-card-text>
  </v-container>
  <v-divider></v-divider> 
  <v-container fluid>
    <div class="grid-cols-1 sm:grid md:grid-cols-3 ">
      <div v-for="(item, index) in data" :key="index"  class="mx-3 mt-6 flex flex-col rounded-lg bg-transparent shadow-[0_2px_15px_-3px_rgba(0,0,0,0.07),0_10px_20px_-2px_rgba(0,0,0,0.04)] dark:bg-neutral-100 sm:shrink-0 sm:grow sm:basis-0"> 
        <!-- href nao funcioando, alterar para funcionar -->
        <a href="'/view-course/'+ item.id">
          <img class="rounded-t-lg" src="https://cdn.elearningindustry.com/wp-content/uploads/2020/08/5-ways-to-improve-your-course-cover-design-1024x575.png" alt="Skyscrapers" />
        </a>
        <div class="p-6">
          <h5 class="mb-2 text-xl font-medium leading-tight text-neutral-100">
            {{ item.title }}
          </h5>
          <p class="mb-4 text-base text-neutral-100">
            {{item.description}}
          </p>
        </div>
        <div
          class="mt-auto border-t-2 border-neutral-100 px-6 py-3 text-center dark:border-neutral-100 text-neutral-100">
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

