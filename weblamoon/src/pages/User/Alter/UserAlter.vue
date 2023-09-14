<template>
  <div>
      <form @submit="alterForm">
          <label for="nome">Cpf:</label>
          <input type="text" id="cpf" v-model="formData.cpf" required>

          <label for="nome">Nome:</label>
          <input type="text" id="nome" v-model="formData.name" required>

          <label for="email">Email:</label>
          <input type="email" id="email" v-model="formData.email" required>

          <label for="password">Senha:</label>
          <input type="text" id="password" v-model="formData.password" required>

          <button type="submit">Enviar</button>

          <div v-if="error === false">
              <p>Sucesso ao atualizar usuário</p>
          </div>
          <div v-if="error">
              <p>Ocorreu um erro ao buscar os dados: {{ error }}</p>
          </div>
      </form>
  </div>
</template>

<script src="./UserAlter.js"></script>

<style src="./style.css"></style>