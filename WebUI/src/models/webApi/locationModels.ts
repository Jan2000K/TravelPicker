import { KeyValueVM } from "../KeyValueVM"

export interface IAddLocationVM{
    locationName:string,
    Latitude : number,
    Longitude : number,
    CountryCode : string
}

export interface ILocationVM{
    id:string
    locationName:string
    regionName:string
    latitude:number
    country:KeyValueVM<string,string>
    longitude:number 
    dateTimeOffset:Date
}

