import axios from '@/../src/axios'; 

export default {
  data() {
    return {
      data: [],
      error: null,
    };
  },    
  methods: {
    fetchData() {
      axios.get('/User')
        .then(response => {
          this.data = response.data;
          this.error = null;
        })
        .catch(error => {
          this.data = [];
          this.error = error.message;
        });
    },
  },
};