<template>
  <div class="general-layout">
    <HeaderComponent class="header" />
    <section>
      <router-view />
    </section>
  </div>
</template>

<script>
import HeaderComponent from "@/views/layout/HeaderComponent.vue";

export default {
  name: "GeneralLayout",
  components: { HeaderComponent },
}; 
</script>

<style scoped lang="scss">
.general-layout {
  display: grid;
  grid-template-rows: 0.1fr 1fr;

  height: 100vh;
  overflow-y: hidden;

  background: url("../../assets/fondo.png") no-repeat center;
  background-size: cover;
}

.header {
  grid-column: 1 / 3;
  grid-row: 1 / 2;
}

section {
  grid-row: 2/4;
  grid-column: 1/3;
  overflow-y: hidden;
}

</style>
