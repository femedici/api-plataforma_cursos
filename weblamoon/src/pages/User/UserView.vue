<template>
  <div class="user-profile">
    <div class="profile-img">
      <div class="user-top">
        <div class="user-image-container" @mouseover="showChangeImageButton = true"
          @mouseleave="showChangeImageButton = false">
          <img class="user-image" :src="currentProfileImageUrl" alt="Foto de Perfil">
          <button class="change-image-button" @click="openEditProfilePopup" v-if="showChangeImageButton">Alterar
            Foto</button>
        </div>
        <div class="user-name">
          {{ getUserName }}
        </div>
      </div>
      <div class="action-bar">
        <a @click="openChangePasswordPopup"
          class="inline-flex items-center  justify-center px-5 py-3 text-base font-medium text-center text-white border border-gray-300 rounded-lg hover:bg-teal-400 focus:ring-4 focus:ring-gray-100">
          Alterar Senha
        </a>
      </div>
    </div>
    <div class="profile-info">
      <div class="user-card">
        <p><strong>Nome:</strong> </p>
        <input class="input-field" type="text" v-model="getUserName" readonly />
        <p><strong>Email do usuário:</strong> </p>
        <input class="input-field" type="text" v-model="getUserEmail" readonly />
        <p><strong>Data de criação do usuário:</strong> </p>
        <input class="input-field" type="text" v-model="getUserDate" readonly />
      </div>
    </div>
    <edit-profile-popup v-if="showEditProfilePopup" @close="closeEditProfilePopup"></edit-profile-popup>
    <change-password-popup v-if="showChangePasswordPopup" @close="closeChangePasswordPopup"></change-password-popup>
  </div>
</template>

<script>
import EditProfilePopup from './UserPic.vue';
import ChangePasswordPopup from './UserPass.vue';
import axios from '@/../src/axios';
import router from '@/routes';
import { mapGetters } from 'vuex';

export default {
  components: {
    'edit-profile-popup': EditProfilePopup,
    'change-password-popup': ChangePasswordPopup,
  },
  data() {
    return {
      showChangeImageButton: false,
      showEditProfilePopup: false,
      showChangePasswordPopup: false,
      currentProfileImageUrl: 'https://static.vecteezy.com/system/resources/previews/020/911/739/non_2x/user-profile-icon-profile-avatar-user-icon-male-icon-face-icon-profile-icon-free-png.png',
      user: {
        cpf: '',
      },
    };
  },
  computed: {
    ...mapGetters('user', ['getUserName', 'getUserEmail', 'getUserDate']),
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
    openChangePasswordPopup() {
      this.showChangePasswordPopup = true;
    },
    closeChangePasswordPopup() {
      this.showChangePasswordPopup = false;
    },
  },
};
</script>

<style scoped>
.user-profile {
  color: #fff;
  display: flex;
  flex-direction: row;
  align-items: flex-start;
  padding: 20px;
}

.profile-img {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  background-color: #082f49;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  margin: 20px;
}

.profile-info {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  background-color: #082f49;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  margin: 20px;
  width: 100vh;
  height: flex;
}

.user-card {
  margin-top: 10px;
  margin-left: 10px;
  color: #fff;
}

.user-top {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: left;
  margin-bottom: 20px;
  margin-left: 20px;
}

.user-image-container {
  position: relative;
  width: 100px;
  height: 100px;
  border-radius: 50%;
  overflow: hidden;
}

.user-image {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.change-image-button {
  position: absolute;
  top: 0px;
  bottom: 0px;
  /* Ajuste a posição superior conforme necessário */
  right: 0px;
  /* Ajuste a posição à direita conforme necessário */
  background-color: #007bff6c;
  color: #fff;
  padding: 5px 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.action-button {
  width: 100%;
  background-color: #fee754;
  color: #fff;
  padding: 10px 20px;
  margin: 10px 0;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  text-align: center;
}

.delete-button {
  background-color: #FF5733;
}

.action-button:hover {
  background-color: #0056b3;
}

.delete-button:hover {
  background-color: #cc3e22;
}

.input-field {
  background-color: #303030;
  border: 1px solid #1d1d1d;
  border-style: solid;
  color: #fff;
  border-radius: 8px;
  font-size: 16px;
  width: 250%;
  padding: 8px;

}

.action-bar {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}
</style>