import { ApiResponse } from "@/types/commons/ApiResponse";

export async function sendRequest(
  url: string,
  verb: string,
  body?: any
): Promise<ApiResponse> {
  const config: RequestInit = {
    method: verb,
    mode: "cors",
    body: body,
    headers: {
      "Content-Type": "application/json"
    },
  };

  const apiResponse: ApiResponse = {
    isSuccess: false,
    statusCode: 500,
    content: "",
  };

  const res = await fetch(url, config);
  const data = await res.json();
  apiResponse.isSuccess = true;
  apiResponse.statusCode = 200;
  apiResponse.content = JSON.stringify(data);

  return apiResponse;
}
