import { Box } from "@mui/material"
import { BoxProps } from "@mui/material/Box"
import Footer from "../../components/Footer"
import { Dashboard } from "../../components/Dashboard"

interface IBaseLayoutProps extends BoxProps {
    viewName?: string
    profileName?: string
}

export const BaseLayout: React.FC<IBaseLayoutProps> = ({ children, viewName, profileName }) => {
    return (
        <Box height='100vh'>
            <Dashboard viewName={viewName} profileName={profileName} />
            <Box>
                <Footer />
            </Box>
        </Box>
    )
}