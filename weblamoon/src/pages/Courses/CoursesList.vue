<template>
  <v-container fluid class="bg-sky-950/60 flex flex-col">
    <div class="flex items-end justify-between">
      <span class="max-w-2xl mb-4 text-4xl font-bold tracking-tight leading-none md:text-5xl xl:text-6xl text-cyan-100">
        Cursos Disponíveis
      </span>
      <v-btn to="/becameCreator" prepend-icon="mdi-plus-circle"
        class="bg-gradient-to-r from-sky-700 to-emerald-600 text-neutral-50">
        Se tornar um criador
      </v-btn>
    </div>
    <v-card-text class="font-sans text-zinc-50 text-xl">
      <p></p><a class="underline decoration-teal-300">Explore</a> todos os cursos presentes na plataforma
      LaMoon.
    </v-card-text>
  </v-container>

  <v-divider></v-divider>

  <v-container fluid>
    <v-row class="mb-4">
      <v-col cols="12">
        <v-text-field v-model="searchTerm" label="Pesquise cursos" outlined class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"></v-text-field>
      </v-col>
    </v-row>

    <!-- Display filtered courses -->
    <div class="grid-cols-1 sm:grid md:grid-cols-3">
      <div v-for="(item, index) in filteredCourses" :key="index"
        class="mx-3 mt-6 flex shadow-2xl flex-col rounded-lg bg-transparent transform translate-y-0 transition-transform hover:translate-y-[-1rem] hover:shadow-md"
        style="height: 400px;">
        <a :href="'/view-course/' + item.id">
          <div style="height: 200px; /* Set a fixed height for the image container */">
            <img class="rounded-t-lg object-cover h-full w-full" :src="item.banner" alt="Course" />
          </div>
          <div class="p-6">
            <h4 class="mb-2 text-xl font-medium leading-tight text-emerald-300">
              {{ item.title }}
            </h4>
            <p class="mb-4 text-base text-neutral-100">
              {{ item.description }}
            </p>
          </div>
          <div
            class="mt-auto border-t-2 border-neutral-100 px-6 py-3 text-center dark:border-neutral-100 text-neutral-100">
            <p>Criado por <a class="text-emerald-300"> {{ item.creator }}</a></p>
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
      searchTerm: '',
    };
  },
  computed: {
    // Compute filtered courses based on the search term
    filteredCourses() {
      return this.data.filter(course =>
        course.title.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    },
  },
  created() {
    axios.get('/Courses')
      .then(response => {
        this.data = response.data;
        this.error = null;

        this.data.forEach(course => {
          course.banner = 'data:image;base64,' + course.banner;
        });
      })
      .catch(error => {
        this.data = [];
        this.error = error.message;
      });
  },
};
</script>

