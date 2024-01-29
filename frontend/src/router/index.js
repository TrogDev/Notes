import { createRouter, createWebHistory } from "vue-router"
import store from "@/store"
import UnathorizedView from "../views/UnathorizedView.vue"
import NotesView from "../views/NotesView.vue"
import LoginView from "../views/LoginView.vue"
import RegisterView from "../views/RegisterView.vue"

const routes = [
    {
        path: "/",
        redirect: () => {
            if (store.state.isAuth) {
                return {
                    path: "/me"
                }
            }
            else {
                return {
                    path: "/auth"
                }
            }
        }
    },
    {
        path: "/auth",
        component: UnathorizedView,
        children: [
            {
                path: "login",
                component: LoginView
            },
            {
                path: "register",
                component: RegisterView
            }
        ]
    },
    {
        path: "/me",
        component: NotesView,
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

router.beforeEach(async (to, _, next) => {
    return next()
})

export default router
