<template>
    <div class="container">
        <h1>Detalhes do Curso</h1>
        <div v-if="course">
            <h2>{{ course.title }}</h2>
            <p>{{ course.id }}</p>
            <p>{{ course.body }}</p>
            <p>{{ course.former }}</p>
            <p>{{ course.comments }}</p>
        </div>
        <h3>Tópicos:</h3>
        <!-- Use topics em vez de data para iterar sobre os tópicos -->
        <div v-for="(item, index) in topics" :key="index">
            <p>{{ item.title }}</p>
            <p>{{ item.body }}</p>
            <router-link :to="'/view-topic/' + item.title" class="nav-link">VER</router-link>
        </div>
        <br><br>
        <router-link :to="'/create-topic/' + course.id" class="nav-link">Criar Tópico</router-link>
    </div>
</template>

<script src="./CoursesView.js"></script>

<style src="./style.css"></style>