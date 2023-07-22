import settings from "../../settings.json"
import { axiosInstance } from "../../services/AxiosInstance"
import AuthService from "../../services/AuthService"
import { useMutation, useQuery } from "@tanstack/react-query"
import { IApiResult } from "../../types"
import { IAddLocationVM, ILocationVM } from "../../models/webApi/locationModels"
import { IEntityIdsVM } from "../../models/webApi/entityIdsVM"


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


function getUserLocations():Promise<IApiResult<ILocationVM[]>>{
    const url = `${settings.ApiUrl}${settings.Controllers.LocationController.Path}`
    return axiosInstance
        .get(url)
        .then((res) => res.data)
        .catch((err) => AuthService.HandleUnaothorizedResponse(err,false))
}
export function useGetUserLocations(){
    return useQuery(["getUserLocations"],getUserLocations)
}


function deleteLocation(
    model : IEntityIdsVM
 ): Promise<IApiResult<null>> {
     const url = `${settings.ApiUrl}${settings.Controllers.LocationController.Path}`
     return axiosInstance
         .delete(url,{data:model})
         .then((res) => res.data)
         .catch((err) => AuthService.HandleUnaothorizedResponse(err,false))
 }
 
 export function useDeleteLocation() {
     return useMutation({
         mutationFn: (model: IEntityIdsVM) =>
         deleteLocation(model),
         cacheTime:0
     })
 
 }
