import { KeyValueVM } from "../KeyValueVM"

export interface IAddLocationVM{
    locationName:string,
    latitude : number,
    longitude : number,
    countryCode : string
    regionName : string

}

export interface ILocationVM{
    id:string
    locationName:string
    regionName:string
    latitude:number
    country:KeyValueVM<string,string>
    longitude:number 
    dateCreated:string
}

