import axios from '@/../src/axios';
import router from '@/routes';

export default {
    data() {
        return {
            formData: {
                referenceCourse: '',
                title: '',
                body: '',
                atachments: '',
                user_comments: 'xxxxx',
            },
            error: null,
        };
    },
    mounted() {
        // Use $route.params.cpf para acessar o CPF passado na rota
        const courseid = this.$route.params.courseid;
        const title = this.$route.params.title;
        // Defina o valor inicial do campo cpf com o valor do parâmetro da rota
        this.formData.title = title;
        this.formData.referenceCourse = courseid;
    },
    methods: {
         alterForm() {
            try {
                const response =  axios.put(`/Topic/${this.formData.title}`, this.formData);
                // Lide com a resposta aqui, por exemplo, exiba uma mensagem de sucesso
                console.log('Dados enviados com sucesso:', response.data);
                // Limpe o formulário após o envio
                // this.formData.title = '';
                // this.formData.body = '';
                // this.formData.attachments = '';
                this.error = false;

                window.alert('Topico alterado com sucesso!');
                router.push(`/view-topic/${this.formData.title}`);
            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
                this.error = true;
            }
        },
    },
};
