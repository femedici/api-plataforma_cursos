<template>
    <div>
        <input v-model="email" placeholder="Digite o email" />
        <button @click="buscarDados">Buscar</button>
        <div v-if="usuario">
            <h2>Usuário Encontrado:</h2>
            <p>Nome: {{ usuario.name }}</p>
            <p>Email: {{ usuario.email }}</p>
            <!-- Adicione outras informações que desejar mostrar aqui -->
        </div>
    </div>
</template>

<script src="./UserView.js"></script>

<style src="./style.css"></style>