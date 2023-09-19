<template>
    <div class="container">
        <div v-if="topic">
            <h2>{{ topic.title }}</h2>
            <p>{{ topic.body }}</p>
            <p>{{ topic.attachments }}</p>
            <p>{{ topic.user_comments }}</p>
        </div>
    </div>
</template>

<script src="./TopicView.js"></script>

<style src="./style.css"></style>