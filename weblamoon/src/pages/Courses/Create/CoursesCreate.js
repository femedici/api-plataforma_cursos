import axios from '@/../src/axios';
import router from '@/routes';
// import { formToJSON } from 'axios';

axios.defaults.headers.common['Content-Type'] = 'multipart/form-data';

export default {
    data() {
        return {
            formData: {
                title: '',
                description: '',
                mainVideo: "XXXX",
                bodyText: '',
                icon: null,
                banner: 'xxxxx',
            },
            error: null,
        };
    },

    methods: {

        async submitForm() {
            try {
                this.formData.icon = this.$refs.fileInput.files[0];

                console.log(this.$refs.fileInput.files[0]);

                const response = await axios.post('/Courses', this.formData);


                // Lide com a resposta aqui, por exemplo, exiba uma mensagem de sucesso
                console.log('Dados enviados com sucesso:', response.data);
                window.alert('Dados criados');
                // Limpe o formulário após o envio~
                this.error = false;

                //
                window.alert('Curso criado com sucesso!');
                router.push(`/list-courses`);
            } catch (error) {
                // Lide com erros aqui, por exemplo, exiba uma mensagem de erro
                console.error('Erro ao enviar dados:', error);
                window.alert('Erro ao criar o curso. Por favor, tente novamente.');
            }
        },
    },
};
