<template>
  <v-layout class="">

    <v-navigation-drawer class="bg-[#0c1922]">
      <SideBar /> 
    </v-navigation-drawer>

    <v-main class="bg-[121f28]">
      <router-view></router-view>
    </v-main>
  </v-layout>
</template>

<script>
import SideBar from './components/SideBar.vue'

export default {
  name: 'App',
  components: { SideBar},
  data: () => ({
    //
  }),
} 
</script>
