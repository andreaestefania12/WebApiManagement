<template>
  <ModalError v-show="hasError" v-model:error="hasError" :message="message" />
  <router-view/>
</template>

<script lang="ts">
import { defineComponent, onErrorCaptured, ref, Ref } from "vue";
import ModalError from "@/components/modals/ModalError.vue";

export default defineComponent({
  name: "App",
  components: {
    ModalError,
  },
  setup() {
    const hasError: Ref<boolean> = ref(false);
    const message: Ref<string> = ref("");
    onErrorCaptured((err: any, instance, details) => {
      hasError.value = true;
      message.value = JSON.parse(err.toString().substr(6)).error;
    });

    return {
      hasError,
      message,
    };
  },
});
</script>

<style lang="scss">
@import url("https://fonts.googleapis.com/css?family=Mulish");
* {
  margin: 0;
  box-sizing: border-box;
  padding: 0;
  list-style: none;
  font-family: "Mulish", sans-serif;
  color: #ffffff;
}
</style>
