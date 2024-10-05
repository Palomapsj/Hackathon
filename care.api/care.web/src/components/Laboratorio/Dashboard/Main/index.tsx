import { LaboratoryDatagridSection } from "./DatagridSection"
import { LaboratorySearchSection } from "./SearchSection"
import { LaboratoryMainSectionProps } from "./types"
import { Grid } from "@mui/material"

export const LaboratoryMainSection: React.FC<LaboratoryMainSectionProps> = ({ viewName, profileName }) => {
    return (
        <Grid container spacing={3}>
            {profileName === 'laboratorio' && viewName === 'exames' && (
                <>
                    <LaboratorySearchSection profileName='laboratorio' viewName='exames' />
                    <LaboratoryDatagridSection profileName='laboratorio' viewName='exames' />
                </>
            )}
            {profileName === 'laboratorio' && viewName === 'examesAgendados' && (
                <>
                    <LaboratorySearchSection profileName='laboratorio' viewName='examesAgendados' />
                    <LaboratoryDatagridSection profileName='laboratorio' viewName='examesAgendados' />
                </>
            )}
            {profileName === 'laboratorio' && viewName === 'examesEmAnalise' && (
                <>
                    <LaboratorySearchSection profileName='laboratorio' viewName='examesEmAnalise' />
                    <LaboratoryDatagridSection profileName='laboratorio' viewName='examesEmAnalise' />
                </>
            )}
        </Grid>
    )
}