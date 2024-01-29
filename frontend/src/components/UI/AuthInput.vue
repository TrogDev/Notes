<template>
    <input :value="modelValue" @input="onUpdateValue" class="primary-input" :class="{ error: isError }">
</template>

<style>
.primary-input {
    background-color: var(--field-background);
    color: var(--text-color);
    font-size: 14px;
    font-weight: 400;
    line-height: 14px;
    border: none;
    padding: 7px 15px;
    border-radius: 7px;
}

.primary-input.error {
    outline: 1px solid var(--error);
}

.primary-input:focus {
    outline: none;
}

.primary-input::placeholder {
    color: var(--additional-text-color);
}
</style>

<script>
export default {
    name: "primary-input",
    props: {
        isError: {
            default: false
        },
        modelValue: {
            type: String,
            default: null
        }
    },
    methods: {
        onUpdateValue(event) {
            this.$emit("update:modelValue", event.target.value)
        }
    }
}
</script>