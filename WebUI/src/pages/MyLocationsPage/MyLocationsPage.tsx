import { MapContainer, Marker, Popup, TileLayer, useMap } from "react-leaflet"
import "leaflet/dist/leaflet.css"
import styles from "./MyLocationsPage.module.sass"
import { NavigationComponent } from "../../components/NavigationComponent/NavigationComponent"
import {
    Alert,
    AlertColor,
    Button,
    CircularProgress,
    Snackbar,
} from "@mui/material"
import { Continents } from "../../models/webApi/cityModels"
import { useCallback, useEffect, useState } from "react"
import { ActionStatusCode } from "../../models/AppCodes"
import { MapComponent } from "../../components/MapComponent/MapComponent"
import AddLocationTwoToneIcon from "@mui/icons-material/AddLocationTwoTone"
import {
    DataGrid,
    GridActionsCellItem,
    GridCallbackDetails,
    GridColDef,
    GridRowIdGetter,
    GridRowParams,
    GridRowSelectionModel,
    GridToolbar,
} from "@mui/x-data-grid"
import MapIcon from "@mui/icons-material/Map"
import {
    useDeleteLocation,
    useGetUserLocations,
} from "../../hooks/queries/useLocation"
import { GridInitialStateCommunity } from "@mui/x-data-grid/models/gridStateCommunity"
import DateService from "../../services/DateService"
import { ILocationVM } from "../../models/webApi/locationModels"
import { IEntityIdsVM } from "../../models/webApi/entityIdsVM"
import GoogleMapsService from "../../services/GoogleMapsService"
import { useNavigate } from "react-router-dom"
import appRoutes from "../../models/AppRoutes"

export const MyLocationsPage: React.FC = () => {
    const [snackbarOpened, setSnackbarOpened] = useState(false)
    const [alertMessage, setAlertMessage] = useState("")
    const [alertType, setAlertType] = useState<AlertColor>("info")
    const [tableRows, setTableRows] = useState([] as ILocationVM[])
    const [selectedRows, setSelectedRows] = useState([] as ILocationVM[])
    const nav = useNavigate()

    const locationQuery = useGetUserLocations()
    const locationDelete = useDeleteLocation()
    const handleDirectionsClick = useCallback(
        (params: GridRowParams<ILocationVM>) => {
            const url = GoogleMapsService.directionsToLink(
                params.row.locationName
            )
            window.open(url, "_blank")
        },
        []
    )
    const handleMapActionClick = useCallback(
        (params: GridRowParams<ILocationVM>) => {
            nav(appRoutes.index,{state:{location:params.row}})
        },
        []
    )
    const tableColumns: GridColDef[] = [
        {
            field: "id",
            headerName: "Id",
        },
        {
            field: "latitude",
            headerName: "latitude",
        },
        {
            field: "longitude",
            headerClassName: "longitude",
        },
        {
            field: "locationName",
            headerName: "Location name",
            type: "string",
            minWidth: 300,
        },
        {
            field: "country",
            headerName: "Country",
            type: "string",
            valueFormatter: (val) => val.value.name,
            width: 200,
        },
        {
            field: "dateCreated",
            headerName: "Date created (UTC)",
            type: "dateTime",
            valueGetter: (val) => new Date(val.value),
            valueFormatter: (val) => DateService.formatDate(val.value as any),
            width: 200,
        },
        {
            field: "Actions",
            headerName: "Actions",
            type: "actions",
            getActions: (params: GridRowParams) => [
                <GridActionsCellItem
                    icon={<MapIcon />}
                    label="Show on Map"
                    title="Show on map"
                    onClick={() => handleMapActionClick(params)}
                />,
                <GridActionsCellItem
                    icon={<AddLocationTwoToneIcon />}
                    label="Get directions"
                    title="Get directions"
                    onClick={() => handleDirectionsClick(params)}
                />,
            ],
        },
    ]
    const initialState: GridInitialStateCommunity = {
        columns: {
            columnVisibilityModel: {
                id: false,
                latitude: false,
                longitude: false,
            },
        },
    }
    const handleRowSelection = (
        rowSelectionModel: GridRowSelectionModel,
        details: GridCallbackDetails<any>
    ): void => {
        const rws = tableRows.filter((loc) =>
            rowSelectionModel.includes(loc.id)
        )
        setSelectedRows(rws)
    }

    const handleDelete = () => {
        if (selectedRows.length === 0) {
            setAlertType("warning")
            setAlertMessage("No rows selected for deletion!")
            setSnackbarOpened(true)
            return
        }
        const model: IEntityIdsVM = { EntityIds: selectedRows.map((x) => x.id) }
        locationDelete.mutateAsync(model).then((res) => {
            if (res.code !== ActionStatusCode.ActionSuccess) {
                setAlertMessage(res.message ?? "Unexpected error occured")
                setAlertType("error")
                setSnackbarOpened(true)
            } else {
                locationQuery.refetch()
            }
        })
    }
    useEffect(() => {
        if (
            locationQuery.data?.code !== ActionStatusCode.ActionSuccess ||
            !locationQuery.data.data
        ) {
            setAlertMessage(
                locationQuery.data?.message ?? "Unexpected error occured"
            )
            setAlertType("error")
            setSnackbarOpened(true)
        } else {
            setAlertMessage(locationQuery.data.message)
            setAlertType("success")
            setSnackbarOpened(true)
            setTableRows(locationQuery.data.data as any[])
        }
    }, [locationQuery.data])

    return (
        <>
            <NavigationComponent activeRoute={1} />
            <Snackbar
                open={snackbarOpened}
                onClose={(e) => setSnackbarOpened(false)}
                anchorOrigin={{ horizontal: "right", vertical: "top" }}>
                <Alert severity={alertType}>{alertMessage}</Alert>
            </Snackbar>
            <div className={styles.mainContainer}>
                <Button
                    className={styles.deleteButton}
                    onClick={handleDelete}
                    variant="outlined">
                    Delete Selected Locations
                </Button>
                <div className={styles.dataGridContainer}>
                    <DataGrid
                        slots={{
                            toolbar: GridToolbar,
                        }}
                        onRowSelectionModelChange={handleRowSelection}
                        disableColumnSelector={true}
                        checkboxSelection={true}
                        rowSelection={true}
                        initialState={initialState}
                        columns={tableColumns}
                        rows={tableRows}
                    />
                </div>
            </div>
        </>
    )
}
