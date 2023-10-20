<template>
    <div class="user-form">
      <form @submit="alterForm" class="form-container">
        <div class="title">Alterar Usuário</div>
        <br /><br />
        <label for="name" class="label">Nome:</label>
        <input type="text" id="search-bars" v-model="formData.name" required />
  
        <label for="email" class="label">Email:</label>
        <input type="email" id="search-bars" v-model="formData.email" required />
  
        <label for="password" class="label">Senha:</label>
        <input type="password" id="search-bars" v-model="formData.password" required />
  
        <button type="submit" class="button">Enviar</button>
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
  
  <style scoped>
  .user-form {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
  }
  
  .form-container {
    text-align: center;
    border: 1px solid #ccc;
    padding: 20px;
    background-color: #000000;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  }
  
  .title {
    font-size: 24px;
    margin-bottom: 20px;
  }
  
  .label {
    font-weight: bold;
    display: block;
    margin: 10px 0;
  }
  
  #search-bars {
    width: 100%;
    padding: 10px;
    color: #000000;
    border: 1px solid #000000;
    border-radius: 5px;
  }
  
  .button {
    background-color: #007BFF;
    color: #fff;
    padding: 10px 20px;
    margin: 10px 0;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    text-decoration: none;
    text-align: center;
  }
  
  .button:hover {
    background-color: #0056b3;
  }
  </style>