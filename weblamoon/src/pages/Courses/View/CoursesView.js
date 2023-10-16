import axios from '@/../src/axios';
import router from '@/routes';

export default {
    data() {
        return {
            course: {
                id: null,
            },
            topics: [],
            error: null,
        };
    },
    created() {
        const courseId = this.$route.params.id;

        // Busque os detalhes do curso
        axios.get(`/Courses/id/${courseId}`)
            .then(response => {
                this.course = response.data;
            })
            .catch(error => {
                console.error("Erro ao buscar detalhes do curso:", error);
            });

        // Busque os tópicos relacionados ao curso'
        axios.get(`/Topic/referencecourse/${courseId}`)
            .then(response => {
                this.topics = response.data;
                this.error = null;
            })
            .catch(error => {
                this.topics = [];
                this.error = error.message;
                console.error("Erro ao buscar tópicos:", error);
            });
    },
    methods: {
        deleteCourse(id) {
            axios.delete(`/Courses/${id}`)
                .then(response => {
                    this.course = response.data;
                    window.alert('Curso deletado com sucesso!');
                    router.push(`/list-courses`);
                })
                .catch(error => {
                    console.error("Erro ao deletar curso:", error);
                });
        },
        confirmDeleteCourse() {
            const shouldDelete = window.confirm("Tem certeza de que deseja deletar este curso?");

            if (shouldDelete) {
                this.deleteCourse(this.course.id);
            }
        },
    },
};