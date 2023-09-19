<template>
    <div class="user-form">
        <form @submit="submitForm">
            <label for="nome" labels>Cpf</label>
            <input type="text" id="search-bars" v-model="formData.cpf" required>

            <label for="nome" labels><br>Nome</label>
            <input type="text" id="search-bars" v-model="formData.name" required>

            <label for="email" labels><br>Email</label>
            <input type="email" id="search-bars" v-model="formData.email" required>

            <label for="password" labels><br>Senha</label>
            <input type="text" id="search-bars" v-model="formData.password" required>
            <br>
            <div class="centralize">
                <button type="submit" id="centralize">Enviar</button>
            </div>
            <div v-if="error === false">
                <p>Sucesso ao cadastrar usuário</p>
            </div>
            <div v-if="error">
                <p>Ocorreu um erro ao buscar os dados: {{ error }}</p>
            </div>
        </form>
    </div>
</template>
  
<script src="./UserCreate.js"></script>

<style src="./style.css"></style>