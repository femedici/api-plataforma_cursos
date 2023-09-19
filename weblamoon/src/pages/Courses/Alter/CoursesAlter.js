import axios from '@/../src/axios';

export default {
    data() {
        return {
            formData: {
                id: '',
                title: '',
                icon: 'xxxxx',
                cover: 'xxxxx',
                body: '',
                attachments: '',
                password: '',
                comments: "XXXX",
                general_Progression: 0,
                user_Progression: 0,
            },
            error: null,
        };
    },

    created() {
        // Use $route.params.cpf para acessar o CPF passado na rota
        const routeId = this.$route.params.id;

        // Defina o valor inicial do campo cpf com o valor do parâmetro da rota
        this.formData.id = routeId;
    },

    methods: {
        async alterForm() {
            try {
                const response = await axios.put(`/Courses/${this.formData.id}`, this.formData);
                // Lide com a resposta aqui, por exemplo, exiba uma mensagem de sucesso
                console.log('Dados enviados com sucesso:', response.data);
                // Limpe o formulário após o envio
                this.formData.id = '';
                this.formData.title = '';
                this.formData.body = '';
                this.formData.attachments = '';
                this.formData.password = '';
                this.error = false;

            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
                this.error = true;
            }
        },
    },
};
