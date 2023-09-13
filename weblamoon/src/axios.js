import axios from 'axios';

const instance = axios.create({
  baseURL: 'https://localhost:7232', // Substitua pela URL do seu backend
});

export default instance;