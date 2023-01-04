<template>
    <div class="wrapper-paginator">
        <div class="paginator">
            <input class="button"
                type="submit" 
                value="<"
                @click="previousPage"
                :disabled= "isFirstPage"
                :class="{disabled: isFirstPage }" 
            />
            <input class="button"
                type="submit" 
                value=">"
                @click="nextPage"
                :disabled= "isLastPage"
                :class="{disabled: isLastPage }" 
            />
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
    name: "PaginatorComponent",
    props: {
        isFirstPage: {
            type: Boolean,
            requiered: true
        },
        isLastPage: {
            type: Boolean,
            requiered: true
        }
    },
    setup(props, context) {

        function nextPage(): void {
            context.emit("nextPage");

        }

        function previousPage(): void {
            context.emit("previousPage");
        }

        return { nextPage, previousPage};
    }
})
</script>

<style >


.paginator {
    display: flex;
    flex-direction: row;
    justify-content: center;
    margin-top: 1rem;
}

.button {
  background-color: #004AAD;
  padding: 0.1rem 0.4rem;
  color: #ffffff;
  font-size: 1rem;
  outline: none;
  border: none;
  border-radius: 0.3rem;
  cursor: pointer;
  margin-right: 1rem;
}

.disabled {
  background-color: #416ea8;
  padding: 0.1rem 0.4rem;
  color: #ffffff;
  font-size: 1rem;
  outline: none;
  border: none;
  border-radius: 0.3rem;
  cursor: not-allowed;
  margin-right: 1rem;
}
</style>