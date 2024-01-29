import axios from "axios"
import store from "@/store"

const NoteService = {
    async getList() {
        const response = await axios.get("/api/notes", {
            headers: {
                Authorization: `Bearer ${store.state.accessToken}`
            }
        })
        return response.data
    },
    async delete(id) {
        await axios.delete(`/api/notes/${id}`, {
            headers: {
                Authorization: `Bearer ${store.state.accessToken}`
            }
        })
    },
    async update(id, title, description) {
        const data = new FormData()
        data.append("title", title)
        data.append("description", description)
        await axios.put(`/api/notes/${id}`, data, {
            headers: {
                Authorization: `Bearer ${store.state.accessToken}`
            }
        })
    },
    async create(title, description) {
        const data = new FormData()
        data.append("title", title)
        data.append("description", description)
        await axios.post("/api/notes", data, {
            headers: {
                Authorization: `Bearer ${store.state.accessToken}`
            }
        })
    },
    async export() {
        const response = await axios.get("/api/notes/export", {
            headers: {
                Authorization: `Bearer ${store.state.accessToken}`
            },
            responseType: "arraybuffer"
        })
        return response
    }
}

export default NoteService