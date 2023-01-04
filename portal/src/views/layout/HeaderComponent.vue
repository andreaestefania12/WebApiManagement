<template>
  <header class="wrapper-header">
    <ul class="options">
      <li class="option">
        <p>Administración del personal</p>
      </li>
    </ul>
  </header>
</template>

<script>
export default {
  name: "HeaderComponent",
};
</script>

<style scoped lang="scss">
.wrapper-header {
  background-image: url("../../assets/Header.png") ;
  .logo {
    height: 3rem;
  }
}

.options {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-top: 0.5rem;
  margin-left: 1rem;

  .option {
    display: flex;
    align-items: center;
    justify-content: center;
    margin-right: 2rem;
    

    .option-image {
      height: 1.5rem;
    }

    &:hover {
      text-shadow: 2px 2px 4px #3f39397f;
    }
  }
}
</style>
