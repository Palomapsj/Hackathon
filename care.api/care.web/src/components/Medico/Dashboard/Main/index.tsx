import { DoctorMainSectionProps } from "./types"
import { Grid } from "@mui/material"
import { DoctorSearchSection } from "./SearchSection"
import { DoctorDatagridSection } from "./DatagridSection"
import { DoctorNewPatientExamSection } from "./NewPatientExamSection"

export const DoctorMainSection: React.FC<DoctorMainSectionProps> = ({ viewName, profileName }) => {
    return (
        <Grid container spacing={3}>
            {profileName === 'medico' && viewName === 'pacientes' && (
                <>
                    <DoctorSearchSection viewName='pacientes' profileName='medico' />
                    <DoctorDatagridSection viewName='pacientes' profileName='medico' />
                </>
            )}
            {profileName === 'medico' && viewName === 'novoPacienteExame' && (
                <>
                    <DoctorNewPatientExamSection />
                </>
            )}
            {profileName === 'medico' && viewName === 'protocolosPendentes' && (
                <>
                    <DoctorSearchSection viewName='protocolosPendentes' profileName='medico' />
                    <DoctorDatagridSection viewName='protocolosPendentes' profileName='medico' />
                </>
            )}
        </Grid>
    )
}