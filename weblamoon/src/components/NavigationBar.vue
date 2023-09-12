<!-- NavigationBar.vue -->

<template>
  <nav class="navbar">
    <div class="logo">
      <router-link to="/">
        <img src="@/assets/logo.png" alt="LaMoon" />
      </router-link>
    </div>
    <div class="nav-links">
      <router-link to="/about" class="nav-link">Sobre</router-link>
      <router-link to="/create" class="nav-link">Cadastro</router-link>
      <router-link to="/login" class="nav-link">Login</router-link>
    </div>
  </nav>
</template>

<style scoped>
.navbar {
  background-color: #eed3aa;
  /* Cor de fundo da barra de navegação */
  border-bottom: 4px solid #810b67;
  /* Borda na parte inferior da barra */
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 10px 20px;
}

.logo img {
  width: 60px;
  height: 60px;
}

.nav-links a {
  color: #fff;
  /* Cor do texto dos links */
  text-decoration: none;
  margin: 0 15px;
  font-family: 'Dosis', sans-serif;
  text-transform: uppercase;
  font-size: 170%;
  font-weight: bold;  
}
.nav-links .nav-link {
  text-decoration: none;
  margin: 0 15px;
  transition: text-decoration 0.5s; /* Adicione uma transição suave para a animação do sublinhado */
}

.nav-links .nav-link:hover {
  color: #EF6C00;
  text-decoration: underline; /* Adiciona sublinhado quando o mouse está sobre o link */
}
</style>
