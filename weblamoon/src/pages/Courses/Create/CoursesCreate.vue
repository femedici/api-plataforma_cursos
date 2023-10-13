<template>
    <div class="course-form">
        <div class="Title">
            Crie seu curso
        </div>
        <br><br>
        <form @submit.prevent="submitForm">
            <label for="id" labels>Código de identificação (3 Numeros)<br></label>
            <input type="text" id="search-bars" v-model="formData.id" required>

            <label for="title" labels><br>Titulo do Curso:<br></label>
            <input type="text" id="search-bars" v-model="formData.title" required>

            <label for="body"><br>Conteúdo:<br></label>
            <input type="text" id="search-bars" v-model="formData.body">

            <label for="icon"><br>Ícone do Curso:<br></label>
            <input type="file" id="icon"  ref="fileInput" @change="handleFileChange">
            <br><br>

            <label for="attachments" labels><br>Anexos:<br></label>
            <input type="text" id="search-bars" v-model="formData.attachments">

            <label for="password" labels><br>Senha de Acesso:<br></label>
            <input type="text" id="search-bars" v-model="formData.password">
            <br>
            <div>
                <button type="submit">Enviar</button>
            </div>
        </form>
    </div>
</template>
  
<script src="./CoursesCreate.js"></script>

<style src="./style.css"></style>