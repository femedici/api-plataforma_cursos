<template>
  <v-parallax class="object-cover"
    src="https://images.unsplash.com/photo-1451187580459-43490279c0fa?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2072&q=80">
    <div class="page">
      <div class="content">
        <div class="text-left">
          <v-img class="logoimg" src="@/assets/logoName.png"></v-img>
          <h1 class="textlogo">Embarque nessa jornada de possibilidades e explore um<br>universo de conhecimento!</h1>
          <div class="matrix-section">
            <div class="matrix-container">
              <div class="card-matrix">
                <div class="row">
                  <div class="card">
                    <h3><v-icon icon="mdi-wifi" size="small"></v-icon> Dev WEB</h3>
                    <v-divider></v-divider>
                    <p>Aprenda o básico de tudo necessário para desenvolver uma aplicação web completa!</p>
                  </div>
                  <div class="card">
                    <h3><v-icon icon="mdi-wifi" size="small"></v-icon> Dev WEB</h3>
                    <v-divider></v-divider>
                    <p>Aprenda o básico de tudo necessário para desenvolver uma aplicação web completa!</p>
                  </div>
                  <div class="card">
                    <h3><v-icon icon="mdi-wifi" size="small"></v-icon> Dev WEB</h3>
                    <v-divider></v-divider>
                    <p>Aprenda o básico de tudo necessário para desenvolver uma aplicação web completa!</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="imagem-com-relevo">
          <img class="imagem-com-relevo-inner"
            src="https://images.unsplash.com/photo-1513258496099-48168024aec0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80" />
        </div>
      </div>
    </div>

    <div class="big-card">
      <h1><strong>Para começar é simples.</strong></h1>
      <v-divider></v-divider>
      <p class="bc-description"><br>Crie uma conta<br>Escolha um curso<br>Se cadastre nele, ou<br>Vá para a aba
        cursos<br>Clique em "Publicar Curso"<br>Preencha todos os campos<br>E aguarde o mesmo ser liberado!</p>
      <br>
      <v-divider></v-divider>
      <h3>Demonstrou interesse? Por que não começa <strong><router-link :to="'/create-user/'">criando uma
            conta?</router-link></strong></h3>
    </div>
  </v-parallax>
</template>
<script>

export default {
  name: "App",
  data() {
    return {
    };
  },
};
</script>

<style scoped>
.page {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  padding: 20px;
}

.content {
  display: flex;
  justify-content: center;
}

.logoimg {
  margin-top: -200px;
  margin-left: -170px;
}

.text-left {
  width: 50%;
  padding: 20px;
  text-align: left;
  align-self: center;
  margin-top: 150px;
}

.textlogo {
  margin-top: -120px;
  margin-left: 90px;
}

.imagem-com-relevo {
  box-shadow: 0 0 0px rgba(0, 0, 0, 0.7);
  transform: scale(1);
  border-radius: 12px;
  max-width: 40%;
  margin-top: 55px;
}

.imagem-com-relevo-inner {
  box-shadow: 0 15px 10px rgba(0, 0, 0, 0.5);
  border-radius: 8px;
  max-width: 100%;
  margin-top: 80px;
}

h1 {
  font-size: large;
}

.matrix-section {
  text-align: center;
  margin: 40px;
}

.matrix-container {
  margin-left: -130px;
  margin-top: 130px;
  display: flex;
  justify-content: left;
}

.card-matrix {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.row {
  display: flex;
  justify-content: center;
  margin: 10px 0;
}

.card {
  background-color: #092a49;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  margin: 10px;
  margin-left: 50px;
  flex: 1;
  width: 200px;
  /* Largura do cartão */
  height: 200px;
  /* Altura do cartão */
}


.big-card {
  margin-top: 200px;
  border: 1px solid #092a4985;
  padding: 20px;
  width: 100%;
  height: 300px;
  text-align: center;
  background-color: #092a4985;
}

.bc-description {
  margin-left: 20px;
  text-align: center;
}
</style>