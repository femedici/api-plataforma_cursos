<template>
    <div>
        <div v-if="user">
            <h2>Informações do Usuário: {{ user.name }}</h2>
            <p>Cpf: {{ user.cpf }}</p>
            <p>Email: {{ user.email }}</p>
            <!-- Adicione outras informações que desejar mostrar aqui -->
        </div>
    </div>
    <div class="button-container">
        <router-link :to="'/alter-user/' + user.cpf" class="button2">Alterar Usuário</router-link>
        <button type="button" @click="confirmDeleteUser" class="button2">Deletar Usuário</button>
    </div>
</template>

<script>
import axios from '@/../src/axios';
import router from '@/routes';

export default {
    data() {
        return {
            user: {
                cpf: '',
            }
        };
    },
    created() {
        const userEmail = this.$route.params.email;

        // Busque os detalhes do curso
        axios.get(`/User/email/${userEmail}`)
            .then(response => {
                this.user = response.data;
            })
            .catch(error => {
                console.error("Erro ao buscar detalhes do curso:", error);
            });
    },
    methods: {
        deleteUser(cpf) {
            axios.delete(`/User/${cpf}`)
                .then(response => {
                    this.user = response.data;
                    window.alert('Usuário deletado com sucesso!');
                    router.push(`/list-users`);
                })
                .catch(error => {
                    console.error("Erro ao buscar detalhes do curso:", error);
                });
        },
        confirmDeleteUser() {
            const shouldDelete = window.confirm("Tem certeza de que deseja deletar este usuário?");

            if (shouldDelete) {
                this.deleteUser(this.user.cpf);
            }
        },
    },
};
</script>
