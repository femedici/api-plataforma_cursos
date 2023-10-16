import { createApp } from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify';
import { loadFonts } from './plugins/webfontloader';
import router from './router';
import store from './pages/auth/store'; // Importe o Vuex store
import './assets/tailwind.css';

loadFonts();

const app = createApp(App);

app
  .use(vuetify)
  .use(router)
  .use(store) // Adicione o Vuex store usando o use method
  .mount('#app');
