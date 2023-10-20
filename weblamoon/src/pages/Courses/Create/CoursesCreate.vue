<template>
    <div class="course-form">
      <div class="title">
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
      </form>
    </div>
  </template>
  
  
<script src="./CoursesCreate.js"></script>

<style scoped src="./style.css"></style>