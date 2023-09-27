<template>
    <v-list>
        <v-list-item prepend-avatar="" 
            title="La Moon"
            subtitle="Cursos Online">
        </v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list density="compact">
        <v-list-item prepend-icon="mdi-home" title="Home" to="/"></v-list-item>
        <v-list-item prepend-icon="mdi-login" title="Login" to="/about"></v-list-item>
    </v-list>
</template>

