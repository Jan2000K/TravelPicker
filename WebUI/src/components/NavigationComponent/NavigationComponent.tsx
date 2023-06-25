import { Tab, Tabs } from "@mui/material"
import { useState } from "react"

export const NavigationComponent: React.FC = () => {
    const [value, setValue] = useState(0)

    const handleChange = (event: React.SyntheticEvent, newValue: number) => {
        setValue(newValue)
    }

    return (
        <Tabs
            value={value}
            onChange={handleChange}
            aria-label="Navigation">
            <Tab label="MAP" />
            <Tab label="MY LOCATIONS" />
            <Tab label="NEARBY" />
        </Tabs>
    )
}

