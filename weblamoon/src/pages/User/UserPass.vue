<template>
  <div class="change-password-popup">
    <h2>Trocar Senha</h2>
    <input type="password" v-model="oldPassword" placeholder="Senha Antiga">
    <input type="password" v-model="newPassword" placeholder="Nova Senha">
    <input type="password" v-model="confirmPassword" placeholder="Confirmar Nova Senha">
    <button @click="changePassword">Trocar Senha</button>
    <button @click="closePopup">Fechar</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      oldPassword: '',
      newPassword: '',
      confirmPassword: ''
    };
  },
  methods: {
    changePassword() {
      if (this.newPassword === this.confirmPassword) {
        // Script pra trocar senha
        this.closePopup();
      } else {
        window.alert('As senhas não coincidem. Tente novamente.');
      }
    },
    closePopup() {
      this.$emit('close');
    }
  }
};
</script>

<style scoped>
.change-password-popup {
  background-color: #1d1d1d;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  padding: 20px;
  width: 500px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  text-align: center;
}

.change-password-popup h2 {
  font-size: 1.2rem;
  margin-bottom: 10px;
}

.change-password-popup input {
  color: #ffffff;
  width: 100%;
  padding: 10px;
  margin-bottom: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.change-password-popup button {
  background-color: #007BFF;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-right: 10px;
}

.change-password-popup button:hover {
  background-color: #0056b3;
}
</style>