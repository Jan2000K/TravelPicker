import { ApiCodes, IApiResult, ICompanyResponseVm } from "../../types"
import settings from "../../settings.json"
import { axiosInstance } from "../../services/AxiosInstance"
import AuthService from "../../services/AuthService"
import { useMutation } from "@tanstack/react-query"


function loginUser(
    username: string,
    password: string
): Promise<IApiResult<string>> {
    const url = `${settings.ApiUrl}${settings.Controllers.UserController.Path}/Authorize`
    const requestBody = { username: username, password: password }
    return axiosInstance
        .post(url, requestBody)
        .then((res) => res.data)
        .catch((err) => AuthService.HandleUnaothorizedResponse(err,false))
}

export function useLogin() {
    return useMutation({
        mutationFn: (creds: { username: string; password: string }) =>
            loginUser(creds.username, creds.password),
        cacheTime:0
    })

}
