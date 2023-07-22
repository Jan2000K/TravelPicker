import axios, { AxiosError, AxiosResponse } from "axios";
import { IApiResult } from "../types";
import ApiResult from "../models/Result";

const axiosInstance = axios.create({
    withCredentials:true,
})
axiosInstance.interceptors.response.use(
    res=>{
        return res
    },
    (err:AxiosError)=>{
        if(err.response?.status === 401){
            window.location.href = "/login"
            return err.response.data as IApiResult<string>
            
        }
        else{
            return ApiResult.ConstructUnexpectedError() 
        }
    }


    
)


export {axiosInstance}