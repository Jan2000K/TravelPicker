import { ILocationVM } from "../models/webApi/locationModels"

export class LocationService {
    static locationToString(location: ILocationVM) {
        let concatName = location.locationName
        if (location.regionName)
            concatName = concatName + ", " + location.regionName
        if (location.country.name)
            concatName = concatName + ", " + location.country.name
        return concatName
    }
}
