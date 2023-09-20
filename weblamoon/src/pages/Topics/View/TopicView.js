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