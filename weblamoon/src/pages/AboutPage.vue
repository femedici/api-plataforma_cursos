<template>
    <div class="about-us">
      <div class="about-content">
        <div class="about-section" v-for="(topic, key, index) in topics" :key="key">
          <div class="about-card">
            <h1>{{ topic.title }}</h1>
            <p>{{ topic.text }}</p>
          </div>
          <v-divider class="divider" v-if="index < Object.keys(topics).length - 1"></v-divider>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        topics: {
          "sobre-nos": {
            title: "Sobre Nós",
            text: "Bem-vindo à LaMoon, a plataforma líder em educação online! Nossa missão é tornar a aprendizagem acessível, conveniente e eficaz para todos, em qualquer lugar do mundo."
          },
          "nossa-equipe": {
            title: "Nossa Equipe",
            text: "Nossa equipe é composta por educadores, desenvolvedores, designers e entusiastas da educação. Estamos dedicados a criar a melhor experiência de aprendizagem online para nossos alunos. Se você tiver alguma dúvida ou precisar de suporte, nossa equipe de suporte está sempre pronta para ajudar."
          },
          "missao": {
            title: "Missão",
            text: "Nossa missão é capacitar indivíduos através da educação, tornando o conhecimento e as habilidades acessíveis a todos. Acreditamos que a educação é a chave para desbloquear oportunidades ilimitadas e estamos comprometidos em tornar a aprendizagem online eficaz e envolvente."
          },
          "visao": {
            title: "Visão",
            text: "Nossa visão é ser a principal plataforma global de educação online, oferecendo uma ampla gama de cursos de alta qualidade e recursos educacionais para alunos em todo o mundo. Estamos constantemente inovando e expandindo nossa oferta de cursos para atender às necessidades em evolução de nossos alunos."
          }
        }
      };
    }
  };
  </script>
  
  <style scoped>
  .about-us {
    text-align: center;
  }
  
  .about-card {
    background-color: #0a0736;
    border-radius: 8px;
    padding: 20px;
  }
  
  .divider {
    height: 2px; /* Altura menor do divisor */
    background-color: #ccc; /* Cor do divisor */
    margin: 10px 0; /* Espaçamento menor entre divisores */
  }
  p{
    margin-top: 30px;
  }
  /* Estilos adicionais conforme necessário */
  </style>