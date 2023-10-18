<template>
  <v-parallax class="object-cover"
    src="https://images.unsplash.com/photo-1451187580459-43490279c0fa?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2072&q=80">
    <div class="page">
      <div class="content">
        <div class="text-left">
          <h1>LaMoon</h1>
          <p>Onde o seu conhecimento não tem limite!</p>
        </div>
        <div class="imagem-com-relevo">
          <img class="imagem-com-relevo-inner"
            src="https://images.unsplash.com/photo-1513258496099-48168024aec0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80" />
        </div>
      </div>
      <div class="card-list">
        <router-link v-for="(card, index) in cards" :to="'/courses/' + card.link" :key="index">
          <div class="card">
            <div class="card-image">
              <img class="card-image-inner" :src="card.imageURL" alt="Imagem do curso" />
            </div>
            <div class="card-details">
              <h3>{{ card.title }}</h3>
              <p>{{ card.description }}</p>
            </div>
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
        {
          "title": "Desenvolvimento WEB",
          "description": "Descrição do curso de DEV Web",
          "link": "desweb",
          "imageURL": "https://classic.exame.com/wp-content/uploads/2017/09/programac3a7c3a3o.jpg?quality=70&strip=info&w=1024"
        },
        {
          "title": "Manutenção de Computadores",
          "description": "Descrição do curso de manutenção",
          "link": "manu1",
          "imageURL": "https://classic.exame.com/wp-content/uploads/2017/09/programac3a7c3a3o.jpg?quality=70&strip=info&w=1024"
        },
        {
          "title": "Manutenção de Celulares",
          "description": "Descrição do curso de manutenção",
          "link": "manu2",
          "imageURL": "https://classic.exame.com/wp-content/uploads/2017/09/programac3a7c3a3o.jpg?quality=70&strip=info&w=1024"
        }
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

.card-list {
  display: flex;
  justify-content: center;
  margin-top: 20px;
}

.horizontal-cards {
  display: flex;
  overflow-x: auto;
}

.card {
  display: flex;
  border-radius: 8px;
  flex-direction: column;
  border: 1px solid #ccc;
  margin: 10px;
  padding: 10px;
  max-width: 80%;
  align-items: center;
}

.card-details {
  flex: 1;
  padding: 10px;
  text-align: center;
}

.card-image {
  flex: 1;
  text-align: center;
  padding: 10px;
}

.card-image-inner {
  max-width: 100%;
}

.imagem-com-relevo {
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
  transform: scale(1.1);
  border-radius: 12px;
  max-width: 40%;
  margin-top: 30px;
}

.imagem-com-relevo-inner {
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
  border-radius: 8px;
  max-width: 90%;
  margin-top: 20px;
}

h1 {
  font-size: xx-large;
}
</style>