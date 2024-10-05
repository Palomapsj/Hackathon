import React from "react"
import { DoctorDatagridSectionProps } from "./types"
import { Grid } from "@mui/material"
import { DataGrid, GridColDef, GridRowsProp, GridToolbarContainer, GridToolbarExport } from "@mui/x-data-grid";
import { CustomToolBar } from "../../../../CustomToolBar";

// DataGrid
const rows: GridRowsProp = [
    {
        id: 1,
        dataDeSolicitacao: '12/03/2023',
        protocolo: 'BE1234567',
        nomePaciente: 'Lorem Ipsun de Oliveira',
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
const columns: GridColDef[] = [
    { field: 'dataDeSolicitacao', headerName: 'Data de solicitação', width: 135, type: 'Date' },
    { field: 'protocolo', headerName: 'Protocolo', width: 100 },
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

export const DoctorDatagridSection: React.FC<DoctorDatagridSectionProps> = (props: DoctorDatagridSectionProps) => {
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