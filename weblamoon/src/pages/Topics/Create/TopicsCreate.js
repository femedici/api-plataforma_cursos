import axios from '@/../src/axios';

export default {
    data() {
        const courseId = this.$route.params.id;
        return {
            formData: {
                referenceCourse: courseId,
                title: '',
                body: '',
                atachments: '',
                user_comments: 'xxxxx',
            },
            error: null,
        };
    },

    methods: {
        submitForm() {
            try {
                const response = axios.post('/Topic', this.formData);
                // Lide com a resposta aqui, por exemplo, exiba uma mensagem de sucesso
                console.log('Dados enviados com sucesso:', response.data);
                // Limpe o formulário após o envio~
                this.formData.title = '';
                this.formData.body = '';
                this.formData.atachments = '';
                this.error = false;

                //
            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
            }
        },
    },
};
