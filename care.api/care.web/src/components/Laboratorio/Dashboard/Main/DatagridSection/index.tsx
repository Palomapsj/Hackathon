import React from "react"
import { LaboratoryDatagridSectionProps } from "./types"
import { Button, Grid } from "@mui/material"
import { DataGrid, GridApi, GridColDef, GridRowsProp } from "@mui/x-data-grid";
import { CustomToolBar } from "../../../../CustomToolBar";
import AssignmentTurnedInIcon from '@mui/icons-material/AssignmentTurnedIn';

export const LaboratoryDatagridSection: React.FC<LaboratoryDatagridSectionProps> = ({ profileName, viewName }) => {
    // DataGrid
    let rows: GridRowsProp = []
    let columns: GridColDef[] = []
    if (profileName === 'laboratorio' && viewName === 'exames') {
        rows = [
            {
                id: 1,
                dataDeSolicitacao: '12/03/2023',
                protocolo: 'BE1234567',
                nomeMedico: 'Lorem Medico de Oliveira',
                medicoCRMUF: '1234-SP',
                nomePaciente: 'Lorem Paciente de Oliveira',
                cpf: '123.456.789-00',
                status: 'Status teste',
                exame: 'Exame teste',
                voucher: 'ET1234567',
                dataAgendada: '15/03/2023',
                statusExame: 'Exame solicitado',
                motivoPendenciaCancelamento: 'Sem pendências',
                laudo: 'Link do laudo teste',
                resultadoRET: 'Link do resultado RET teste'
            }
        ];
        columns = [
            { field: 'dataDeSolicitacao', headerName: 'Data de solicitação', width: 135, type: 'Date' },
            { field: 'protocolo', headerName: 'Protocolo', width: 100 },
            { field: 'nomeMedico', headerName: 'Médico', width: 150 },
            { field: 'medicoCRMUF', headerName: 'CRM/UF', width: 130 },
            { field: 'nomePaciente', headerName: 'Paciente', width: 150 },
            { field: 'cpf', headerName: 'CPF', width: 130 },
            { field: 'status', headerName: 'Status', width: 100 },
            { field: 'exame', headerName: 'Exame', width: 100 },
            { field: 'voucher', headerName: 'Voucher', width: 100 },
            { field: 'dataAgendada', headerName: 'Data agendada', width: 135, type: 'Date' },
            { field: 'statusExame', headerName: 'Status do exame', width: 130 },
            { field: 'motivoPendenciaCancelamento', headerName: 'Motivo de pendência / cancelamento', width: 160 },
            { field: 'laudo', headerName: 'Laudo', width: 150 },
            { field: 'resultadoRET', headerName: 'Resultado RET', width: 150 }
        ];
    } else if (profileName === 'laboratorio' && (viewName === 'examesAgendados' || viewName === 'examesEmAnalise')) {
        rows = [
            {
                id: 1,
                dataDaSolicitacao: '12/03/2023',
                protocolo: 'BE1234567',
                nomeMedico: 'Lorem Medico de Oliveira',
                medicoCRMUF: '1234-SP',
                nomePaciente: 'Lorem Ipsun de Oliveira',
                cpf: '123.456.789-00',
                status: 'Ativo',
                exame: 'Exame teste',
                voucher: 'ET1234567',
                dataAgendada: '12/03/2023',
                statusExame: 'Exame solicitado',
                aceite: ''
            },
        ];
        columns = [
            { field: 'dataDaSolicitacao', headerName: 'Data da solicitação', width: 135, type: 'Date' },
            { field: 'protocolo', headerName: 'Protocolo', width: 100 },
            { field: 'nomeMedico', headerName: 'Médico', width: 150 },
            { field: 'medicoCRMUF', headerName: 'CRM/UF', width: 130 },
            { field: 'nomePaciente', headerName: 'Paciente', width: 150 },
            { field: 'cpf', headerName: 'CPF', width: 130 },
            { field: 'status', headerName: 'Status', width: 130 },
            { field: 'exame', headerName: 'Exame', width: 100 },
            { field: 'voucher', headerName: 'Voucher', width: 100 },
            { field: 'dataAgendada', headerName: 'Data Agendada', width: 135, type: 'Date' },
            { field: 'statusExame', headerName: 'Status do exame', width: 130 },
            {
                field: "informar",
                headerName: "Informar",
                sortable: false,
                renderCell: (params) => {
                    /*Todo: fazer o botão de aceite que abre a modal*/
                    return <Button variant='outlined'><AssignmentTurnedInIcon /></Button>;
                }
            },
        ];
    }
    return (
        <Grid item xs={12} style={{ height: 300, width: '100%' }}>
            <DataGrid
                rows={rows}
                columns={columns}
                slots={{
                    toolbar: CustomToolBar
                }}
                slotProps={{
                    toolbar: {
                        disableDensitySelector: true,
                    }
                }}
                sx={{
                    '& .MuiDataGrid-columnHeaderTitle': {
                        whiteSpace: 'normal',
                        lineHeight: 'normal'
                    },
                    '& .MuiDataGrid-columnHeader': {
                        // Forced to use important since overriding inline styles
                        height: 'unset !important'
                    },
                    '& .MuiDataGrid-columnHeaders': {
                        // Forced to use important since overriding inline styles
                        maxHeight: '168px !important'
                    },
                    //Todo: Talvez letras menores?
                    fontSize: {
                        lg: 15,
                        md: 13,
                        xs: 12
                    }
                }}
            />
        </Grid>
    )
}