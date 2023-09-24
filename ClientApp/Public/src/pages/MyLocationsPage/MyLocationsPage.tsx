import "leaflet/dist/leaflet.css"
import styles from "./MyLocationsPage.module.sass"
import { NavigationComponent } from "../../components/NavigationComponent/NavigationComponent"
import { Alert, AlertColor, Button, Snackbar } from "@mui/material"
import { useCallback, useEffect, useState } from "react"
import { ActionStatusCode } from "../../models/AppCodes"
import {
    useDeleteLocation,
    useGetUserLocations,
} from "../../hooks/queries/useLocation"
import { ILocationVM } from "../../models/webApi/locationModels"

import DeleteIcon from "@mui/icons-material/Delete"
import { LocationTileComponent } from "../../components/LocationTileComponent/LocationTileComponent"

export const MyLocationsPage: React.FC = () => {
    const [snackbarOpened, setSnackbarOpened] = useState(false)
    const [alertMessage, setAlertMessage] = useState("")
    const [alertType, setAlertType] = useState<AlertColor>("info")
    const [locations, setLocations] = useState([] as ILocationVM[])
    const [selectedLocations, setSelectedLocations] = useState(
        [] as ILocationVM[]
    )
    const locationQuery = useGetUserLocations()
    const locationDelete = useDeleteLocation()
    useEffect(() => {
        if (locationQuery.isFetched) {
            if (
                locationQuery.data?.code !== ActionStatusCode.ActionSuccess ||
                !locationQuery.data?.data
            ) {
                setAlertMessage(
                    locationQuery.data?.message ?? "Unexpected error occured"
                )
                setAlertType("error")
                setSnackbarOpened(true)
            } else {
                const locations = locationQuery.data!.data.sort(
                    (a, b) =>
                        new Date(b.dateCreated).getTime() -
                        new Date(a.dateCreated).getTime()
                )
                setLocations(locations)
            }
        }
    }, [locationQuery.data])
    const handleDelete = () => {
        if (selectedLocations.length > 0) {
            locationDelete
                .mutateAsync({ EntityIds: selectedLocations.map((x) => x.id) })
                .then(x => {
                    locationQuery.refetch()
                    setAlertMessage("Successfully deleted selected locations")
                    setSnackbarOpened(true)
                    setAlertType("success")
                    })
                

        }
    }
    return (
        <>
            <NavigationComponent activeRoute={1} />
            <Snackbar
                open={snackbarOpened}
                onClose={(e) => setSnackbarOpened(false)}
                autoHideDuration={3000}
                anchorOrigin={{ horizontal: "right", vertical: "top" }}>
                <Alert severity={alertType}>{alertMessage}</Alert>
            </Snackbar>
            <div className={styles.mainContainer}>
                <div
                    onClick={handleDelete}
                    title="Delete selected locations"
                    className={styles.deleteContainer}>
                    <DeleteIcon />
                </div>
                <div className={styles.dataGridContainer}>
                    {locations.map((x) => (
                        <LocationTileComponent
                            selectedLocations={selectedLocations}
                            setSelectedLocations={setSelectedLocations}
                            location={x}
                            key={x.id}
                        />
                    ))}
                </div>
            </div>
        </>
    )
}
