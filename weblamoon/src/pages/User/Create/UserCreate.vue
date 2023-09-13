<template>
    <div>
        <form @submit="submitForm">
            <label for="nome">Nome:</label>
            <input type="text" id="nome" v-model="formData.name" required>

            <label for="email">Email:</label>
            <input type="email" id="email" v-model="formData.email" required>

            <label for="nome">Senha:</label>
            <input type="text" id="nome" v-model="formData.password" required>

            <button type="submit">Enviar</button>

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