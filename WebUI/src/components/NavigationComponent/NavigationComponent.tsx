import { Tab, Tabs } from "@mui/material"
import { useState } from "react"
import appRoutes from "../../models/AppRoutes"
import { useNavigate } from "react-router-dom"

export const NavigationComponent: React.FC<{activeRoute:number}> = ({activeRoute}) => {
    const [value, setValue] = useState(activeRoute)
    const navigate = useNavigate()
    const handleChange = (event: React.SyntheticEvent, newValue: number) => {
        setValue(newValue)
    }

    return (
        <Tabs
        
            value={value}
            onChange={handleChange}
            aria-label="Navigation">
            <Tab
            onClick={()=>navigate(appRoutes.index)} 
            label="MAP" />
            <Tab 
            onClick={()=>navigate(appRoutes.myLocations)}
            label="MY LOCATIONS" />
        </Tabs>
    )
}

