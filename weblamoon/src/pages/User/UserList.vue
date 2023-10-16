<template>
  <div class="user-form">
    <div v-if="data.length > 0">
      <h2>Usuários Cadastrados:</h2>
      <table>
        <thead>
          <tr>
            <th>Nome</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in data" :key="index">
            <td>{{ item.name }}</td>
            <td>{{ item.email }}</td>
            <br>
            <td></td>
            <router-link :to="'/view-user/' + item.email" class="button1">Ver Perfil</router-link>
            <br><br>
          </tr>
        </tbody>
      </table>
    </div>

    <div v-if="error">
      <p>Ocorreu um erro ao buscar os dados: {{ error }}</p>
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

