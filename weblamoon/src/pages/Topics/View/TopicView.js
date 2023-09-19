import axios from '@/../src/axios';

export default {
  data() {
    return {
      topic: {
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
        axios.delete(`/Topic/${title}`)
            .then(response => {
                this.topic = response.data;
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