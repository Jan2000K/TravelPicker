export interface IApiResult<T> {
    code: ActionStatusCode
    data: T
    message: string
}
export class ApiResult<T> {
    constructor(
        private code: ActionStatusCode,
        private data: T,
        private message: string
    ) {}
}
export interface IResult<T> {
    success: boolean
    data: T
    message: string
    code: ActionStatusCode
}
