import { createApp } from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify';
import { loadFonts } from './plugins/webfontloader';
import router from './router';
import './assets/tailwind.css'

loadFonts();

const app = createApp(App);

app
  .use(vuetify)
  .use(router) // Add the router using the use method
  .mount('#app');
