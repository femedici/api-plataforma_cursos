<template>
    <v-list>
        <v-list-item prepend-avatar="" title="UserName" subtitle="Usuário desde: XXXX">
        </v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list>
        <v-list-item prepend-icon="mdi-account" title="Perfil" to="/view-user"></v-list-item>
        <v-list-item prepend-icon="mdi-login" title="Login" to="/login"></v-list-item>
        <v-list-item prepend-icon="mdi-align-horizontal-left" title="Cursos Inscrito" to="/x"></v-list-item>
        <v-list-item prepend-icon="mdi-account" title="Cadastrar" to="/create-user"></v-list-item>
    </v-list>

    <div class="pa-2">
        <v-btn block>
            Desconectar
        </v-btn>
    </div>
</template>

<script>
import { mapGetters } from "vuex";

export default {
    computed: {
        ...mapGetters("user", ["getUserName", "getUserDate"]), // Mapeie os getters do módulo "user"
    },
}

</script>