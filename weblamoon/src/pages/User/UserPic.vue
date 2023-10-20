<template>
  <div class="edit-profile-popup">
    <h2>Editar Foto de Perfil</h2>
    <input v-model="icon" placeholder="Insira a URL da nova foto de perfil">
    <button @click="saveNewProfileImage">Salvar</button>
    <button @click="closePopup">Fechar</button>
  </div>
</template>
  
<script>
export default {
  data() {
    return {
      icon: '',
    };
  },
  methods: {
    saveNewProfileImage() {
      //Script pra trocar a img
      this.closePopup();
    },
    closePopup() {
      this.$emit('close');
    },
  },
};
</script>
  
<style scoped>
.edit-profile-popup {
  background-color: #fff;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  padding: 20px;
  width: 300px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  text-align: center;
}

.edit-profile-popup h2 {
  font-size: 1.2rem;
  margin-bottom: 10px;
}

.edit-profile-popup input {
  color: #000000;
  width: 100%;
  padding: 10px;
  margin-bottom: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.edit-profile-popup button {
  background-color: #007BFF;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-right: 10px;
}

.edit-profile-popup button:hover {
  background-color: #0056b3;
}
</style>