export interface IApiResult<T>{
    code: AppCode,
    data: T,
    message: string,
}
export interface IResult<T>{
    success: boolean,
    data: T,
    message: string,
    code: AppCodes
}

