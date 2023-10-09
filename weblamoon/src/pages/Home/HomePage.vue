<template>
    <!DOCTYPE html>
    <html lang="en">


    <body>
        <div class="columns-2">

            <div class="esquerda">
                <h2>Bem vindos!</h2><br>
                <p>A lamoon é uma plataforma de cursos. Temos a flexibilidade de permitir o usuario adicionar qualquer curso
                    *contanto que tenha uma verificação manual de nossos admnistradores*.
                </p>
                <p>
                    Tem algo a ensinar ou desejo de aprender? Vem com a LaMoon!
                </p>
            </div>
            <div class="direita">
                <router-link to="/">
                    <img src="@/assets/home2.png" alt="Ilustrativo" width="375" height="250" />
                    <br>
                </router-link>
            </div>
        </div>
        <div class="container">
            <div class="scroll-fade">
                Cursos Diversos
            </div>
            <!-- Conteúdo da página -->
            <p class="texts">
                <router-link to="/create-course" class="nav-link">Crie Cursos</router-link>
            </p>
            <p class="texts">
                Estude de forma otimizada
            </p>
            <p class="texts">
                Organize seus cursos e tenha informações do andamento, tópicos mais relevantes e dados relevantes para
                otimização.
            </p>
            <p class="texts">
                Se cadastre clicando aqui: <router-link to="/create-user" class="nav-link">Cadastro</router-link>
            </p>

            <v-sheet elevation="12" max-width="600" rounded="lg" width="100%" class="pa-4 text-center mx-auto">
                <v-icon class="mb-5" color="success" icon="mdi-check-circle" size="112"></v-icon>

                <h2 class="text-h5 mb-6">Veja alguns dos cursos disponíveis.</h2>

                <p class="mb-4 text-medium-emphasis text-body-2">
                    <a href="/list-courses" class="text-decoration-none text-info">Próximo</a>
                </p>
            </v-sheet>
        </div>
    </body>

    </html>
</template>

<script>

</script>

<style src="./style.css"></style>