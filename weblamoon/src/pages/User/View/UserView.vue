<template>
    <div>
        <div v-if="user">
            <h2>Informações do Usuário: {{ user.name }}</h2>
            <p>Cpf: {{ user.cpf }}</p>
            <p>Email: {{ user.email }}</p>
            <!-- Adicione outras informações que desejar mostrar aqui -->
        </div>
    </div>
    <router-link :to="'/alter-user/' + user.cpf" class="nav-link">Alterar Usuário</router-link>
    <br><br>
    <button type="button"  @click="confirmDeleteUser">Deletar Usuário</button>
</template>

<script src="./UserView.js"></script>

<style src="./style.css"></style>