<template>
    <v-list>
        <v-list-item prepend-avatar="" title="UserName" subtitle="Usuário desde: XXXX">
        </v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list>
        <v-list-item prepend-icon="mdi-home" title="Home" to="/"></v-list-item>
        <v-list-item prepend-icon="mdi-format-align-left" title="Sobre" to="/about"></v-list-item>
        <v-list-item prepend-icon="mdi-animation" title="Cursos" to="/list-courses"></v-list-item>
        <v-list-item prepend-icon="mdi-login" title="Login" to="/login"></v-list-item>
        <v-list-item prepend-icon="mdi-align-horizontal-left" title="Cursos Inscrito" to="/x"></v-list-item>
        <v-list-item prepend-icon="mdi-account" title="Cadastrar" to="/create-user"></v-list-item>
    </v-list>

    <div class="pa-2">
        <v-btn block >
            Cadastrar
        </v-btn>
    </div>
</template>

<script>

export default {
}

</script>