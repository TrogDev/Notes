<template>
    <form class="note-card" @submit.prevent="createNote">
        <div class="note-card__header">
            <input type="text" class="note-card__header__title" v-model="title" placeholder="Заголовок . . .">
        </div>
        <div class="note-card__main">
            <textarea class="note-card__main__description" v-model="description" placeholder="Описание . . ."></textarea>
        </div>
        <div class="note-card__footer">
            <primary-button type="sumbit" class="note-card__footer__button">Создать</primary-button>
        </div>
    </form>
</template>

<style>
.note-card__footer__button {
    width: 100%;
}
</style>

<script>
import NoteService from "@/services/NoteService.js"

export default {
    data() {
        return {
            title: "",
            description: ""
        }
    },
    emits: ["created"],
    methods: {
        async createNote() {
            await NoteService.create(this.title, this.description)
            this.$emit("created")
            this.title = ""
            this.description = ""
        }
    }
}
</script>