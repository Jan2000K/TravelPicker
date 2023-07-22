import { MapContainer, Marker, Popup, TileLayer, useMap } from "react-leaflet"
import styles from "./MapComponent.module.sass"
import { useEffect } from "react"
import { LatLngExpression, latLng } from "leaflet"
import { ILocationVM } from "../../models/webApi/locationModels"
export const MapComponent: React.FC<{ location: ILocationVM }> = ({ location: location }) => {
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
            <MarkerComponent cityName={location.locationName} latlong={[location.latitude,location.longitude]}></MarkerComponent>
        </MapContainer>
    )
}

const MarkerComponent: React.FC<{ latlong: LatLngExpression,cityName:string }> = ({ latlong,cityName }) => {
    const map = useMap()
    useEffect(
        ()=>{
            map.flyTo(latlong)
        },[latlong]
    )
    return (
        <Marker position={latlong}>
            <Popup>
                {cityName}
            </Popup>
        </Marker>
    )
}
