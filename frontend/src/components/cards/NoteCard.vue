<template>
    <div class="note-card">
        <div class="note-card__header">
            <input @focusout="updateNote" type="text" class="note-card__header__title" v-model="title"
                placeholder="Заголовок . . .">
            <button class="note-card__header__delete-button" @click="deleteNote">
                <img src="@/assets/img/close.svg" alt="close">
            </button>
        </div>
        <div class="note-card__main">
            <textarea @focusout="updateNote" class="note-card__main__description" v-model="description"></textarea>
        </div>
        <div class="note-card__footer">
            <small class="note-card__footer__date">{{ new Date(note.createdAt).toLocaleString("ru-RU") }}</small>
        </div>
    </div>
</template>

<style>
.note-card {
    width: 400px;
    padding: 15px;
    border-radius: 15px;
    background-color: var(--window-background);
    display: flex;
    flex-direction: column;
}

.note-card__header {
    padding: 0 0 8px 0;
    border-bottom: 1px solid var(--primary);
    display: flex;
    justify-content: space-between;
    gap: 5px;
}

.note-card__header__title {
    font-size: 16px;
    color: var(--primary);
    font-weight: 600;
    border: none;
    background: none;
    width: 100%;
}

.note-card__header__title:focus {
    outline: none;
}

.note-card__header__title::placeholder {
    color: var(--additional-text-color);
}

.note-card__header__delete-button {
    background: none;
    border: none;
    width: 20px;
    height: 20px;
    cursor: pointer;
}

.note-card__header__delete-button>img {
    width: 100%;
    height: 100%;
}

.note-card__main {
    padding: 8px 0;
    height: 100%;
}

.note-card__main__description {
    font-size: 14px;
    font-weight: 400;
    color: var(--text-color);
    background: none;
    border: none;
    width: 100%;
    resize: none;
    height: 250px;
}

.note-card__main__description:focus {
    outline: none;
}

.note-card__footer {
    padding: 8px 0 0 0;
    border-top: 1px solid var(--primary);
}

.note-card__footer__date {
    font-size: 12px;
    color: var(--additional-text-color);
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
    created() {
        this.title = this.note.title
        this.description = this.note.description
    },
    props: {
        note: {
            type: Object,
            required: true
        }
    },
    emits: ["updated"],
    methods: {
        async deleteNote() {
            await NoteService.delete(this.note.id)
            this.$emit("updated")
        },
        async updateNote() {
            try {
                await NoteService.update(this.note.id, this.title, this.description)
            }
            catch (e) {
                this.title = this.note.title
                this.description = this.note.description
            }
            this.$emit("updated")
        }
    }
}
</script>