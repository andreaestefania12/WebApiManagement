<template>
        <input
         class="input-search"
         :placeholder="message"
            id="searcher"
            type="text"
            @input="handleSearch"
        />
</template>

<script lang="ts">
import Vue, { defineComponent } from 'vue'
export default defineComponent({
    name: "SearchFormsComponent",
    props: {
    message: {
      type: String,
      default: "",
    },
  },
    setup(props, context) {
        
        function handleSearch(event: any){
            context.emit("update:search", event.target.value)
        }

        return {
            handleSearch
        }
    }


})
</script>

<style lang="scss">

.input-search {
    display: flex;
    width: 50% !important;
    height: 1.5rem;
    border-radius: 0.4em;
    overflow: hidden;
    border: 1px solid #001129;
    padding: 10px;
    box-shadow: 1px 1px 10px #aaaaaa;

}
</style>