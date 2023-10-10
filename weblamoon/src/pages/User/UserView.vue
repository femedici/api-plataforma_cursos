<template>
    <div>
        <div>
            <p>Nome do usuário: {{ getUserName }}</p>
            <p>Email do usuário: {{ getUserEmail }}</p>
            <p>Data de criação do usuário: {{ getUserDate }}</p>
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
import { mapGetters } from 'vuex';

export default {
    data() {
        return {
            user: {
                cpf: '',
            }
        };
    },
    computed: {
        ...mapGetters('user', ['getUserName', 'getUserEmail', 'getUserDate']), // Mapeando os getters do módulo 'user'
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
