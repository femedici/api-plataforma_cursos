<template>
  <v-container fluid>
    <v-row>
      <v-col>
        <v-card>
          <h2 class="mb-4 text-3xl font-extrabold text-gray-900 dark:text-black md:text-5xl lg:text-6xl">
            <span class="text-transparent bg-clip-text bg-gradient-to-r to-emerald-600 from-sky-400">Cursos</span>
            disponiveis
            <button prepend-icon="mdi-home" type="button"
              class="inline-flex items-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"><v-icon>mdi-plus</v-icon>
              Publicar Curso
            </button>
          </h2>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
  <v-divider></v-divider>
  <v-container fluid>
    <div class="grid-cols-1 sm:grid md:grid-cols-3 ">
      <div
        class="mx-3 mt-6 flex flex-col rounded-lg bg-white shadow-[0_2px_15px_-3px_rgba(0,0,0,0.07),0_10px_20px_-2px_rgba(0,0,0,0.04)] dark:bg-neutral-700 sm:shrink-0 sm:grow sm:basis-0">
        <a href="#!">
          <img class="rounded-t-lg" src="https://tecdn.b-cdn.net/img/new/standard/city/044.webp" alt="Skyscrapers" />
        </a>
        <div class="p-6">
          <h5 class="mb-2 text-xl font-medium leading-tight text-neutral-800 dark:text-neutral-50">
            Card title
          </h5>
          <p class="mb-4 text-base text-neutral-600 dark:text-neutral-200">
            This is a wider card with supporting text below as a natural
            lead-in to additional content. This content is a little bit
            longer.
          </p>
        </div>
        <div
          class="mt-auto border-t-2 border-neutral-100 px-6 py-3 text-center dark:border-neutral-600 dark:text-neutral-50">
          <small>Last updated 3 mins ago</small>
        </div>
      </div>
      <div
        class="mx-3 mt-6 flex flex-col rounded-lg bg-white shadow-[0_2px_15px_-3px_rgba(0,0,0,0.07),0_10px_20px_-2px_rgba(0,0,0,0.04)] dark:bg-neutral-700 sm:shrink-0 sm:grow sm:basis-0">
        <a href="#!">
          <img class="rounded-t-lg" src="https://tecdn.b-cdn.net/img/new/standard/city/043.webp"
            alt="Los Angeles Skyscrapers" />
        </a>
        <div class="p-6">
          <h5 class="mb-2 text-xl font-medium leading-tight text-neutral-800 dark:text-neutral-50">
            Card title
          </h5>
          <p class="mb-4 text-base text-neutral-600 dark:text-neutral-200">
            This card has supporting text below as a natural lead-in to
            additional content.
          </p>
        </div>
        <div
          class="mt-auto border-t-2 border-neutral-100 px-6 py-3 text-center dark:border-neutral-600 dark:text-neutral-50">
          <small>Last updated 3 mins ago</small>
        </div>
      </div>
      <div
        class="mx-3 mt-6 flex flex-col rounded-lg bg-white shadow-[0_2px_15px_-3px_rgba(0,0,0,0.07),0_10px_20px_-2px_rgba(0,0,0,0.04)] dark:bg-neutral-700 sm:shrink-0 sm:grow sm:basis-0">
        <a href="#!">
          <img class="rounded-t-lg" src="https://tecdn.b-cdn.net/img/new/standard/city/042.webp"
            alt="Palm Springs Road" />
        </a>
        <div class="p-6">
          <h5 class="mb-2 text-xl font-medium leading-tight text-neutral-800 dark:text-neutral-50">
            Card title
          </h5>
          <p class="mb-4 text-base text-neutral-600 dark:text-neutral-200">
            This is a wider card with supporting text below as a natural
            lead-in to additional content. This card has even longer content
            than the first to show that equal height action.
          </p>
        </div>
        <div
          class="mt-auto border-t-2 border-neutral-100 px-6 py-3 text-center dark:border-neutral-600 dark:text-neutral-50">
          <small>Last updated 3 mins ago</small>
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

