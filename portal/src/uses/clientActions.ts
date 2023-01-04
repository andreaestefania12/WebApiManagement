import { Client } from "@/types/client";
import { Ref, ref,onMounted, computed } from "vue";
import { clientServices } from "@/services/api/clientServices";

export function clientActions(){
    const listClient : Ref<Client[]> = ref([]);
    const query : Ref<string> = ref(""); 

    onMounted(async () => {
        listClient.value = await clientServices.getAll();
    });

    const filteredClient= computed(()=> {
        let result = listClient.value;
        if( query.value.length > 0){
            result = listClient.value.filter(
                (client) => client.firstName.toLocaleLowerCase().includes(query.value.toLocaleLowerCase()) || 
                client.emailAddress.toLocaleLowerCase().includes(query.value.toLocaleLowerCase()) 
            )
        } 
        return result;
    });

    return {
        listClient,
        filteredClient,
        query
    }
}