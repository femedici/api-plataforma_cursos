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
        commit('SET_USER', user);
    },
};

const getters = {
    getUser: (state) => state.user,
    getUserName: (state) => (state.user ? state.user.name : null),
    getUserEmail: (state) => (state.user ? state.user.email : null),
    getUserDate: (state) => (state.user ? state.user.creationDate : null),
    getUserID: (state) => (state.user ? state.user.id : null),
    getUserCreator: (state) => (state.user ? state.user.creator : null),
    getUserBecameCreator: (state) => (state.user ? state.user.becameCreator : null),
};

export default {
    namespaced: true, // Certifique-se de definir namespaced como true
    state,
    mutations,
    actions,
    getters,
};

