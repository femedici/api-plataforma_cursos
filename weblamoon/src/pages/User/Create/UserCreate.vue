<template>
    <div class="user-form">
        <div class="Title">
            Cadastro
        </div>
        <br><br>
        <form @submit="submitForm">
            <label for="nome" class="label">Cpf</label>
            <input type="text" id="search-bars" v-model="formData.cpf" required>

            <label for="nome" class="label"><br>Nome</label>
            <input type="text" id="search-bars" v-model="formData.name" required>

            <label for="email" class="label"><br>Email</label>
            <input type="email" id="search-bars" v-model="formData.email" required>

            <label for="password" class="label"><br>Senha</label>
            <input type="text" id="search-bars" v-model="formData.password" required>
            <br>
            <div class="centralize">
                <button type="submit" id="centralize">Enviar</button>
            </div>
        </form>
    </div>
</template>
  
<script src="./UserCreate.js"></script>

<style src="./style.css"></style>