<template>
      <input
        type="text"
        @input="emitChangeValue"
        :value="value"
      />
</template>

<script lang="ts">
import { defineComponent, ref, Ref } from "vue";

export default defineComponent({
  name: "InputFormsComponent",
  props: {
    value: {
      type: String,
      default: "",
    },
  },
  setup(props, context) {
    const date: Ref<string> = ref("");

    function emitChangeValue(event: any) {
      context.emit("update:value", event.target.value);
    }

    return { date, emitChangeValue };
  },
});
</script>

<style lang="scss" scoped>
  .input-modal{
    width: 100%;
  }
</style>

