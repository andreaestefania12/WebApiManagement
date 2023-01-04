<template>
  <div class="modal">
    <div class="wrapper">
      <img v-bind:src="require('@/assets/error.png')" alt="" />
      <p>{{ message }}</p>

      <input
        type="submit"
        value="Cerrar"
        class="admin-submit button modal-button"
        @click="closeError"
      />
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "ModalError",
  props: {
    message: {
      type: String,
      default: "",
    },
    error: {
      type: Boolean,
      default: false,
    },
  },
  setup(props: any, context: any) {
    function closeError() {
      context.emit("update:error", false);
    }

    return {
      closeError,
    };
  },
});
</script>

<style scoped lang="scss">
@import "/src/styles/submit";
.modal {
    position: fixed;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  background: rgba(0, 0, 0, 0.8);
  display: flex;
  z-index: 3;
  align-items: center;
  justify-content: center;
  -webkit-transition: opacity 400ms ease-in;
  -moz-transition: opacity 400ms ease-in;
  transition: opacity 400ms ease-in;
}
.button{
  width: 57%;
}
.wrapper {
  padding: 1rem;
  border-radius: 1rem;
  background: white;
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 50%;
}
img {
  width: 6rem;
}
p {
  font-size: 1.2rem;
  padding: 1.5rem;
  text-align: center;
  color: #001129;
}
</style>
