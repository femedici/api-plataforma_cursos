<template>
    <div v-if="show" class="login-warning">
        <v-sheet elevation="12" max-width="600" rounded="lg" width="100%" class="pa-4 text-center mx-auto ">
            <v-icon class="mb-5" color="success" icon="mdi-check-circle" size="112"></v-icon>
            
            <h2 class="text-h5 mb-6"><br>{{ message }}</h2>
            
            <p class="mb-4 text-medium-emphasis text-body-2">
                <a>Login realizado com sucesso!</a>
                <br>
                Agora explore novos conhecimentos, novas áreas ou se quiser, crialas!
            </p>
            
            <v-divider class="mb-4"></v-divider>
            
            <div class="text-center">
                <v-btn class="text-none" color="success" rounded variant="flat" width="90" @click="closeLoginWarning" to="/">
                    Pronto
                </v-btn>
            </div>
        </v-sheet>
    </div>
</template>
  
<script>
export default {
    data() {
        return {
            show: false,
            message: '',
        };
    },
    methods: {
        openLoginWarning(message) {
            this.show = true;
            this.message = message;
        },
        closeLoginWarning() {
            this.show = false;
        },
    },
};
</script>
