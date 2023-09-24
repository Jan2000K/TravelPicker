import { useQuery } from "@tanstack/react-query"
import {  IRandomCityFilterVM } from "../../models/webApi/cityModels"
import { axiosInstance } from "../../services/AxiosInstance"
import settings from "../../settings.json"
import { IApiResult } from "../../types"
import AuthService from "../../services/AuthService"
import { ILocationVM } from "../../models/webApi/locationModels"

export function useRandomCity(filter: IRandomCityFilterVM) {
    return useQuery(["randomCity"], ()=>  getRandomCity(filter),{enabled:false}
    )
}

const getRandomCity = (filter: IRandomCityFilterVM) => {
    return axiosInstance
        .post<IApiResult<ILocationVM>>(
            `${settings.ApiUrl}${settings.Controllers.CityController.Path}/random`,filter
        )
        .then((res) => res.data)
        .catch((err) => {
            AuthService.HandleUnaothorizedResponse(err)
        })
}
