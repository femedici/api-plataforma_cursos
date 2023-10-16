// src/store/index.js

import { createStore } from 'vuex';
import userModule from './user'; // Importe o módulo do usuário

const store = createStore({
  modules: {
    user: userModule,
    // Outros módulos, se houver
  },
});

export default store;
