import settings from "../../settings.json"
import { axiosInstance } from "../../services/AxiosInstance"
import { useMutation } from "@tanstack/react-query"


function loginUser(
    username: string,
    password: string
) {
    const url = `${settings.ApiUrl}${settings.Controllers.UserController.Path}/Authorize`
    const requestBody = { username: username, password: password }
    return axiosInstance
        .post(url, requestBody)
}

export function useLogin() {
    return useMutation({
        mutationFn: (creds: { username: string; password: string }) =>
            loginUser(creds.username, creds.password),
        cacheTime:0
    })

}
