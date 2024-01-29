<template>
    <form class="auth-form" @submit.prevent="register">
        <div class="auth-from__input-wrapper">
            <primary-input @input="validateEmail" placeholder="Email" :isError="errors.email.length" v-model="email" />
            <small class="auth-form__error" v-if="errors.email.length">
                {{ errors.email.join("\n") }}
            </small>
        </div>
        <div class="auth-from__input-wrapper">
            <primary-input @input="validatePassword" placeholder="Пароль" type="password" :isError="errors.password.length" v-model="password"
                autocomplete="off" />
            <small class="auth-form__error" v-if="errors.password.length">
                {{ errors.password.join("\n") }}
            </small>
        </div>
        <div class="auth-from__input-wrapper">
            <primary-input @input="validatePasswordRepeat" placeholder="Повторите пароль" type="password" :isError="errors.passwordRepeat.length"
                v-model="passwordRepeat" autocomplete="off" />
            <small class="auth-form__error" v-if="errors.passwordRepeat.length">
                {{ errors.passwordRepeat.join("\n") }}
            </small>
        </div>
        <primary-button type="sumbit" class="auth-form__button">Создать аккаунт</primary-button>
    </form>
</template>

<script>
import AuthService from "@/services/AuthService"

export default {
    data() {
        return {
            email: "",
            password: "",
            passwordRepeat: "",
            errors: {
                email: [],
                password: [],
                passwordRepeat: []
            }
        }
    },
    methods: {
        async register() {
            if (!this.isValidForm()) return

            try {
                await AuthService.register(this.email, this.password)
                const data = await AuthService.login(this.email, this.password)
                localStorage.refreshToken = data.refreshToken
                await this.$store.dispatch("updateAuth")
                this.$router.push("/me")
            }
            catch (e) {
                console.log(e)
                this.errors.email = ["Данный email уже используется"]
            }
        },
        isValidForm() {
            this.validateEmail()
            this.validatePassword()
            this.validatePasswordRepeat()
            return !Object.entries(this.errors).some(([, value]) => value.length)
        },
        validateEmail() {
            if (this.email.length === 0) {
                this.errors.email = ["Поле обязательно для заполнения"]
            }
            else if (!this.email.match(
                /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            )) {
                this.errors.email = ["Некорректный email"]
            }
            else {
                this.errors.email = []
            }
        },
        validatePassword() {
            if (this.password.length === 0) {
                this.errors.password = ["Поле обязательно для заполнения"]
            }
            else if (this.password.length < 6) {
                this.errors.password = ["Пароль слишком короткий"]
            }
            else {
                this.errors.password = []
            }
        },
        validatePasswordRepeat() {
            if (this.passwordRepeat.length === 0) {
                this.errors.passwordRepeat = ["Поле обязательно для заполнения"]
            }
            else if (this.password != this.passwordRepeat) {
                this.errors.passwordRepeat = ["Пароли не совпадают"]
            }
            else {
                this.errors.passwordRepeat = []
            }
        },
    }
}
</script>