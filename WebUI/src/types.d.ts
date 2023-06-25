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


export interface ICompanyUpsert {
    id: string
    name: string
    description: string
    email: string
    website: string
    linkedIn: string
    amountOfEmployees: number
}
export interface IBasicUserDataVm {
    id: string
    userName: string
}
export interface ICompanyResponseVm extends ICompanyUpsert {
    createdBy: IBasicUserDataVm
    dateCreated: Date
}
export interface IAuthStore {
    isLogged?: boolean
    lastLogin?: Date
}

export enum ApiCodes {
    Unauthorized = 0,
    UnexpectedError = 1,
    Success = 2
}
