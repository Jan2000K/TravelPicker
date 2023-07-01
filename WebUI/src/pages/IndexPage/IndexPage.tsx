import { MapContainer, Marker, Popup, TileLayer, useMap } from "react-leaflet"
import "leaflet/dist/leaflet.css"
import styles from "./IndexPage.module.sass"
import { NavigationComponent } from "../../components/NavigationComponent/NavigationComponent"
import {
    Alert,
    AlertColor,
    Button,
    CircularProgress,
    Snackbar,
    TextField,
} from "@mui/material"
import { useRandomCity } from "../../hooks/queries/useCity"
import { CityVM, Continents } from "../../models/webApi/cityModels"
import { useState } from "react"
import { ActionStatusCode } from "../../models/AppCodes"
import { MapComponent } from "../../components/MapComponent/MapComponent"
import { useCreateLocation } from "../../hooks/queries/useLocation"

export const IndexPage: React.FC = () => {
    const [snackbarOpened, setSnackbarOpened] = useState(false)
    const [alertMessage, setAlertMessage] = useState("")
    const [alertType, setAlertType] = useState<AlertColor>("info")
    const [city, setCity] = useState<CityVM>({
        cityName: "Groningen",
        countryCode: "NL",
        regionName: "Groningen",
        latitude: 53.21917,
        longitude: 6.56667,
    })

    const cityQuery = useRandomCity({ continents: [Continents.Europe] })
    const createLocation = useCreateLocation()
    const newLocationHandler = () => {
        cityQuery.refetch().then((res) => {
            if (res.data?.code !== ActionStatusCode.ActionSuccess) {
                setAlertType("error")
                setAlertMessage(cityQuery.data?.message || "Error occured")
                setSnackbarOpened(true)
            } else {
                setAlertType("success")
                setAlertMessage(res.data.message)
                setSnackbarOpened(true)
                setCity(res.data.data)
            }
        })
    }
    const addLocationHandler = () => {
        createLocation
            .mutateAsync({
                CountryCode: city.countryCode,
                Latitude: city.latitude,
                Longitude: city.longitude,
                locationName: city.cityName,
            })
            .then((res) => {
                if (res.code !== ActionStatusCode.ActionSuccess) {
                    setAlertType("error")
                    setAlertMessage(res.message || "Error occured")
                    setSnackbarOpened(true)
                } else {
                    setAlertType("success")
                    setAlertMessage(res.message)
                    setSnackbarOpened(true)
                }
            })
    }
    return (
        <>
            <NavigationComponent activeRoute={0} />
            <Snackbar
                open={snackbarOpened}
                onClose={(e) => setSnackbarOpened(false)}
                anchorOrigin={{ horizontal: "right", vertical: "top" }}>
                <Alert severity={alertType}>{alertMessage}</Alert>
            </Snackbar>
            <MapComponent city={city}></MapComponent>
            <section className={styles.mapControls}>
                <div className={styles.flexRow}>
                    <Button variant="contained" onClick={addLocationHandler}>Save location</Button>
                    <Button variant="outlined" onClick={newLocationHandler}>
                        Find new location
                    </Button>
                </div>
            </section>
        </>
    )
}
