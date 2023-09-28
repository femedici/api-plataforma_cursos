<template>
    <div class="flex flex-col items-center">
        <!-- Carousel -->
        <v-carousel :show-arrows="false" class="w-full">
            <v-carousel-item v-for="(item, i) in items" :key="i" :src="item.src" cover></v-carousel-item>
        </v-carousel>

        <!-- Button -->
        <v-btn to="/list-courses" @click="navigateTo('/list-courses')" class="ml-2 mr-6">Cursos</v-btn>
    </div>
</template>
  
<script>
export default {
    data() {
        return {
            items: [
                {
                    src: 'https://cdn.vuetifyjs.com/images/carousel/squirrel.jpg',
                },
                {
                    src: 'https://cdn.vuetifyjs.com/images/carousel/sky.jpg',
                },
                {
                    src: 'https://cdn.vuetifyjs.com/images/carousel/bird.jpg',
                },
                {
                    src: 'https://cdn.vuetifyjs.com/images/carousel/planet.jpg',
                },
            ],
        }
    },
}
</script>