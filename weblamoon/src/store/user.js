// store/user.js

const state = {
    user: null, // Armazenará as informações do usuário logado
};

const mutations = {
    SET_USER(state, user) {
        state.user = user;
    },
};

const actions = {
    setUser({ commit }, user) {
        commit("SET_USER", user);
    },
};

const getters = {
    getUser: (state) => state.user,
    getUserName: (state) => (state.user ? state.user.name : null), // Getter para o nome do usuário
    getUserEmail: (state) => (state.user ? state.user.email : null), // Getter para o email do usuário
    getUserDate: (state) => (state.user ? state.user.creationDate : null),
};

export default {
    state,
    mutations,
    actions,
    getters,
};
