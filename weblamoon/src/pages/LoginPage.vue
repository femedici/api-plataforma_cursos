<template>
    <div class="flex flex-wrap">
        <div class="w-full md:w-1/2 p-4">
            <v-img :width="1400" aspect-ratio="1/1" cover
                src="https://cdn.vuetifyjs.com/images/parallax/material.jpg"></v-img>
        </div>

        <div class="w-full md:w-1/2 p-4">
            <v-card class="mx-auto pa-12 pb-8" elevation="8" max-width="448" rounded="lg">

                <div class="text-subtitle-1 text-medium-emphasis">Account</div>

                <v-text-field density="compact" placeholder="Email address" prepend-inner-icon="mdi-email-outline"
                    variant="outlined"></v-text-field>

                <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
                    Password

                    <a class="text-caption text-decoration-none text-blue" href="#" rel="noopener noreferrer"
                        target="_blank">
                        Forgot login password?</a>
                </div>

                <v-text-field :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'" :type="visible ? 'text' : 'password'"
                    density="compact" placeholder="Enter your password" prepend-inner-icon="mdi-lock-outline"
                    variant="outlined" @click:append-inner="visible = !visible"></v-text-field>

                <v-card class="mb-12" color="surface-variant" variant="tonal">
                    <v-card-text class="text-medium-emphasis text-caption">
                        Warning: After 3 consecutive failed login attempts, you account will be temporarily locked for three
                        hours. If you must login now, you can also click "Forgot login password?" below to reset the login
                        password.
                    </v-card-text>
                </v-card>

                <v-btn block class="mb-8" color="blue" size="large" variant="tonal">
                    Log In
                </v-btn>

                <v-card-text class="text-center">
                    <a class="text-blue text-decoration-none" href="/create-user" rel="noopener noreferrer" target="_blank">
                        Cadastrar <v-icon icon="mdi-chevron-right"></v-icon>
                    </a>
                </v-card-text>
            </v-card>
        </div>
    </div>
</template>


<script>
export default {
    data: () => ({
        visible: false,
    }),
}
</script>