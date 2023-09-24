import {AxiosError, AxiosResponse} from "axios";
import { axiosInstance } from "./AxiosInstance.tsx";
import settings from "../settings.json"
import ApiResult from "../models/Result.ts";
import { IApiResult } from "../types";

export default class AuthService{
    static HandleUnauthorizedResponse(err:AxiosError,redirectToLogin:boolean){
        if(err.response && err.response.status === 401){
            if(redirectToLogin)
                window.location.href = "/login"
            return err.response.data as IApiResult<string>
            
        }
        else{
            return ApiResult.ConstructUnexpectedError() 
        }
    }

    static IsLoggedIn(){
        return axiosInstance.get<IApiResult<boolean>>(`${settings.ApiUrl}${settings.Controllers.UserController.Path}/isLoggedIn`)
        .then(
            res => res.data.data
        )
        .catch(err => false)
    }
}





