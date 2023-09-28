<template>
    <div class="user-form">
        <form @submit="alterForm">
            <div class="Title">
                Alterar Usuário
            </div>
            <br><br>
            <label for="name" class="label">Nome:</label>
            <input type="text" id="search-bars" v-model="formData.name" required>

            <label for="email" class="label">Email:</label>
            <input type="email" id="search-bars" v-model="formData.email" required>

            <label for="password" class="label">Senha:</label>
            <input type="text" id="search-bars" v-model="formData.password" required>

            <button type="submit">Enviar</button>
        </form>
    </div>
</template>
  
<script>
import axios from '@/../src/axios';
import router from '@/routes';

export default {
    data() {
        return {
            formData: {
                cpf: '',
                name: '',
                email: '',
                password: '',
            },
            error: null,
        };
    },
    created() {
        // Use $route.params.cpf para acessar o CPF passado na rota
        const routeCpf = this.$route.params.cpf;

        // Defina o valor inicial do campo cpf com o valor do parâmetro da rota
        this.formData.cpf = routeCpf;
    },
    methods: {
        alterForm() {
            try {
                const response = axios.put(`/User/${this.formData.cpf}`, this.formData);
                // Lide com a resposta aqui, por exemplo, exiba uma mensagem de sucesso
                console.log('Dados enviados com sucesso:', response.data);
                // Limpe o formulário após o envio
                // this.formData.cpf = '';
                // this.formData.name = '';
                // this.formData.email = '';
                // this.formData.password = '';
                this.error = false;

                window.alert('Usuário alterado com sucesso!');
                router.push(`/view-user/${this.formData.email}`);
            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
                this.error = true;
            }
        },
    },
};
</script>
