import { createApp } from "vue"
import App from "./App.vue"
import router from "./router"
import store from "./store"
import UI from "./components/UI"
import "./assets/css/style.css"


await store.dispatch("updateAuth")

const app = createApp(App)

UI.forEach(c => app.component(c.name, c))

app.use(store).use(router).mount("#app")
