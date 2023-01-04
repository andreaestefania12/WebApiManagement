import { Client } from "@/types/client";
import {  find_all_clients} from "@/store/urls/client";
import { ApiResponse } from "@/types/commons/ApiResponse";
import { sendRequest } from "@/services/api/apiRest";

export const clientServices = {
    async create(client: string): Promise<void> {
        const url = "https://localhost:7223/api/client";
        const response: ApiResponse = await sendRequest(
          url,
          "POST",
          client
        );
    
        if (!response.isSuccess) {
          throw new Error(response.content);
        }
      },
    

    async getAll(): Promise<Client[]> {
        const url = "https://localhost:7223/api/client";
        const response: ApiResponse = await sendRequest(url, "GET", null);
        if (!response.isSuccess) {
          throw new Error(response.content);
        }
        return JSON.parse(response.content);
    },

    async update( client: string): Promise<void> {
      const url = "https://localhost:7223/api/client" ;
      const response: ApiResponse = await sendRequest(
        url,
        "PUT",
        client
      );
  
      if (!response.isSuccess) {
        throw new Error(response.content);
      }
    },


    async delete(id: number ): Promise<void> {
        const url = "https://localhost:7223/api/client?id="+id.toString();
        const response: ApiResponse = await sendRequest(
          url,
          "DELETE",
          null
        );
    
        if (!response.isSuccess) {
          throw new Error(response.content);
        }
      },
}