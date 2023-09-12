<template>
    <div>
        <!-- <img src="@/assets/home/test.jpg" alt="test" class="frame1" /> -->
    </div>
    <!DOCTYPE html>
    <html lang="en">

    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Exemplo de Animação de Rolagem</title>
        <link rel="stylesheet" href="styles.css">
    </head>

    <body>
        <div class="container">
            <div class="scroll-fade">
                Cursos Diversos
            </div>
            <!-- Conteúdo da página -->
            <p>
                Aqui está um exemplo de como criar um elemento em CSS que aparece à medida que você rola a página.
                ...
            </p>
        </div>
    </body>

    </html>
</template>

<script>

</script>

<style scoped>
.frame1 {
    max-width: 100%;
    /* Define a largura máxima como 100% da largura da tela */
    height: auto;
    /* Mantém a proporção da imagem */
}

.presentation {
    background-image: linear-gradient(to top, #eed3aa 0%, #eed3aa 100%);
    width: 50%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.pres-text {
    width: 95%;
    font-family: 'Dosis', sans-serif;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
}

.container {
    width: 80%;
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
    text-align: center;
}

.scroll-fade {
    opacity: 0; /* Inicialmente, o elemento está invisível */
    transform: translateY(20px); /* Deslocamento inicial */
    animation: fade-in 1s ease-out forwards; /* Inicia a animação "fade-in" */
}

/* Define a animação "fade-in" */
@keyframes fade-in {
    to {
        opacity: 1; /* Quando a animação estiver completa, o elemento estará visível */
        transform: translateY(0); /* Deslocamento final */
    }
}

</style>