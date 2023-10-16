<template>
  <v-layout class="">

    <v-navigation-drawer class="bg-[#101828]">
      <SideBar /> 
    </v-navigation-drawer>

    <v-main class="">
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
