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

<script>
import axios from '@/../src/axios';
import router from '@/routes';

export default {
    data() {
        return {
            topic: {
                id: '',
                referenceCourse: '',
                title: '',
            },
            error: null,
        };
    },
    created() {
        const topicTitle = this.$route.params.title;

        // Busque os detalhes do topico
        axios.get(`/Topic/title/${topicTitle}`)
            .then(response => {
                this.topic = response.data;
            })
            .catch(error => {
                console.error("Erro ao buscar detalhes do curso:", error);
            });

    },
    methods: {
        deleteTopic(title) {
            const id_reference = this.topic.referenceCourse;
            axios.delete(`/Topic/${title}`)
                .then(response => {
                    this.topic = response.data;
                    window.alert('Topico deletado com sucesso!');
                    router.push(`/view-course/${id_reference}`);
                })
                .catch(error => {
                    console.error("Erro ao buscar detalhes do curso:", error);
                });
        },
        confirmDeleteTopic() {
            const shouldDelete = window.confirm("Tem certeza de que deseja deletar este tópico?");

            if (shouldDelete) {
                this.deleteTopic(this.topic.title);
            }
        },
    },
};
</script>