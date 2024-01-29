import axios from "axios"

const AuthService = {
    async register(email, password) {
        await axios.post("/api/register/", {
            email: email,
            password: password
        })
    },
    async login(email, password) {
        const response = await axios.post("/api/login/", {
            email: email,
            password: password
        })
        return response.data
    },
    async refresh(refreshToken) {
        const response = await axios.post("/api/refresh/", {
            refreshToken: refreshToken
        })
        return response.data
    }
}

export default AuthService