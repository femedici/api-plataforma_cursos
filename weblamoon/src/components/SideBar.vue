<template>
    <div class="h-screen flex flex-col justify-between">
        <div>
            <v-list>
                <v-img src="@/assets/logoName.png"></v-img>
                <v-list-item prepend-icon="mdi-home" title="Home" to="/" class="font-sans text-zinc-50 text-xl"></v-list-item>
            </v-list>
            
            <v-divider></v-divider>
            
            <v-list>
                <v-list-item prepend-icon="mdi-view-dashboard" title="Cursos" to="/list-courses"
                class="font-sans text-zinc-50 text-xl"></v-list-item>
                <v-list-item prepend-icon="mdi-playlist-check" title="Cursos Inscritos" to=""
                class="font-sans text-zinc-50 text-xl"></v-list-item>
                <v-list-item prepend-icon="mdi-login" title="Login" to="/login"
                class="font-sans text-zinc-50 text-xl"></v-list-item>
                <v-list-item prepend-icon="mdi-format-align-left" title="Sobre" to="/about"
                class="font-sans text-zinc-50 text-xl"></v-list-item>
            </v-list>
        </div>
        


        <div>
            <v-divider></v-divider>
            <v-list>
                <v-list-item prepend-icon="mdi-account" title="Perfil" to="/view-user"
                class="font-sans text-zinc-50 text-xl"></v-list-item>
            </v-list>
        </div>
    </div>
</template>

<script>

export default {
}

</script>