<template>
  <section class="min-h-screen flex items-stretch text-white">
    <div class="lg:flex w-1/2 hidden bg-gray-500 bg-no-repeat bg-cover relative items-center"
      style="background-image: url(https://images.unsplash.com/photo-1522071820081-009f0129c71c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80);">
      <div class="absolute bg-black opacity-60 inset-0 z-0"></div>
      <div class="w-full px-24 z-10">
        <h1 class="text-5xl font-bold text-left tracking-wide font-sans">Se Cadastre</h1>
        <p class="text-2xl my-4 font-sans">Se junte à comunidade de alunos, criadores e aprendizagem do LaMoon!</p>
      </div>
    </div>
    <div
      class="lg:w-1/2 w-full flex items-center justify-center text-center md:px-16 px-0 z-0 bg-gradient-to-r from-[#6591cb]">
      <div class="w-full py-6 z-20">
        <h1 class="flex justify-center items-center">
          <v-img src="@/assets/newlogo.png" class="object-cover h-48 w-96"></v-img>
        </h1>
        <v-card class="mx-auto pa-12 pb-8" elevation="8" max-width="448" rounded="lg">
          <form @submit.prevent="submitForm()">

            <v-text-field label="Nome" v-model="formData.name"></v-text-field>
            <v-text-field label="Email" v-model="formData.email" type="email" required></v-text-field>
            <v-text-field label="Senha" v-model="formData.password" type="password" required></v-text-field>

            <v-btn type="submit" block class="mt-2">Cadastrar</v-btn>
          </form>
        </v-card>
        <div class="fixed top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2">
          <UserAlert ref="userAlert" />
        </div>
      </div>
    </div>
  </section>
</template>


<script>
import axios from '@/../src/axios';
import UserAlert from '@/components/UserCreateAlert.vue'

export default {
  components: {
    UserAlert, // Add the component to the components section
  },
  data() {
    return {
      formData: {
        name: '',
        email: '',
        password: '',
      },
      error: null,
    };
  },

  methods: {
    submitForm() {
      console.log('Form data:', this.formData);

      axios.post('/User', this.formData, {
        headers: {
          'Content-Type': 'application/json', // Set the content type to JSON
        },
      })
        .then(response => {
          console.log('Data sent successfully:', response.data);
          // Clear the form after sending
          this.formData.name = '';
          this.formData.email = '';
          this.formData.password = '';
          this.error = false;

          this.$refs.userAlert.openWarning('Success! ' + this.formData.name);
        })
        .catch(error => {
          console.error('Registration not completed, please try again', error);
          // Handle the error appropriately
        });
    },
  },
};
</script>

