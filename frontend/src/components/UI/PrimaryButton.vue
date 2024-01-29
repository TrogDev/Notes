<template>
    <button class="primary-button">
        <slot></slot>
    </button>
</template>

<style>
.primary-button {
    padding: 10px 15px;
    background-color: var(--primary);
    border-radius: 10px;
    border: none;
    font-size: 14px;
    font-weight: 400;
    cursor: pointer;
    color: var(--window-background);
}

.primary-button:hover {
    text-decoration: underline;
}
</style>

<script>
export default {
    name: "primary-button"
}
</script>
