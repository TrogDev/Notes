<template>
    <main>
        <div class="auth-window">
            <div class="auth-window__header">
                <h2 class="auth-window__header__logo">
                    Notes
                </h2>
                <p class="auth-window__header__description">
                    Авторизуйтесь, для использования системы
                </p>
            </div>
            <div class="auth-window__main">
                <router-view />
            </div>
            <div class="auth-window__footer">
                <router-link class="auth-window__footer__button" to="/auth/login" active-class="active">
                    <primary-button>Вход</primary-button>
                </router-link>
                <router-link class="auth-window__footer__button" to="/auth/register" active-class="active">
                    <primary-button>Регистрация</primary-button>
                </router-link>
            </div>
        </div>
    </main>
</template>

<style scoped>
main {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100dvh;
    width: 100%;
}

.auth-window {
    background-color: var(--window-background);
    border-radius: 20px;
    width: 438px;
    padding: 20px;
    display: flex;
    flex-direction: column;
    gap: 15px;
}

.auth-window__header__logo {
    text-align: center;
    color: var(--primary);
    text-align: center;
    font-size: 32px;
    font-weight: 400;
}

.auth-window__header__description {
    color: var(--text-color);
    text-align: center;
    font-size: 14px;
    font-weight: 400;
    margin-top: 15px;
}

.auth-window__footer {
    display: flex;
    justify-content: space-between;
}

.auth-window__footer__button {
    width: 48%;
}

.auth-window__footer__button>button {
    background-color: var(--field-background);
    color: var(--text-color);
    width: 100%;
}

.auth-window__footer__button.active>button {
    border: 1px solid var(--primary);
}
</style>

<script>
export default {
    created() {
        if (this.$store.state.isAuth) {
            this.$router.push("/me")
        }
    }
}
</script>
