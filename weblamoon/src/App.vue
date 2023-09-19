<script setup>
import NavigationBar from './components/NavigationBar.vue';
</script>


<template>
  <div class="app">
    <NavigationBar />
    <router-view />
  </div>
</template>   

<style>
.app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
}

.container-pres {
  width: 100%;
  height: 100vh;
  display: flex;
  flex-direction: row;
  z-index: 1;

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

.pres-text>h1 {
  font-family: 'Dosis', sans-serif;
  color: #690738 100%;
  text-transform: uppercase;
  font-size: 250%;
  margin: .5rem;
  z-index: 2;
  text-align: center;
}
</style>
