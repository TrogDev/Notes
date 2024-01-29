<template>
    <ApplicationHeader />
    <main>
        <primary-button class="export-button" @click="exportNotes">Скачать в Excel</primary-button>
        <div class="notes container">
            <NoteCreateForm @created="setNotes" />
            <NoteCard v-for="note in notes" :key="note.id" :note="note" @updated="setNotes" />
        </div>
    </main>
</template>

<style scoped>
main {
    margin-top: 25px;
}

.notes {
    display: flex;
    gap: 15px;
    flex-wrap: wrap;
    justify-content: center;
    margin-top: 15px;
}

.export-button {
    margin: auto;
    display: block;
}
</style>

<script>
import NoteService from "@/services/NoteService.js"
import ApplicationHeader from "@/components/partials/ApplicationHeader.vue"
import NoteCard from "@/components/cards/NoteCard.vue"
import NoteCreateForm from "@/components/forms/NoteCreateForm.vue"

export default {
    data() {
        return {
            notes: []
        }
    },
    created() {
        if (!this.$store.state.isAuth) {
            this.$router.push("/auth")
        }
        this.setNotes()
    },
    methods: {
        async setNotes() {
            this.notes = await NoteService.getList()
        },
        async exportNotes() {
            const response = await NoteService.export()
            let blob = new Blob([response.data])
            let link = document.createElement('a')
            link.href = window.URL.createObjectURL(blob)
            link.download = 'Notes.xls'
            link.click()
        }
    },
    components: {
        ApplicationHeader,
        NoteCard,
        NoteCreateForm
    }
}
</script>
