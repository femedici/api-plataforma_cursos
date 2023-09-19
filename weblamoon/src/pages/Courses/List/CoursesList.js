import axios from '@/../src/axios';

export default {
    data() {
        return {
            data: [],
            error: null,
        };
    },
    methods: {
        // mounted() {
        //     this.fetchData(); // Chama a função fetchData quando o componente é montado
        // },
        fetchData() {
            axios.get('/Courses')
                .then(response => {
                    this.data = response.data;
                    this.error = null;
                })
                .catch(error => {
                    this.data = [];
                    this.error = error.message;
                });
        },
    },
};