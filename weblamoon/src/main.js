import { createApp } from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify';
import { loadFonts } from './plugins/webfontloader';
import router from './router';
import store from './pages/auth/store'; // Importe o Vuex store
import './assets/tailwind.css';
import AOS from 'aos';
import 'aos/dist/aos.css';

loadFonts();

const app = createApp(App);

app.config.globalProperties.$AOS = AOS;

app
  .use(vuetify)
  .use(router)
  .use(store) // Adicione o Vuex store usando o use method
  .use(AOS)
  .mount('#app');
