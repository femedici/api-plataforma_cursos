<template>
  <div class="container-pres">
    <div class="presentation">
      <div class="pres-text">
        <img alt="LaMoon Logo" src="./assets/logo.png">
        <h1 class="pres-text">LaMoon Cursos.</h1>
      </div>
    </div>
    <HelloWorld />
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'App',
  components: {
    HelloWorld
  }
}
</script>

<style>
.container-pres {
  width: 100%;
  height: 100vh;
  display: flex;
  flex-direction: row;
  z-index: 1;

}

.presentation {
  background-image: linear-gradient(to top, #218380 0%, #73D2DE 100%);
  color: aliceblue;
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

.pres-text>h1 {
  font-family: 'Dosis', sans-serif;
  text-transform: uppercase;
  font-size: 250%;
  margin: .5rem;
  z-index: 2;
  text-align: center;
}
</style>
