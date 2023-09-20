<template>
    <div class="course-form">
        <form @submit="submitForm">
            <label for="id" labels>Código de identificação<br></label>
            <input type="text" id="search-bars" v-model="formData.id" required>

            <label for="title" labels><br>Titulo do Curso:<br></label>
            <input type="text" id="search-bars" v-model="formData.title" required>

            <label for="body" labels><br>Conteúdo:<br></label>
            <input type="text" id="search-bars" v-model="formData.body" required>

            <label for="attachments" labels><br>Anexos:<br></label>
            <input type="text" id="search-bars" v-model="formData.attachments" required>

            <label for="password" labels><br>Senha de Acesso:<br></label>
            <input type="text" id="search-bars" v-model="formData.password" required>
            <br>
            <div class="centralize">
                <button type="submit" id="centralize">Enviar</button>
            </div>
            <div v-if="error === false">
                <p>Sucesso ao criar curso</p>
            </div>
            <div v-if="error">
                <p>Ocorreu um erro ao criar: {{ error }}</p>
            </div>
        </form>
    </div>
</template>
  
<script src="./CoursesCreate.js"></script>

<style src="./style.css"></style>