<template>
  <div class="container-login">
    <div class="login">
      <h2>Faça Seu Login</h2>
      <form class="login-form">
        <input id="login-itens" type="email" name="email" required placeholder="E-mail">
        <input id="login-itens" type="password" name="senha" required placeholder="Senha">
        <div class="keep-log">
          <label>
            <input class="checkbox" type="checkbox" name="checkbox">Permanecer conectado.
          </label>
        </div>
        <button>Entrar</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}

.login {
  display: flex;
  flex-direction: column;
  align-items: center;

}

.container-login {
  width: 50%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  z-index: 1;

}

.login h2 {
  font-family: 'Montserrat', sans-serif;
  font-size: 2rem;
  font-weight: bold;
  color: #007ec2;
}

.login-form {
  width: 60%;
  display: flex;
  flex-direction: column;
  align-items: center;
}

#login-itens {
  font-family: 'Dosis', sans-serif;
  width: 75%;
  margin: .5rem;
  padding: .5rem;
  border-width: 0 0 0 .4rem;
  border-style: solid;
  border-color: #24c4fa;
  background-color: rgb(237, 236, 236);

}

.login-form button {
  font-family: 'Dosis', sans-serif;
  text-transform: uppercase;
  width: 50%;
  margin: 1rem;
  padding: .6rem;
  border-style: none;
  border-radius: .3rem;
  background-color: #04befe;
  color: white;
  cursor: pointer;
}

.keep-log {
  width: 100%;
  font-family: 'Dosis', sans-serif;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  font-size: .8rem;
  margin: .3rem;
}

label {
  width: 100%;
  position: relative;
}

.checkbox {
  display: inline-block;
  align-self: self-end;
  margin-left: 300px;
}
</style>