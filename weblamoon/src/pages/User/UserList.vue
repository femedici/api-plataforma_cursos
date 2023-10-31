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
                <tr v-for="(item, index) in filteredData" :key="index">
                  <td class=" text-center border-gray-200 bg-gray-800 text-sm">
                    <p class="text-gray-400 whitespace-no-wrap">{{ item.name }}</p>
                  </td>
                  <td class=" text-center border-b border-gray-200 bg-gray-800 text-sm">
                    <p class="text-gray-400 whitespace-no-wrap">{{ item.email }}</p>
                  </td>
                  <td class="w-full px-5 py-5 border-b border-gray-200 bg-gray-800 text-gray-400 text-sm">
                    <v-radio-group v-model="item.creator" row>
                      <v-radio label="Criador" :value="true" @change="updateUserCreatorStatus(item, true)"></v-radio>
                      <v-radio label="Não Criador" :value="false" @change="updateUserCreatorStatus(item, false)"></v-radio>
                    </v-radio-group>
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
      switch1: true,
      currentProfileImageUrl: 'https://static.vecteezy.com/system/resources/previews/020/911/739/non_2x/user-profile-icon-profile-avatar-user-icon-male-icon-face-icon-profile-icon-free-png.png',
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
  computed: {
    filteredData() {
      return this.data.filter(item => item.becameCreator === true);
    },
  },
  methods: {
    updateUserCreatorStatus(user, newValue) {
      axios.put(`/User/admin-users?id=${user.id}`, newValue, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
        .then(response => {
          // Handle the successful response here
          console.log('Data sent successfully:', response.data);
          window.alert('User status updated successfully!');
          this.subNow = true;
          this.show = true;
        })
        .catch(error => {
          // Handle errors here
          console.error('Update not completed, please try again', error);
        });
    },
  },
};
</script>
 
<style scoped>
.background {
  background-color: #153151;
  height: 300%;
}
</style>