<template>
  <div class="about-us">
    <v-parallax class="object-cover"
      src="https://images.unsplash.com/photo-1451187580459-43490279c0fa?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2072&q=80">
      <div class="header">
        <h2><strong>Sobre nós</strong></h2>
        <v-img class="logoimg" src="@/assets/logoName.png"></v-img>
      </div>
    </v-parallax>
    <div class="about-content">
      <div class="about-section" v-for="(topic, key, index) in topics" :key="key">
        <div class="about-card">
          <div class="about-card-content" :class="{ 'reverse': index % 2 !== 0 }">
            <div class="text-container">
              <h1>{{ topic.title }}</h1>
              <v-divider></v-divider>
              <p>{{ topic.text }}</p>
            </div>
            <img :src="topic.image" alt="Imagem para {{ topic.title }}" class="about-image">
          </div>
          <v-divider class="divider" v-if="index < Object.keys(topics).length - 1"></v-divider>
        </div>
      </div>
    </div>
    <div class="github-users">
      <h2>Equipe</h2>
      <div class="github-user" v-for="(user, userIndex) in Users" :key="userIndex">
        <img :src="user.image">
        <div class="user-details">
          <a :href="`https://github.com/${user.githubUsername}`" target="_blank"><img
              src="https://cdn-icons-png.flaticon.com/512/25/25231.png" /></a>
          <p>{{ user.name }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
  
<script>

export default {

  data() {
    return {
      topics: {
        "sobre-lamoon": {
          title: "Sobre a LaMoon",
          text: "Nossa plataforma vai permitir que você compre cursos sobre os tópicos que mais lhe interessam. Mas a melhor parte é que, se você é um especialista ou tem conhecimento valioso a compartilhar, você pode criar seu próprio curso e vendê-lo. É uma oportunidade única para todos, sejam alunos ávidos ou futuros instrutores. Mas claro, todos os cursos são verificados antes de aprovados, além dos usuarios avaliarem a qualidade dos mesmos. Estamos desenvolvendo essa plataforma como parte de nosso projeto para a matéria de Projeto Integrador da UTFPR-CM no segundo semestre de 2023.",
          image: "https://images.unsplash.com/photo-1546410531-bb4caa6b424d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2071&q=80"
        },
        "missao": {
          title: "Missão",
          text: "Nossa missão é capacitar indivíduos através da educação, tornando o conhecimento e as habilidades acessíveis a todos. Acreditamos que a educação é a chave para desbloquear oportunidades ilimitadas e estamos comprometidos em tornar a aprendizagem online eficaz e envolvente.",
          image: "https://media.istockphoto.com/id/1418476503/pt/foto/businessman-analyzing-companys-financial-balance-sheet-working-with-digital-augmented-reality.jpg?s=612x612&w=0&k=20&c=XzJYWhzF6b37CxAwUQdDMduRxdnxhVaiId1W8Qmk8TE="
        },
        "nossa-equipe": {
          title: "Linguagens e Tecnologias",
          text: "Para o desenvolvimento da plataforma foram utilizados, para o Front-End, as linguagens Vue, HTML5 e CSS3, enquanto para o Back-End, as linguagens C#, dotNet e MongoDB.",
          image: "https://images.unsplash.com/photo-1593062037896-764e9f52029e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80"
        },
      },
      Users: [
        {
          name: "Felipe Augusto Medici",
          image: "https://avatars.githubusercontent.com/u/111476568?v=4",
          githubUsername: "femedici",
        },
        {
          name: "Felipe Roskosz Moran",
          image: "https://avatars.githubusercontent.com/u/105233020?v=4",
          githubUsername: "feliperm17",
        },
        {
          name: "Felipe Martins Sanches",
          image: "https://avatars.githubusercontent.com/u/79864909?s=400&u=0bd727ea4080ae444b74f08fac8cad2d17912821&v=4",
          githubUsername: "mattokgit44",
        },
        {
          name: "Caio Ducati Castilho",
          image: "https://avatars.githubusercontent.com/u/101857288?v=4",
          githubUsername: "Cast43",
        },
      ],
    };
  },
};
</script>
  
<style scoped>
.logoimg {
  max-height: 20%;
  max-width: 20%;
  margin-left: 41%;
  margin-top: -20 px;
}

h2 {
  font-size: xx-large;
}

.header {
  text-align: center;
  margin-top: 175px;
}

.object-cover {
  max-height: 400px;
}

.about-us {
  text-align: center;
}

.about-card {
  background-color: #0a0736;
  /*border-radius: 8px;*/
  padding: 20px;
}

.about-card-content {
  display: flex;
  align-items: center;
  text-align: left;
}

.about-image {
  max-width: 500px;
  border-radius: 8px;
  margin-left: 20px;
}

.divider {
  height: 2px;
  background-color: #ccc;
  margin: 10px 0;
}

h1 {
  font-size: x-large;
}

.text-container {
  flex: 1;
}

p {
  margin-top: 30px;
}

.reverse {
  flex-direction: row-reverse;
  text-align: right;
}

.reverse .about-image {
  margin-left: 20px;
  margin-right: 0;
}

.diminuir {
  max-width: 3%;
  max-height: 3%;
}

.github-users {
  display: flex;
  justify-content: space-around;
  margin-top: 20px;
}

.github-user {
  text-align: center;
  margin-bottom: 30px;
  margin-top: 20px;
}

.github-user img {
  width: 100px;
  height: 100px;
  border-radius: 50%;
}

.user-details img {
  width: 24px;
  height: 24px;
}

.user-details p {
  margin-top: 10px;
}
</style>