<template>
    <ApplicationHeader />
    <main>
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
        }
    },
    components: {
        ApplicationHeader,
        NoteCard,
        NoteCreateForm
    }
}
</script>
