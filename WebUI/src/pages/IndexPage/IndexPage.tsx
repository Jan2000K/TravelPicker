import { MapContainer, Marker, Popup, TileLayer } from "react-leaflet"
import "leaflet/dist/leaflet.css"
import styles from "./IndexPage.module.sass"
import { NavigationComponent } from "../../components/NavigationComponent/NavigationComponent"

export const IndexPage: React.FC = () => {
    return (
        <>
            <NavigationComponent />
            <MapContainer
                className={styles.mainMapContainer}
                center={[51.505, -0.09]}
                zoom={13}
                scrollWheelZoom={true}>
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
                <Marker position={[51.505, -0.09]}>
                    <Popup>
                        A pretty CSS3 popup. <br /> Easily customizable.
                    </Popup>
                </Marker>
            </MapContainer>
        </>
    )
}
