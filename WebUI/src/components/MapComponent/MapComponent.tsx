import { MapContainer, Marker, Popup, TileLayer, useMap } from "react-leaflet"
import { CityVM } from "../../models/webApi/cityModels"
import styles from "./MapComponent.module.sass"
import { useEffect } from "react"
import { LatLngExpression, latLng } from "leaflet"
export const MapComponent: React.FC<{ city: CityVM }> = ({ city }) => {
    return (
        <MapContainer
            className={styles.mainMapContainer}
            center={[city.latitude, city.longitude]}
            zoom={13}
            scrollWheelZoom={true}
            markerZoomAnimation={true}>
            <TileLayer
                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            />
            <MarkerComponent cityName={city.cityName} latlong={[city.latitude,city.longitude]}></MarkerComponent>
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
