import axios from '@/../src/axios';
import router from '@/routes';
// import { formToJSON } from 'axios';

axios.defaults.headers.common['Content-Type'] = 'multipart/form-data';

export default {
    data() {
        return {
            formData: {
                id: '',
                title: '',
                icon: null,
                cover: 'xxxxx',
                body: '',
                attachments: '',
                password: '',
                comments: "XXXX",
                general_Progression: 0,
                user_Progression: 0,
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
                // Limpe o formulário após o envio~
                this.formData.title = '';
                this.formData.id = '';
                this.formData.icon = '';
                this.formData.body = '';
                this.formData.attachments = '';
                this.formData.password = '';
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
