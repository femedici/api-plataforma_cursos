<template>
    <v-parallax class="object-cover"
        src="https://images.unsplash.com/photo-1451187580459-43490279c0fa?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2072&q=80">
        <div class="page">
    <div class="content">
      <div class="text-left">
        <h1>LaMoon</h1>
        <p>Onde o limite do seu conhecimento é o limite!</p>
      </div>
      <div class="image-right">
        <img class="imagem-com-relevo" src="https://images.unsplash.com/photo-1513258496099-48168024aec0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80"/>
      </div>
    </div>
    <div class="card-list">
    <router-link
      v-for="(card, index) in cards"
      :to="'/courses/' + card.link"
      :key="index"
    >
      <div class="card">
        <h3>{{ card.title }}</h3>
        <p>{{ card.description }}</p>
      </div>
    </router-link>
  </div>
  </div>
</v-parallax>
</template>

<script>
export default {
  name: "App",
  data() {
    return {
      cards: [
        { title: "Desenvolvimento WEB", description: "Descrição do curso de DEV Web", link: "desweb"},
        { title: "Manutenção de Computadores", description: "Descrição do curso de manutenção", link: "manu1" },
        { title: "Manutenção de Celulares", description: "Descrição do curso de manutenção", link: "manu2" },
      ],
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

.text-left {
  width: 50%;
  padding: 20px;
  text-align: center;
  align-self: center;
}

.image-right {
  width: 50%;
  float: right;
  margin-top: 40px;
}

.card-list {
  display: flex;
  justify-content: center;
  margin-top: 20px;
}

.card {
  border: 1px solid #ccc;
  margin: 10px;
  padding: 10px;
}
.imagem-com-relevo {
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
  transform: scale(1.1);
  border-radius: 8px; 
  max-width: 90%;
}
</style>