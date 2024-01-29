import { createStore } from "vuex"
import AuthService from "@/services/AuthService.js"

export default createStore({
    state: {
        isAuth: false,
        accessToken: null
    },
    getters: {
    },
    mutations: {
        setIsAuth(action, payload) {
            action.isAuth = payload
        },
        setAccessToken(action, payload) {
            action.accessToken = payload
        }
    },
    actions: {
        updateAuth: async (context) => {
            if (localStorage.refreshToken) {
                try {
                    const data = await AuthService.refresh(localStorage.refreshToken)
                    localStorage.refreshToken = data.refreshToken
                    context.commit("setAccessToken", data.accessToken)
                    context.commit("setIsAuth", true)
                    return
                }
                catch (e) {
                    console.log(e)
                }
            }
            delete localStorage.refreshToken
            context.commit("setIsAuth", false)
            context.commit("setAccessToken", null)
        }
    },
    modules: {
    }
})
