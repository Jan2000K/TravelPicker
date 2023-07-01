import settings from "../../settings.json"
import { axiosInstance } from "../../services/AxiosInstance"
import AuthService from "../../services/AuthService"
import { useMutation } from "@tanstack/react-query"
import { IApiResult } from "../../types"
import { IAddLocationVM } from "../../models/webApi/locationModels"


function createLocation(
   model : IAddLocationVM
): Promise<IApiResult<string>> {
    const url = `${settings.ApiUrl}${settings.Controllers.LocationController.Path}`
    return axiosInstance
        .post(url, model)
        .then((res) => res.data)
        .catch((err) => AuthService.HandleUnaothorizedResponse(err,false))
}

export function useCreateLocation() {
    return useMutation({
        mutationFn: (model:IAddLocationVM) =>
        createLocation(model),
        cacheTime:0
    })

}


