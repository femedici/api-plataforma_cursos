<template>
    <div>
        <form @submit="alterForm">

            <label for="id">Código de identificação</label>
            <input type="text" id="title" v-model="formData.id" required>

            <label for="title">Titulo do Curso:</label>
            <input type="text" id="title" v-model="formData.title" required>

            <label for="body">Conteúdo:</label>
            <input type="text" id="text" v-model="formData.body" required>

            <label for="attachments">Anexos:</label>
            <input type="text" id="text" v-model="formData.attachments" required>

            <label for="password">Senha de Acesso:</label>
            <input type="text" id="text" v-model="formData.password" required>

            <button type="submit">Enviar</button>

            <div v-if="error === false">
                <p>Sucesso ao alterar curso</p>
            </div>

            <div v-if="error">
                <p>Ocorreu um erro ao alterar: {{ error }}</p>
            </div>

            <div v-if="error">
                <p>Ocorreu um erro ao alterar os dados: {{ error }}</p>
            </div>
        </form>
    </div>
</template>

<script src="./CoursesAlter.js"></script>

<style src="./style.css"></style>