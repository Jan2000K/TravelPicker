import { MapContainer, Marker, Popup, TileLayer, useMap } from "react-leaflet"
import styles from "./MapComponent.module.sass"
import { useEffect } from "react"
import { LatLngExpression, latLng } from "leaflet"
import { ILocationVM } from "../../models/webApi/locationModels"
import { LocationService } from "../../services/LocationService"
export const MapComponent: React.FC<{ location: ILocationVM }> = ({
    location: location,
}) => {
    return (
        <MapContainer
            className={styles.mainMapContainer}
            center={[location.latitude, location.longitude]}
            zoom={13}
            scrollWheelZoom={true}
            markerZoomAnimation={true}>
            <TileLayer
                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            />
            <MarkerComponent location={location}></MarkerComponent>
        </MapContainer>
    )
}

const MarkerComponent: React.FC<{ location: ILocationVM }> = ({ location }) => {
    const map = useMap()
    useEffect(() => {
        map.flyTo([location.latitude, location.longitude])
    }, [location])
    let concatName = LocationService.locationToString(location)
    return (
        <Marker position={[location.latitude, location.longitude]}>
            <Popup>{concatName}</Popup>
        </Marker>
    )
}
