<template>
  <div class="user-profile">
    <div class="user-details">
      <h1>Dados do Usuário</h1>
      <div class="profile-container">
        <img class="profile-image" :src="currentProfileImageUrl" alt="Foto de Perfil">
        <span class="edit-profile-icon" @click="openEditProfilePopup">✎</span>
      </div>
      <p class="text-left"><strong>Nome do usuário:</strong> {{ getUserName }}</p>
      <p class="text-left"><strong>Email do usuário:</strong> {{ getUserEmail }}</p>
      <p class="text-left"><strong>Data de criação do usuário:</strong> {{ getUserDate }}</p>
    </div>

    <div class="button-container">
      <router-link :to="'/alter-user/' + user.cpf" class="button">Alterar Usuário</router-link>
      <button type="button" @click="confirmDeleteUser" class="button delete-button">Deletar Usuário</button>
    </div>
    <edit-profile-popup v-if="showEditProfilePopup" @close="closeEditProfilePopup"></edit-profile-popup>
  </div>
</template>
  
<script>
import EditProfilePopup from './UserPic.vue';
import axios from '@/../src/axios';
import router from '@/routes';
import { mapGetters } from 'vuex';

export default {
  components: {
    'edit-profile-popup': EditProfilePopup,
  },
  data() {
    return {
      showEditProfilePopup: false,
      currentProfileImageUrl: 'https://static.vecteezy.com/system/resources/previews/020/911/739/non_2x/user-profile-icon-profile-avatar-user-icon-male-icon-face-icon-profile-icon-free-png.png',
      user: {
        cpf: '',
      },
    };
  },
  computed: {
    ...mapGetters('user', ['getUserName', 'getUserEmail', 'getUserDate']), // Mapeando os getters do módulo 'user'
  },
  methods: {
    deleteUser(cpf) {
      axios.delete(`/User/${cpf}`)
        .then(response => {
          this.user = response.data;
          window.alert('Usuário deletado com sucesso!');
          router.push(`/list-users`);
        })
        .catch(error => {
          console.error("Erro ao buscar detalhes do curso:", error);
        });
    },
    confirmDeleteUser() {
      const shouldDelete = window.confirm("Tem certeza de que deseja deletar este usuário?");

      if (shouldDelete) {
        this.deleteUser(this.user.cpf);
      }
    },

    openEditProfilePopup() {
      this.showEditProfilePopup = true;
    },
    closeEditProfilePopup() {
      this.showEditProfilePopup = false;
    },
  },
};
</script>
  
<style scoped>
.text-left {
  text-align: left;
}

.user-profile {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.user-details {
  margin: 20px;
  text-align: center;
  border: 1px solid #ccc;
  padding: 20px;
  background-color: #000000;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.button {
  background-color: #007BFF;
  color: #fff;
  padding: 10px 20px;
  margin: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  text-decoration: none;
  text-align: center;
}

.delete-button {
  background-color: #FF5733;
}

.button:hover {
  background-color: #0056b3;
}

button:hover.delete-button {
  background-color: #cc3e22;
}

.profile-container {
  position: relative;
  display: inline-block;
}

.profile-image {
  width: 100px;
  height: 100px;
  border-radius: 50%;
}

.edit-profile-icon {
  position: absolute;
  top: 0;
  right: 0;
  font-size: 20px;
  cursor: pointer;
}
</style>