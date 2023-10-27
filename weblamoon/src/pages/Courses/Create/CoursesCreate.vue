<template>
  <v-container fluid class="flex flex-col">
    <div class="flex items-end justify-between">
      <span class="max-w-2xl mb-4 text-4xl font-bold tracking-tight leading-none md:text-5xl xl:text-4xl text-cyan-100">
        Publique seu curso
      </span>
    </div>
    <v-divider></v-divider>
  </v-container>

  <div class="ml-20 mr-20 mt-5 mb-8 bg-slate-300 border-solid border-2 rounded-md">
    <div class="ml-20 mr-20 mt-5">

      <h2 class="text-2xl font-bold tracking-tight text-gray-800 text-center m:text-3xl">Primeiro, preencha as informações
        abaixo:
      </h2>
      <br>
      <form @submit="submitCourse">
        <div class="space-y-12">
          <div class="border-b border-white-900/10 pb-12">
            <div class="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 m:grid-cols-6">
              <div class="m:col-span-4">
                <label for="username" class="block text-m font-medium leading-6 text-white-900">Titulo</label>
                <div class="mt-2">
                  <div
                    class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                    <input type="text" name="username" id="username" autocomplete="username"
                      class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                      placeholder="Como se tornar um ganhador!">
                  </div>
                </div>
              </div>

              <div class="m:col-span-4">
                <label for="username" class="block text-m font-medium leading-6 text-white-900">Breve Descrição</label>
                <div class="mt-2">
                  <div
                    class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                    <input type="text" name="username" id="username" autocomplete="username"
                      class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                      placeholder="Curso de ...">
                  </div>
                </div>
              </div>

              <div class="col-span-full">
                <label for="about" class="block text-m font-medium leading-6 text-white-900">Sobre o curso</label>
                <p class="mt-3 text-sm leading-6 text-white-600">Descreva um pouco sobre oque vai ser trabalhado no
                  decorrer do curso. Ideias, teorias, conhecimentos, etc.</p>
                <div class="mt-2">
                  <textarea id="about" name="about" rows="3"
                    class="block w-full rounded-md border-0 py-1.5 text-white-900 shadow-sm ring-1 ring-inset ring-white-300 placeholder:text-white-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 m:text-sm m:leading-6"></textarea>
                </div>
              </div>
            </div>
          </div>

          <div>
            <label for="photo" class="block text-m font-medium leading-6 text-white-900 mb-2">Imagem de Capa do
              Curso</label>
            <label class="block">
              <span class="sr-only">Choose profile photo</span>
              <input type="file" class="block w-full text-sm text-slate-500
              file:mr-4 file:py-2 file:px-4
              file:rounded-full file:border-0
              file:text-sm file:font-semibold
              file:bg-violet-50 file:text-cyan-700
              hover:file:bg-violet-100" />
            </label>
            <br>
            <label for="photo" class="block text-m font-medium leading-6 text-white-900 mb-2">Icone</label>
            <label class="block">
              <span class="sr-only">Choose profile photo</span>
              <input type="file" class="block w-full text-sm text-slate-500
              file:mr-4 file:py-2 file:px-4
              file:rounded-full file:border-0
              file:text-sm file:font-semibold
              file:bg-violet-50 file:text-cyan-700
              hover:file:bg-violet-100" />
            </label>
          </div>

          <div>
            <div class="m:col-span-4">
              <label for="username" class="block text-m font-medium leading-6 text-white-900">Adicione a URL do Vídeo de
                Apresentação do curso</label>
              <div class="mt-2">
                <div
                  class="flex rounded-md shadow-m ring-1 ring-inset ring-white-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 m:max-w-md">
                  <input type="text" name="username" id="username" autocomplete="username"
                    class="block flex-1 border-0 bg-transparent py-1.5 pl-1 text-white-900 placeholder:text-white-400 focus:ring-0 m:text-m m:leading-6"
                    placeholder="drive.com/">
                </div>
              </div>
            </div>
          </div>
        </div>
      </form>
      <div class="mt-6 mb-4 flex items-center justify-end gap-x-6">
        <button class="text-m font-semibold leading-6 text-white-900">Limpar</button>
        <button type=""
          class="rounded-md bg-teal-400 px-3 py-2 text-m font-semibold text-white shadow-m hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Próximo
          Passo</button>
      </div>

    </div>
    <!-- <div class="title">
        Crie seu curso
      </div>
  
      <form @submit="submitForm">
        <label for="id" class="labels">Código de identificação (3 números):</label>
        <input type="text" class="input-field" v-model="formData.id" required>
  
        <label for="title" class="labels">Título do Curso:</label>
        <input type="text" class="input-field" v-model="formData.title" required>
  
        <label for="body" class="labels">Conteúdo:</label>
        <input type="text" class="input-field" v-model="formData.body" required>
  
        <label for="attachments" class="labels">Anexos:</label>
        <input type="text" class="input-field" v-model="formData.attachments" required>
  
        <label for="password" class="labels">Senha de Acesso:</label>
        <input type="text" class="input-field" v-model="formData.password" required>
  
        <div class="button-container">
          <button type="submit" class="submit-button">Enviar</button>
        </div>
      </form> -->
  </div>
</template>

<script>
export default {
  data() {
    return {
      step: 1, // Initial step
      formData: {
        // Initialize your form data here
      },
    };
  },
  methods: {
    nextStep() {
      if (this.step < 4) {
        this.step++;
      }
    },
    previousStep() {
      if (this.step > 1) {
        this.step--;
      }
    },
    submitForm() {
      // Handle form submission here
      // Access form data using this.formData
    },
  },
};
</script>