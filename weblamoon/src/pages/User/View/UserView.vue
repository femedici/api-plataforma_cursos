<template>
    <div>
        <div v-if="user">
            <h2>Informações do Usuário: {{ user.name }}</h2>
            <p>Cpf: {{ user.cpf }}</p>
            <p>Email: {{ user.email }}</p>
            <!-- Adicione outras informações que desejar mostrar aqui -->
        </div>
    </div>
    <div class="button-container">
        <router-link :to="'/alter-user/' + user.cpf" class="button2">Alterar Usuário</router-link>
        <button type="button" @click="confirmDeleteUser" class="button2">Deletar Usuário</button>~
    </div>
</template>

<script src="./UserView.js"></script>

<style src="./style.css"></style>