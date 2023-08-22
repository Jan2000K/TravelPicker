import { IAddLocationVM, ILocationVM } from "../../models/webApi/locationModels"
import DateService from "../../services/DateService"
import styles from "./LocationTileComponent.module.sass"
import MapIcon from "@mui/icons-material/Map"
import GpsFixedIcon from "@mui/icons-material/GpsFixed"
import { useNavigate } from "react-router-dom"
import appRoutes from "../../models/AppRoutes"
import GoogleMapsService from "../../services/GoogleMapsService"
import { useState } from "react"
export const LocationTileComponent: React.FC<{
    location: ILocationVM
    setSelectedLocations: React.Dispatch<React.SetStateAction<ILocationVM[]>>
    selectedLocations: ILocationVM[]
}> = ({ location, selectedLocations, setSelectedLocations }) => {
    const [isSelected, setIsSelected] = useState(false)
    let concated = ""
    if (location.regionName) concated = concated + location.regionName + ", "
    if (location.country.name) concated = concated + location.country.name
    const nav = useNavigate()
    const showOnMap = () => {
        nav(appRoutes.index, { state: { location: location } })
    }
    const getDirections = () => {
        const url = GoogleMapsService.directionsToLink(location.locationName)
        window.open(url, "_blank")
    }

    const updateSelectedLocations = () => {
        const isTileSelected = selectedLocations.findIndex(
            (x) => x.id === location.id
        )
        if (isTileSelected === -1) {
            setSelectedLocations([...selectedLocations, location])
            setIsSelected(true)
        } else {
            setSelectedLocations(
                selectedLocations.filter((x) => x.id !== location.id)
            )
            setIsSelected(false)
        }
    }
    return (
        <div
            style={isSelected ? { border: "1px solid blue" } : {}}
            onClick={updateSelectedLocations}
            className={styles.locationWrapper}>
            <h1>{location.locationName}</h1>
            <h4>{concated}</h4>
            <span>
                <b>Date added: </b>
                {DateService.formatDate(new Date(location.dateCreated))}
            </span>
            <div className={styles.actionsContainer}>
                <div
                    onClick={showOnMap}
                    title="Show on map"
                    className={styles.mapIcon}>
                    <MapIcon />
                </div>
                <div
                    onClick={getDirections}
                    title="Directions"
                    className={styles.GpsFixedIcon}>
                    <GpsFixedIcon />
                </div>
            </div>
        </div>
    )
}
