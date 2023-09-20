<template>
    <div class="user-form">
        <form @submit="alterForm">
            <div class="Title">
                Alterar Usuário
            </div>
            <br><br>
            <label for="name" class="label">Nome:</label>
            <input type="text" id="search-bars" v-model="formData.name" required>

            <label for="email" class="label">Email:</label>
            <input type="email" id="search-bars" v-model="formData.email" required>

            <label for="password" class="label">Senha:</label>
            <input type="text" id="search-bars" v-model="formData.password" required>

            <button type="submit">Enviar</button>
        </form>
    </div>
</template>
  
<script src="./UserAlter.js"></script>

<style src="./style.css"></style>