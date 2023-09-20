<template>
  <div class="user-form">
    <button @click="fetchData">Buscar Dados</button>

    <div v-if="data.length > 0">
      <h2>Dados do Backend:</h2>
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
            <router-link :to="'/view-user/' + item.email" class="nav-link">VER</router-link>
          </tr>
        </tbody>
      </table>
    </div>

    <div v-if="error">
      <p>Ocorreu um erro ao buscar os dados: {{ error }}</p>
    </div>
  </div>
</template>
  
  

<script src="./UserList.js"></script>

<style src="./style.css"></style>