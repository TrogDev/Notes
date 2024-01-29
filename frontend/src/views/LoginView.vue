<template>
    <form class="auth-form" @submit.prevent="login">
        <div class="auth-from__input-wrapper">
            <primary-input placeholder="Email" :isError="errors.email.length" v-model="email" />
            <small class="auth-form__error" v-if="errors.email.length">
                {{ errors.email.join("\n") }}
            </small>
        </div>
        <div class="auth-from__input-wrapper">
            <primary-input placeholder="Пароль" type="password" :isError="errors.password.length" v-model="password" autocomplete="off" />
            <small class="auth-form__error" v-if="errors.password.length">
                {{ errors.password.join("\n") }}
            </small>
        </div>
        <primary-button type="sumbit" class="auth-form__button">Войти</primary-button>
    </form>
</template>

<script>
import AuthService from "@/services/AuthService"

export default {
    data() {
        return {
            email: "",
            password: "",
            errors: {
                email: [],
                password: []
            }
        }
    },
    methods: {
        async login() {
            try {
                const data = await AuthService.login(this.email, this.password)
                localStorage.refreshToken = data.refreshToken
                await this.$store.dispatch("updateAuth")
                this.$router.push("/me")
            }
            catch(e) {
                console.log(e)
                this.errors.email = ["Неправильный логин или пароль"]
                this.errors.password = ["Неправильный логин или пароль"]
            }
        }
    }
}
</script>