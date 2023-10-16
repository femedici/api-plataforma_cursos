<template>
    <div class="container2">
        <h1>Detalhes do Curso</h1>
        <div v-if="course">
            <h2>{{ course.title }}</h2>
            <p>Código de referencia: {{ course.id }}</p>
            <p>Sobre o curso: {{ course.body }}</p>
            <p>Anexos: {{ course.attachments }}</p>
        </div>
        <h3>Tópicos:</h3>
        <h3>-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        </h3>
        <!-- Use topics em vez de data para iterar sobre os tópicos -->
        <div v-for="(item, index) in topics" :key="index">
            <p class="text-bold">{{ item.title }}</p>
            <p>{{ item.body }}</p>
            <router-link :to="'/view-topic/' + item.title" class="button1">Acessar</router-link>
            <h3>-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            </h3>
        </div>
        <router-link :to="'/create-topic/' + course.id" class="button2">Criar Tópico</router-link>
        <div class="button-container">
            <router-link :to="'/alter-course/' + course.id" class="button2">Alterar Curso</router-link>
            <button type="button" @click="confirmDeleteCourse" class="button2">Deletar Curso</button>
        </div>
    </div>
</template>

<script src="./CoursesView.js"></script>

<style src="./style.css"></style>