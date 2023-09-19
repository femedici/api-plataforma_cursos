<template>
    <div class="container">
        <div v-if="topic">
            <h2>{{ topic.title }}</h2>
            <p>{{ topic.body }}</p>
            <p>{{ topic.attachments }}</p>
            <p>{{ topic.user_comments }}</p>
        </div>
    </div>
    <router-link :to="'/alter-topic/' + topic.title" class="nav-link">Alterar Tópico</router-link>
    <br><br>
    <button type="button" @click="confirmDeleteTopic">Deletar Topico</button>
</template>

<script src="./TopicView.js"></script>

<style src="./style.css"></style>