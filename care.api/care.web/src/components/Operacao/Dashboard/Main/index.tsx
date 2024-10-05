import { OperationDatagridSection } from "./DatagridSection"
import { OperationNewPatientExamSection } from "./NewPatientExamSection"
import { OperationSearchSection } from "./SearchSection"
import { OperationMainSectionProps } from "./types"
import { Grid } from "@mui/material"

export const OperationMainSection: React.FC<OperationMainSectionProps> = ({ viewName, profileName }) => {
    return (
        <Grid container spacing={3}>
            {profileName === 'operacao' && viewName === 'pacientes' && (
                <>
                    <OperationSearchSection profileName='operacao' viewName='pacientes' />
                    <OperationDatagridSection profileName='operacao' viewName='pacientes' />
                </>
            )}
            {profileName === 'operacao' && viewName === 'novoPacienteExame' && (
                <>
                    <OperationNewPatientExamSection />
                </>
            )}
            {profileName === 'operacao' && viewName === 'medicosDoPrograma' && (
                <>
                    <OperationSearchSection profileName='operacao' viewName='medicosDoPrograma' />
                    <OperationDatagridSection profileName='operacao' viewName='medicosDoPrograma' />
                </>
            )}
        </Grid>
    )
}