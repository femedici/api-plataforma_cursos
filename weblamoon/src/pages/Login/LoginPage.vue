
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
    name: 'LoginPage',
    props: {
        msg: String
    }
}
</script>

<style src="./style.css"></style>