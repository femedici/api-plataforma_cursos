<template>
  <div class="background p-8 rounded-md w-full ">
    <div class="flex items-center justify-between pb-6">
      <div class="mx-auto">
        <div class="-mx-4 sm:-mx-8 px-4 sm:px-8 py-4 overflow-x-auto">
          <div class="inline-block min-w-full shadow rounded-lg overflow-hidden">
            <table class="max-w-full leading-normal w-full">
              <thead>
                <tr>
                  <th
                    class="px-16 py-3 border-b-1 border-gray-500 bg-gray-700 text-left text-xs font-semibold text-gray-200 uppercase tracking-wider">
                    Nome
                  </th>
                  <th
                    class="px-5 py-3 border-b-1 border-gray-500 bg-gray-700 text-left text-xs font-semibold text-gray-200 uppercase tracking-wider">
                    Email
                  </th>
                  <th
                    class="px-20 py-3 border-b-1 border-gray-500 bg-gray-700 text-left text-xs font-semibold text-gray-200 uppercase tracking-wider">
                    Criador
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in data" :key="index">
                  <td class="px-5 py-5 border-b border-gray-200 bg-gray-800 text-sm">
                    <div class="flex items-center">
                      <div class="flex-shrink-0 w-10 h-10">
                        <img class="user-image" :src="currentProfileImageUrl" alt="Foto de Perfil">
                      </div>
                      <div class="ml-3">
                        <p class="text-gray-400 whitespace-no-wrap">
                          {{ item.name }}
                        </p>
                      </div>
                    </div>
                  </td>
                  <td class="w-full px-5 py-5 border-b border-gray-200 bg-gray-800 text-sm">
                    <p class="text-gray-400 whitespace-no-wrap">{{ item.email }}</p>
                  </td>
                  <td class="w-full px-5 py-5 border-b border-gray-200 bg-gray-800 text-gray-400 text-sm">
                    <v-switch v-model="model" hide-details true-value="Criador" false-value="Não Criador"
                      :label="`${model}`"></v-switch>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
  
  

<script>
import axios from '@/../src/axios';

export default {
  data() {
    return {
      data: [],
      error: null,
      currentProfileImageUrl: 'https://static.vecteezy.com/system/resources/previews/020/911/739/non_2x/user-profile-icon-profile-avatar-user-icon-male-icon-face-icon-profile-icon-free-png.png',
      model: 'Não Criador'
    };
  },
  created() {
    axios.get('/User')
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

<style scoped>
.background {
  background-color: #132b46;
  height: 300%;
}
</style>