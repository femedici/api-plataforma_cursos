<template>
    <div>
        <form @submit="alterForm">

            <label for="name">Nome:</label>
            <input type="text" id="name" v-model="formData.name" required>

            <label for="email">Email:</label>
            <input type="email" id="email" v-model="formData.email" required>

            <label for="password">Senha:</label>
            <input type="text" id="password" v-model="formData.password" required>

            <button type="submit">Enviar</button>
        </form>
    </div>
</template>
  
<script src="./UserAlter.js"></script>

<style src="./style.css"></style>