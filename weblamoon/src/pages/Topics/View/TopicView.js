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
};