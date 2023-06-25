import { IApiResult } from "../types";
import { AppCode } from "./AppCodes";

export default class ApiResult<T> implements IApiResult<T> {
    public code: number;
    public data: T;
    public message: string;
    constructor(code: number, data: T, message: string) {
        this.data  = data
        this.message = message
        this.code = code
    }
    static ConstructUnexpectedError(){
        return new ApiResult(AppCode.UnexpectedError,"","Unexpected error occured")
    }
}