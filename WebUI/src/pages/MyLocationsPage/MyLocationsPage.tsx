import { MapContainer, Marker, Popup, TileLayer, useMap } from "react-leaflet"
import "leaflet/dist/leaflet.css"
import styles from "./MyLocationsPage.module.sass"
import { NavigationComponent } from "../../components/NavigationComponent/NavigationComponent"
import {
    Alert,
    Button,
    CircularProgress,
    Snackbar,
    TextField,
} from "@mui/material"
import { CityVM, Continents } from "../../models/webApi/cityModels"
import { useState } from "react"
import { ActionStatusCode } from "../../models/AppCodes"
import { MapComponent } from "../../components/MapComponent/MapComponent"

export const MyLocationsPage: React.FC = () => {
    const [snackbarOpened, setSnackbarOpened] = useState(false)
    const [errorMessage, setErrorMessage] = useState("")

    return (
        <>
            <NavigationComponent activeRoute={1} />
            <Snackbar
                open={snackbarOpened}
                onClose={(e) => setSnackbarOpened(false)}
                anchorOrigin={{ horizontal: "right", vertical: "top" }}>
                <Alert severity="error">{errorMessage}</Alert>
            </Snackbar>
            
        </>
    )
}
