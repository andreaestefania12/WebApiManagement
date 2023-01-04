<template>
  <div class="task-layout">
    <ModalSuccess
        v-show="showSuccessModal"
        :message="message"
        @closeSuccessModal="closeModal"
    />
    <div class="wrapper-form">
        <h3>Agregar un nuevo cliente</h3>
        <div class="forms-group">
            <p>Nombre</p>
            <InputFormsComponent  
              class="input-form"
              v-model:value="name.val"
              :value="name.val"
            />
            <p v-show="name.enabled" class="error-field">
            {{ name.errors[0] }}
            </p>
        </div>
        <div class="forms-group">
            <p>Apellido</p>
             <InputFormsComponent  
              class="input-form"
              v-model:value="lastName.val"
              :value="lastName.val"
            />
             <p v-show="lastName.enabled" class="error-field">
            {{ lastName.errors[0] }}
            </p>
        </div>
        
        <div class="forms-group">
            <p>Email</p>
            <InputFormsComponent  
              class="input-form"
              v-model:value="email.val"
              :value="email.val"
            />
             <p v-show="email.enabled" class="error-field">
            {{ email.errors[0] }}
            </p>
        </div>
        <div class="forms-group">
            <p>Celular</p>
            <InputFormsComponent  
              class="input-form"
              v-model:value="phoneNumber.val"
              :value="phoneNumber.val"
            />
             <p v-show="phoneNumber.enabled" class="error-field">
            {{ phoneNumber.errors[0] }}
            </p>
        </div>
        <div class="forms-group">
            <p></p>
            <input class="admin-submit" 
                type="submit" 
                value="Guardar"
                v-bind:disabled="successForm"
                @click="saveTransaction"
                :class="{ disabled: successForm }"
            />
        </div>
    </div>
    <div class="wrapper-module">
    <div class="search">
        <p>Buscar un cliente</p>
        <SearchFormsComponent 
          :message="placeholder"
          v-model:search="query"
          />
      </div>
    <div class="wrapper-table">
      <table class="table">
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Email</th>
            <th>Celular</th>
            <th>Estado</th>
            <th>Editar</th>
            <th>Eliminar</th>
          </tr>
        </thead>
        <tbody>
          <tr  v-for="(client, index) in paginateTask" v-bind:key="index">
            <td>{{ client.firstName }}</td>
            <td>{{ client.lastName }}</td>
            <td>{{ client.emailAddress }}</td>
            <td>{{ client.phoneNumber }}</td>
            <td>{{ client.status }}</td>
            <td><img src="@/assets/Editar.png" class="table-image" @click="editClientTransaction(client.id)"/></td>
            <td><img src="@/assets/error.png" class="table-image" @click="deleteClientTransaction(client.id)"/></td>
          </tr>
        </tbody>
      </table>
    </div> 
      <PaginatorComponent
      :is-first-page="isFirstPage"
      :is-last-page="isLastPage"
      @nextPage = "nextPage"
      @previousPage = "previousPage"
    ></PaginatorComponent>
  </div> 
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, ref, Ref } from "vue";
import ModalSuccess from "@/components/modals/ModalSuccess.vue"
import {paginator} from "@/services/commons/paginator";
import { vmClient } from "@/viewModels/clientViewModel";
import PaginatorComponent from "@/components/commons/PaginatorComponent.vue"
import InputFormsComponent from "@/components/controls/InputFormsComponent.vue"
import SearchFormsComponent from "@/components/controls/SearchFormsComponent.vue";
import {clientActions} from "@/uses/clientActions";


export default defineComponent({
  name: "ClientOption",
  components: {
    ModalSuccess,
    PaginatorComponent,
    SearchFormsComponent,
    InputFormsComponent
  },
  setup (){
    const showSuccessModal: Ref<boolean> = ref(false);      
    const placeholder = "Buscar nombre o email";

    const message = "Se realizó la solicitud correctamente";

    async function closeModal() {
        showSuccessModal.value = false;
        await cleanForm();
    }
    const {filteredClient, query} = clientActions();

    const {
        name,
        lastName,
        email,
        phoneNumber,
        successForm,
        id,
        saveClient,
        cleanForm,
        editClient,
        deleteClient
        } = vmClient();


    async function saveTransaction() {
      await saveClient();
      showSuccessModal.value = true;
    }


    function editClientTransaction(idClient: number){
      editClient(idClient);
    }

    function deleteClientTransaction(idClient: number){
      deleteClient(idClient);
      showSuccessModal.value = true;
    }
    

    const {
      isFirstPage,
      isLastPage,
      maxItems,
      nextPage,
      previousPage,
      returnData 
    } = paginator();

    maxItems.value = 5;

    const paginateTask = computed(() => {
      return returnData(filteredClient.value);
    });



    return {
        name,
        lastName,
        email,
        phoneNumber,
        placeholder,
        query,
        id,
        isFirstPage,
        isLastPage,
        successForm,
        paginateTask,
        nextPage,
        previousPage,
        showSuccessModal,
        message,
        closeModal,
        saveTransaction,
        editClientTransaction,
        deleteClientTransaction
    };
  }
});
</script>

<style scoped lang="scss">
@import "/src/styles/submit";
@import "/src/styles/form";
@import "/src/styles/table";

.task-layout {
  display: grid;
  grid-template-columns: 0.55fr 1fr;
  height: 100%;
  margin-top: 1.2rem;
}

::-webkit-scrollbar {
    display: none;
}

</style>