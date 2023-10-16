<template>
    <div class="user-form">
        <div class="Title">
            Alterar tópico
        </div>
        <br><br>
        <form @submit="alterForm">
            <label for="title" class="label">Titulo do Tópico:</label>
            <input type="text" id="search-bars" v-model="formData.title" required>

            <label for="body" class="label">Conteúdo:</label>
            <input type="text" id="search-bars" v-model="formData.body" required>

            <label for="attachments" class="label">Anexos:</label>
            <input type="text" id="search-bars" v-model="formData.attachments" required>

            <button type="submit">Enviar</button>
        </form>
    </div>
</template>

<script src="./TopicsAlter.js"></script>

<style src="./style.css"></style>