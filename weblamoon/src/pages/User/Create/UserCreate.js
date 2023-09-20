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
        submitForm() {
            try {
                const response = axios.post('/User', this.formData);
            
                console.log('Dados enviados com sucesso:', response.data);
                // Limpe o formulário após o envio
                this.formData.cpf = '';
                this.formData.nome = '';
                this.formData.email = '';
                this.error = false;

                window.alert('Cadastro realizado com sucesso!');
            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
                window.alert('Erro ao cadastrar. Por favor, tente novamente.');
            }
        },
    },
};
