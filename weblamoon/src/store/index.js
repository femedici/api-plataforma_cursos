// store/index.js

import Vue from "vue";
import Vuex from "vuex";
import userModule from "./user"; // Importe o módulo do usuário

Vue.use(Vuex);

export default new Vuex.Store({
    modules: {
        user: userModule, // Registre o módulo do usuário
        // Outros módulos, se houver
    },
});
