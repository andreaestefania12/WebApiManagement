<template>
  <div class="modal">
    <div class="wrapper">
      <img v-bind:src="require('@/assets/success.png')" alt="" />
      <p>{{ message }}</p>
      <input
        type="submit"
        value="Aceptar"
        class="admin-submit button"
        @click="closeModal"
      />
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "ModalSuccess",
  props: {
    message: {
      type: String,
      default: "Error",
    },
  },
  setup(props: any, context: any) {
    function closeModal() {
      context.emit("closeSuccessModal");
    }

    return {
      closeModal,
    };
  },
});
</script>

<style scoped lang="scss">
@import "/src/styles/submit";
.button{
  width: 57%;
}
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
