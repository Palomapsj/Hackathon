import { TextField, Container, Paper, Typography, Box, MenuItem, Grid, Button } from "@mui/material";
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { Stack } from '@mui/material';
import { DataGrid, GridColDef, GridRowsProp, GridToolbarExport } from "@mui/x-data-grid";
import { PendingProtocolsSectionProps } from "./types";

const rows: GridRowsProp = [
    {
        id: 1,
        col1: '12/03/2023',
        col2: 'BE1234567',
        col3: 'Lorem Ipsun de Oliveira',
        col4: '123.456.789-00',
        col5: 'Status teste',
        col6: 'Exame teste',
        col7: 'ET1234567',
        col8: '15/03/2023',
        col9: 'Exame solicitado',
        col10: 'Sem pendências',
        col11: 'Link do laudo teste',
        col12: 'Link do resultado RET teste'

    }
];

const columns: GridColDef[] = [
    { field: 'col1', headerName: 'Data de solicitação', width: 135, type: 'Date' },
    { field: 'col2', headerName: 'Protocolo', width: 100 },
    { field: 'col3', headerName: 'Paciente', width: 150 },
    { field: 'col4', headerName: 'CPF', width: 130 },
    { field: 'col5', headerName: 'Status', width: 100 },
    { field: 'col6', headerName: 'Exame', width: 100 },
    { field: 'col7', headerName: 'Voucher', width: 100 },
    { field: 'col8', headerName: 'Data agendada', width: 135, type: 'Date' },
    { field: 'col9', headerName: 'Status do exame', width: 130 },
    { field: 'col10', headerName: 'Motivo de pendência / cancelamento', width: 160 },
    { field: 'col11', headerName: 'Laudo', width: 150 },
    { field: 'col12', headerName: 'Resultado RET', width: 150 }
];

export const PendingProtocolsSection: React.FC<PendingProtocolsSectionProps> = (props: PendingProtocolsSectionProps) => {
    return (
        <Grid item xs={12} md={12} lg={12}>
            <Paper elevation={6}>
                <Typography component='h1' variant='h4' align='center' color='primary' sx={{ pt: 1 }}>
                    Protocolos Pendentes
                </Typography>
                <Box component='form' noValidate sx={{ mx: 2 }}>
                    <Box component='hr' mb={2} />
                    <Grid container spacing={2}>
                        <Grid item xs={6}>
                            <TextField fullWidth id='doctorProtocol' variant='filled' label='Nº PROTOCOLO' />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='patientFullName' variant='filled' label='NOME DO PACIENTE' />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='patientCpf' label='CPF DO PACIENTE' />
                        </Grid>

                        <Grid item xs={6}>
                            <TextField fullWidth id='patientStatus' select variant='filled' label='STATUS DO PACIENTE' />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='patientStatusExame' select variant='filled' label='STATUS DO EXAME' />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='patientStatusResultado' select variant='filled' label='STATUS DO RESULTADO' />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='patientFilterDate' select variant='filled' label='FILTRO POR DATA DE:' />
                        </Grid>

                        <Grid item spacing={2} xs={3}>
                            <DatePicker label="DATA INICIO" />
                        </Grid>
                        <Grid item spacing={2} xs={3}>
                            <DatePicker label="DATA FIM" />
                        </Grid>
                    </Grid>
                    <Grid item xl={12} lg={12} md={12} xs={12}>
                        <Stack direction='row' justifyContent='flex-end' alignItems='center'>
                            <Button variant='contained'>Procurar</Button>
                        </Stack>
                    </Grid>
                    <Grid item xl={12} lg={12} md={12} xs={12}>
                        <Stack direction='row' justifyContent='space-between' alignItems='center' spacing={2} >
                            <TextField
                                id='resultsByPage'
                                variant='filled'
                                value='100'
                                disabled
                                inputProps={{ style: { textAlign: 'center' } }}
                                InputLabelProps={{ style: { textAlign: 'center' } }}
                                label='Resultados por Página' />
                            <TextField id='instantSearch' variant='filled' label='Pesquisar' />
                        </Stack>
                    </Grid>
                    <Grid item xl={12} lg={12} md={12} xs={12} style={{ height: 300 }} >
                        <DataGrid
                            rows={rows}
                            columns={columns}
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
                                fontSize: {
                                    lg: 15,
                                    md: 13,
                                    xs: 12
                                }
                            }}
                        />
                    </Grid>
                    <br />
                    <Grid item xl={12} lg={12} md={12} xs={12} >
                        <Button variant='contained' sx={{ mb: 1 }}>EXPORTA PARA EXECEL</Button>
                    </Grid>
                </Box>
            </Paper>
        </Grid >
    );
}

// Todo: Reutilizar o SearchSection e o DatagridSection para renderizar corretamente essa tela