<template>
    <div class="container">
        <div v-if="topic">
            <h2>{{ topic.title }}</h2>
            <p>{{ topic.body }}</p>
            <p>{{ topic.attachments }}</p>
            <p>{{ topic.user_comments }}</p>
        </div>
    </div>
    <div class="button-container">
        <router-link :to="'/alter-topic/' + topic.referenceCourse + '/' + topic.id" class="button2">Alterar
            Tópico</router-link>
        <button type="button" @click="confirmDeleteTopic" class="button2">Deletar Topico</button>
    </div>
    <br><br>
    <router-link :to="'/view-course/' + topic.referenceCourse" class="button1">Retornar ao Curso</router-link>
</template>

<script src="./TopicView.js"></script>

<style src="./style.css"></style>