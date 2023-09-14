import axios from '@/../src/axios';

export default {
    data() {
        return {
            email: "",
            usuario: null
        };
    },
    methods: {
        buscarDados() {
            axios.get(`/User/email/${this.email}`)
                .then(response => {
                    this.usuario = response.data;
                })
                .catch(error => {
                    console.error("Erro ao buscar dados:", error);
                });
        }
    }
};

