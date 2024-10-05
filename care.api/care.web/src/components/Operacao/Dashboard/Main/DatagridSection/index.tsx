import React from "react"
import { OperationDatagridSectionProps } from "./types"
import { Button, Grid } from "@mui/material"
import { DataGrid, GridApi, GridColDef, GridRowsProp, GridKeyValue } from "@mui/x-data-grid";
import { CustomToolBar } from "../../../../CustomToolBar";

export const OperationDatagridSection: React.FC<OperationDatagridSectionProps> = ({ profileName, viewName }) => {
    // DataGrid
    let rows: GridRowsProp = []
    let columns: GridColDef[] = []
    if (profileName === 'operacao' && viewName === 'pacientes') {
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
            { field: 'resultadoRET', headerName: 'Resultado RET', width: 150 }
        ];
    } else if (profileName === 'operacao' && viewName === 'medicosDoPrograma') {
        rows = [
            {
                id: 1,
                dataDeCadastro: '12/03/2023',
                nomeMedico: 'Lorem Medico de Oliveira',
                medicoCRMUF: '1234-SP',
                especialidade: 'Oncologia',
                email: 'testando@gmail.com',
                celular: '(11)98888-7777',
                cidade: 'São Paulo',
                estado: 'SP',
                status: 'Ativo',
                aceite: 'Sim'
            },
            {
                id: 2,
                dataDeCadastro: '12/03/2023',
                nomeMedico: 'Lorem Medico de Oliveira',
                medicoCRMUF: '1234-SP',
                especialidade: 'Oncologia',
                email: 'testando@gmail.com',
                celular: '(11)98888-7777',
                cidade: 'São Paulo',
                estado: 'SP',
                status: 'Ativo',
                aceite: 'Não'
            },
        ];
        columns = [
            { field: 'dataDeCadastro', headerName: 'Data de cadastro', width: 135, type: 'Date' },
            { field: 'nomeMedico', headerName: 'Médico', width: 150 },
            { field: 'medicoCRMUF', headerName: 'CRM/UF', width: 130 },
            { field: 'especialidade', headerName: 'Especialidade', width: 130 },
            { field: 'email', headerName: 'Email', width: 130 },
            { field: 'celular', headerName: 'Celular', width: 130 },
            { field: 'cidade', headerName: 'Cidade', width: 130 },
            { field: 'estado', headerName: 'Estado', width: 80 },
            { field: 'status', headerName: 'Status', width: 130 },
            {
                field: "aceite",
                headerName: "Aceite",
                sortable: false,
                renderCell: (params) => {
                    /*Todo: Fazer um if que verifica se tem aceite, caso tenha, coloca um sim no aceite e não renderiza o botão.*/
                    return <Button variant='outlined'>Aceite</Button>;
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