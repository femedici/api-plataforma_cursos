<template>
    <div class="h-screen flex flex-col justify-between">
        <div>
            <v-list>
                <a href="/"><v-img src="@/assets/logoName.png"></v-img></a>
            </v-list>

            <v-divider></v-divider>

            <v-list>
                <v-list-item prepend-icon="mdi-view-dashboard" title="Cursos" to="/list-courses"
                    class="font-sans text-zinc-50 text-xl"></v-list-item>
                <v-list-item prepend-icon="mdi-account-star" title="Tornar-se Criador" to="/becameCreator"
                    class="font-sans text-zinc-50 text-xl"></v-list-item>
                <v-list-item v-if="getUserCreator" prepend-icon="mdi-plus-box-multiple" title="Publicar Curso"
                    to="/create-course" class="font-sans text-zinc-50 text-xl"></v-list-item>
                <v-list-item v-if="getUserCreator" prepend-icon="mdi-creation" title="Cursos Publicados"
                    to="/creator-page" class="font-sans text-zinc-50 text-xl"></v-list-item>
                <v-list-item v-if="getUserID" prepend-icon="mdi-playlist-check" title="Cursos Inscrito" to="/coursesSub"
                    class="font-sans text-zinc-50 text-xl"></v-list-item>
                <v-list-item prepend-icon="mdi-login" title="Login" to="/login"
                    class="font-sans text-zinc-50 text-xl"></v-list-item>
            </v-list>
        </div>

        <div>
            <v-list-item prepend-icon="mdi-shield-account-variant" title="Administração" to="/admin-users"
                v-if="getUserName == 'admin'" class="font-sans text-zinc-50 text-xl"></v-list-item>
            <v-divider></v-divider>
            <v-list>
                <v-list-item prepend-icon="mdi-account" title="Perfil" to="/view-user" v-if="getUserID"
                    class="font-sans text-zinc-50 text-xl"></v-list-item>
            </v-list>
        </div>
    </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
    computed: {
        ...mapGetters('user', ['getUserID', 'getUserName', 'getUserCreator']), // Mapeando os getters do módulo 'user'
    },
}

</script>