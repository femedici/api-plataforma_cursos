// src/store/index.js

import { createStore } from 'vuex';
import userModule from './user'; // Importe o módulo do usuário
import VuexPersist from 'vuex-persist';

const vuexLocalStorage = new VuexPersist({
  key: 'lamoon-user', // Nome chave para os dados armazenados
  storage: window.sessionStorage, // Use 'sessionStorage' se preferir persistir apenas durante a sessão
  modules: ['user'], // Módulos que você deseja persistir
});


const store = createStore({
  modules: {
    user: userModule,
  },
  plugins: [vuexLocalStorage.plugin],
});

export default store;

