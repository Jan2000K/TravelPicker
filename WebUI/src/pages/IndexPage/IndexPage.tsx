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
import {  Continents } from "../../models/webApi/cityModels"
import { useEffect, useState } from "react"
import { ActionStatusCode } from "../../models/AppCodes"
import { MapComponent } from "../../components/MapComponent/MapComponent"
import { useCreateLocation } from "../../hooks/queries/useLocation"
import AuthService from "../../services/AuthService"
import { useLocation, useNavigate, useNavigation, useSearchParams } from "react-router-dom"
import appRoutes from "../../models/AppRoutes"
import { ILocationVM } from "../../models/webApi/locationModels"
import { KeyValueVM } from "../../models/KeyValueVM"

export const IndexPage: React.FC = () => {
    const [isLoading,setLoading] = useState(false)
    const [snackbarOpened, setSnackbarOpened] = useState(false)
    const [alertMessage, setAlertMessage] = useState("")
    const [alertType, setAlertType] = useState<AlertColor>("info")
    const [searchParams,setSearchParams] = useSearchParams()
    const [location, setLocation] = useState<ILocationVM>({
        locationName: "Groningen",
        country: new KeyValueVM("NL","Netherlands"),
        regionName: "Groningen",
        latitude: 53.21917,
        longitude: 6.56667,
        id : "",
        dateTimeOffset : new Date() 
    })
    const nav = useNavigate()
    let {state} = useLocation()
    useEffect(
        ()=>{
            setLoading(true)
            AuthService.IsLoggedIn()
            .then(
                (isLogged)=>{
                    if(isLogged){
                        setLoading(false)
                    }
                    else{
                       nav(appRoutes.login)
                    }
                }
            )
        }
        ,[]
    )
    useEffect(
    ()=>{
        const location = state.location as ILocationVM
        if(!location)
        {
            return
        }
        setLocation(location)
        
    },[]
    )
    const cityQuery = useRandomCity({ continents: [Continents.Europe] })
    const createLocation = useCreateLocation()
    const newLocationHandler = () => {
        state = null
        cityQuery.refetch().then((res) => {
            if (res.data?.code !== ActionStatusCode.ActionSuccess) {
                setAlertType("error")
                setAlertMessage(cityQuery.data?.message || "Error occured")
                setSnackbarOpened(true)
            } else {
                setAlertType("success")
                setAlertMessage(res.data.message)
                setSnackbarOpened(true)
                setLocation(res.data.data)
                debugger
            }
        })
    }
    const addLocationHandler = () => {
        debugger
        createLocation
            .mutateAsync({
                CountryCode: location.country.id,
                Latitude: location.latitude,
                Longitude: location.longitude,
                locationName: location.locationName,
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
    if(isLoading){
        return(
            <CircularProgress  />
        )
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
            <MapComponent location={location}></MapComponent>
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
