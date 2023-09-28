<template>
    <v-app-bar title="La Moon" class="bg-grey-darken-4">
      <v-navigation :value="value" active>
        <v-btn to="/" @click="navigateTo('/')" class="ml-2">Home</v-btn>
        <v-btn to="/about" @click="navigateTo('/about')" class="ml-2">Sobre</v-btn>
        <v-btn to="/list-courses" @click="navigateTo('/list-courses')" class="ml-2 mr-6">Cursos</v-btn>
      </v-navigation>
    </v-app-bar>
  </template>
  
  
<script>
export default {
    data() {
        return {
            value: null,
        };
    },
    methods: {
        navigateTo(route) {
            this.$router.push(route);
        },
    },
};
</script>
  