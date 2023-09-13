
import axios from '@/../src/axios'; 

export default {
    data() {
        return {
            formData: {
                nome: '',
                email: '',
                senha: '',
            },
            error: null,
        };
    },


    methods: {
        submitForm() {
            try {
                const response = axios.post('/User', this.formData);
                // Lide com a resposta aqui, por exemplo, exiba uma mensagem de sucesso
                console.log('Dados enviados com sucesso:', response.data);
                // Limpe o formulário após o envio
                this.formData.nome = '';
                this.formData.email = '';
                this.error = false;
            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
            }
        },
    },
};
