import axios from '@/../src/axios';

export default {
    data() {
        return {
            formData: {
                cpf: '',
                nome: '',
                email: '',
                senha: '',
            },
            error: null,
        };
    },


    methods: {
        alterForm() {
            try {
                const response = axios.put(`/User/${this.cpf}`, this.formData);
                // Lide com a resposta aqui, por exemplo, exiba uma mensagem de sucesso
                console.log('Dados enviados com sucesso:', response.data);
                // Limpe o formulário após o envio
                this.formData.cpf = '';
                this.formData.nome = '';
                this.formData.email = '';
                this.error = false;

                //
            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
            }
        },
    },
};