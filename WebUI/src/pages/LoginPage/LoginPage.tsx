import { Alert, Button, Snackbar, Stack, TextField } from "@mui/material"
import classes from "./LoginPage.module.sass"
import ShuffleRoundedIcon from "@mui/icons-material/ShuffleRounded"
import { useState } from "react"
import { useLogin } from "../../hooks/queries/useUsers"
import { translationsEng } from "../../translations/translationEng"
import { AppCode } from "../../models/AppCodes"
import appRoutes from "../../models/AppRoutes"
export const LoginPage: React.FC = () => {
    const [usernameValue, setUsernameValue] = useState("")
    const [passwordValue, setPasswordValue] = useState("")
    const [errorMessage, setErrorMessage] = useState("")
    const [snackbarOpened,setSnackbarOpened] = useState(false)
    const loginMutation = useLogin()
    const handleLogin = ()=>{
        loginMutation.mutateAsync({username:usernameValue,password:passwordValue})
        .then(
            (res)=>{
                debugger
                if(res.code == AppCode.ActionFailed){
                    setErrorMessage(translationsEng.errorMessages.invalidCredentials)
                    setSnackbarOpened(true)
                }
                else if(res.code == AppCode.ActionSuccess){
                    location.href ="/"
                }
            }
        )
        .catch(
            ()=>{
                setErrorMessage(translationsEng.errorMessages.unexpectedError)
            }
        )
    }
    return (
        <>
            <Snackbar
                open={snackbarOpened}
                onClose={
                    (e)=>setSnackbarOpened(false)
                }
                anchorOrigin={{ horizontal: "right", vertical: "top" }}>
                <Alert severity="error">
                   {errorMessage}
                </Alert>
            </Snackbar>
            <div className={classes.rootContainer}>
                <div className={classes.formContainer}>
                    <Stack spacing={2}>
                        <h2>HTTP Client</h2>
                        <div className={classes.centerItem}>
                            <ShuffleRoundedIcon />
                        </div>
                        <TextField
                            id="username"
                            label="Username"
                            variant="standard"
                            value={usernameValue}
                            onChange={(ev)=>{setUsernameValue(ev.target.value)}}
                        />
                        <TextField
                            id="password"
                            type="password"
                            label="Password"
                            variant="standard"
                            value={passwordValue}
                            onChange={(ev)=>{setPasswordValue(ev.target.value)}}
                        />
                        <Button variant="contained" onClick={handleLogin}>Sign in</Button>
                    </Stack>
                </div>
            </div>
        </>
    )
}
