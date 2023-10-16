<template>
    <div class="user-form">
        <form @submit="submitForm">
            <div class="Title">
                Crie o tópico
            </div>
            <br><br>
            <label for="title" class="label">Titulo do Tópico:</label>
            <input type="text" id="search-bars" v-model="formData.title" required>

            <label for="id" class="label">Código de identificação (2 Numeros)</label>
            <input type="text" id="search-bars" v-model="formData.id" required>

            <label for="body" class="label">Conteúdo:</label>
            <input type="text" id="search-bars" v-model="formData.body" required>

            <label for="attachments" class="label">Anexos:</label>
            <input type="text" id="search-bars" v-model="formData.attachments" required>

            <button type="submit" class="centralize">Enviar</button>
        </form>
    </div>
</template>
  
<script src="./TopicsCreate.js"></script>

<style src="./TopicCreate.css"></style>