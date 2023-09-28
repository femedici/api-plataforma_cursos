<template>
  <v-layout class="rounded rounded-md">
    <AppBar />
    <v-navigation-drawer expand-on-hover rail class="bg-grey-darken-3">
      <ProfileBar />
    </v-navigation-drawer>

    <v-main style="min-height: 300px;">
      <router-view></router-view>
    </v-main>
  </v-layout>
</template>

<script>
import ProfileBar from './components/ProfileBar.vue'
import AppBar from './components/AppBar.vue'

export default {
  name: 'App',
  components: { ProfileBar, AppBar },
  data: () => ({
    //
  }),
} 
</script>
