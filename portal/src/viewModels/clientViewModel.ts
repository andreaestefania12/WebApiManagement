import { onMounted, ref, Ref, watch } from "vue";
import { clientServices } from "@/services/api/clientServices";
import { clientValidator } from "@/services/validator/forms/clientValidator";
import router from "@/router";
import { Client } from "@/types/client";

export function vmClient() {
  const clientList: Ref<Client[]> = ref([]);
  const id: Ref<number> = ref(0);
  const status: Ref<string> = ref("Activo");  
  const registrationDate: Ref<string> = ref("");
  const isEdit: Ref<boolean> = ref(false);  
  const {
    name,
    lastName,
    email,
    phoneNumber,
    successForm
  } = clientValidator();


  onMounted(async () => {
    clientList.value = await clientServices.getAll();
  });

  async function saveClient() {

    if(isEdit.value){
      const editClient = {
        id: id.value,
        firstName: name.value.val,
        lastName: lastName.value.val,
        emailAddress: email.value.val ,
        phoneNumber: phoneNumber.value.val ,
        status: status.value,
        registrationDate: registrationDate.value
      };
      const clientJson = JSON.stringify(editClient);
      await clientServices.update(clientJson);
    }
    else{
      const date = new Date()
      const day = date.getDate()
      const month = date.getMonth() + 1
      const year = date.getFullYear()
      const newClient = {
        firstName: name.value.val,
        lastName: lastName.value.val,
        emailAddress: email.value.val ,
        phoneNumber: phoneNumber.value.val ,
        status: "Activo",
        registrationDate: year +"-" + month +"-" + day
      };
      const clientJson = JSON.stringify(newClient);
      await clientServices.create(clientJson);
    }
   
  }

  function editClient(idClient: number):void {
    const client: Client | undefined = clientList.value.find((client) => client.id == idClient);
    if(client){
      name.value.val = client.firstName;
      lastName.value.val = client.lastName;
      email.value.val = client.emailAddress;
      phoneNumber.value.val = client.phoneNumber;
      id.value = client.id;
      status.value = client.status;
      registrationDate.value = client.registrationDate;
      isEdit.value = true;
    }
  }

  async function deleteClient(idClient: number) {
    await clientServices.delete(idClient);
  }

  
  async function cleanForm() {
    await router.push("/");
    await router.push("/client");
  }

  return {
    name,
    lastName,
    email,
    phoneNumber,
    successForm,
    clientList,
    editClient,
    id,
    saveClient,
    cleanForm,
    deleteClient
  };
}
