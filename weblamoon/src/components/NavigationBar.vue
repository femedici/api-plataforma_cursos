<template>
  <nav class="navbar">
    <div class="container">
      <div class="logo">
        <router-link to="/">
          <img src="@/assets/logo-navigation.png" alt="LaMoon" />
        </router-link>
      </div>
      <div class="nav-links">
        <router-link to="/about" class="nav-link">Sobre</router-link>
        <router-link to="/list-users" class="nav-link">Usuários</router-link>
        <router-link to="/list-courses" class="nav-link">Cursos</router-link>
        <span class="divider"></span>
        <router-link to="/login" class="nav-link">Login</router-link>
        <router-link to="/create-user" class="nav-link">Cadastro</router-link>
        <!-- <router-link to="/view-user" class="nav-link">Perfil</router-link> -->
      </div>
    </div>
  </nav>
</template>

<style scoped>
.navbar {
  background-color: #eed3aa;
  /* Cor de fundo da barra de navegação */
  border-bottom: 4px solid #810b67;
  /* Borda na parte inferior da barra */
}

.container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  max-width: 1200px;
  /* Defina a largura máxima desejada */
  margin: 0 auto;
  /* Centraliza horizontalmente */
  padding: 10px 20px;
}

.logo img {
  max-width: 80%;
  /* Define a largura máxima como 100% da largura da tela */
  height: auto;
  /* Mantém a proporção da imagem */
}

.nav-links a {
  color: #fff;
  /* Cor do texto dos links */
  margin: 0 15px;
  font-family: 'BR Firma', sans-serif;
  text-transform: uppercase;
  font-size: 100%;
}

.nav-links .nav-link {
  text-decoration: none;
  margin: 0 15px;
  transition: text-decoration 0.5s;
  /* Adicione uma transição suave para a animação do sublinhado */
}

.nav-links .nav-link:hover {
  color: #EF6C00;
}

.divider {
  height: 20px;
  /* Aumente a altura para tornar o divisor visível */
  margin: 0 15px;
  /* Espaçamento à esquerda e à direita do divisor */
}</style>
