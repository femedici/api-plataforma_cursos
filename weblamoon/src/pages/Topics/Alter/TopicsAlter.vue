<template>
    <div>
        <form @submit="alterForm">
            <label for="title">Titulo do Tópico:</label>
            <input type="text" id="title" v-model="formData.title" required>

            <label for="body">Conteúdo:</label>
            <input type="text" id="text" v-model="formData.body" required>

            <label for="attachments">Anexos:</label>
            <input type="text" id="text" v-model="formData.attachments" required>

            <button type="submit">Enviar</button>

            <div v-if="error === false">
                <p>Sucesso ao alterar tópico</p>
            </div>
            <div v-if="error">
                <p>Ocorreu um erro ao alterar: {{ error }}</p>
            </div>
        </form>
    </div>
</template>

<script src="./TopicsAlter.js"></script>

<style src="./style.css"></style>