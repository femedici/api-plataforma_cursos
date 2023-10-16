<template>
    <div class="user-form">
        <form @submit="alterForm">
            <div class="Title">
                Alterar Curso
            </div>
            <br><br>
            <label for="title" class="label">Titulo do Curso:</label>
            <input type="text" id="search-bars" v-model="formData.title" required>

            <label for="body">Conteúdo:</label>
            <input type="text" id="search-bars" v-model="formData.body" required>

            <label for="attachments">Anexos:</label>
            <input type="text" id="search-bars" v-model="formData.attachments" required>

            <label for="password">Senha de Acesso:</label>
            <input type="text" id="search-bars" v-model="formData.password" required>

            <button type="submit">Enviar</button>
        </form>
    </div>
</template>

<script src="./CoursesAlter.js"></script>

<style src="./style.css"></style>