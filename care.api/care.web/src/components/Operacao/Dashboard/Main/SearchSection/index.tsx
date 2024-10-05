import React from "react"
import { OperationSearchSectionProps } from "./types"
import { Button, Grid, MenuItem, Paper, Stack, TextField } from "@mui/material"
import { DatePicker } from "@mui/x-date-pickers";

// Select
const patientStatus = [
    {
        chave: 1,
        status: 'Ativo'
    },
    {
        chave: 2,
        status: 'Inativo'
    },
    {
        chave: '',
        status: ''
    }
]
const examStatus = [
    {
        chave: 1,
        status: 'Exame agendado'
    },
    {
        chave: 2,
        status: 'Amostra retirada'
    },
    {
        chave: 3,
        status: 'Em análise'
    },
    {
        chave: 4,
        status: 'Exame concluído'
    },
    {
        chave: 5,
        status: 'Exame com pendência'
    },
    {
        chave: 6,
        status: 'Exame cancelado'
    },
    {
        chave: '',
        status: ''
    }
]
const examResultsStatus = [
    {
        chave: 1,
        status: 'Concluído com biomarcador'
    },
    {
        chave: 2,
        status: 'Concluído sem biomarcador'
    },
    {
        chave: 3,
        status: 'Inconclusivo'
    },
    {
        chave: '',
        status: ''
    }
]
const filterDateBy = [
    {
        chave: 1,
        status: 'Data de solicitação'
    },
    {
        chave: 2,
        status: 'Data de agendamento'
    },
    {
        chave: '',
        status: ''
    }
]
const doctorSpecializations = [
    {
        chave: 1,
        status: 'Oncologia'
    },
    {
        chave: 2,
        status: 'Obstetria'
    },
    {
        chave: 3,
        status: 'Cardiovascular'
    },
    {
        chave: 4,
        status: 'Otorrinolaringologia'
    },
    {
        chave: 5,
        status: 'Hepatologista'
    },
    {
        chave: '',
        status: ''
    }
]

export const OperationSearchSection: React.FC<OperationSearchSectionProps> = ({ viewName, profileName }) => {
    return (
        <Grid item xs={12} md={12} lg={12}>
            <Paper
                sx={{
                    p: 2,
                    display: 'flex',
                    flexDirection: 'column',
                }}
            >
                {profileName === 'operacao' && viewName === 'pacientes' && (
                    <Grid container spacing={2}>
                        <Grid item xl={2} lg={2} md={3} xs={12}>
                            <TextField fullWidth id='patientProtocolNumber' variant='filled' label='N° Protocolo' />
                        </Grid>
                        <Grid item xl={8} lg={8} md={6} xs={12}>
                            <TextField fullWidth id='patienteFullName' variant='filled' label='Nome do Paciente' />
                        </Grid>
                        {/*Todo: Aplicar formatador para o CPF*/}
                        <Grid item xl={2} lg={2} md={3} xs={12}>
                            <TextField fullWidth id='patienteCPF' variant='filled' label='CPF' />
                        </Grid>
                        <Grid item xl={4} lg={4} md={4} xs={12}>
                            {/*Todo: Tratar o defaultValue e a entrada vazia. exam status*/}
                            <TextField fullWidth select id='examStatus' variant='filled' label='Status do Exame' defaultValue=''>
                                {examStatus.map((examStatus) => (
                                    <MenuItem key={examStatus.chave} value={examStatus.status}>
                                        {examStatus.chave} - {examStatus.status}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xl={4} lg={4} md={4} xs={12}>
                            {/*Todo: Tratar o defaultValue e a entrada vazia. patient status*/}
                            <TextField fullWidth select id='petientStatus' variant='filled' label='Status do Paciente' defaultValue=''>
                                {patientStatus.map((patientStatus) => (
                                    <MenuItem key={patientStatus.chave} value={patientStatus.status}>
                                        {patientStatus.chave} - {patientStatus.status}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xl={4} lg={4} md={4} xs={12}>
                            {/*Todo: Tratar o defaultValue e a entrada vazia. exam result status*/}
                            <TextField fullWidth select id='examResultsStatus' variant='filled' label='Status do Resultado' defaultValue=''>
                                {examResultsStatus.map((examResultsStatus) => (
                                    <MenuItem key={examResultsStatus.chave} value={examResultsStatus.status}>
                                        {examResultsStatus.chave} - {examResultsStatus.status}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xl={6} lg={6} md={6} xs={12}>
                            <TextField fullWidth id='doctorFullName' variant='filled' label='Médico' />
                        </Grid>
                        <Grid item xl={6} lg={6} md={6} xs={12}>
                            <TextField fullWidth id='doctorCRMUF' variant='filled' label='CRM/UF' />
                        </Grid>
                        <Grid item xl={6} lg={6} md={6} xs={12}>
                            {/*Todo: Tratar o defaultValue e a entrada vazia. filter date by*/}
                            <TextField fullWidth select id='filterDateBy' variant='filled' label='Filtro Por Data de:' defaultValue=''>
                                {filterDateBy.map((filterDateBy) => (
                                    <MenuItem key={filterDateBy.chave} value={filterDateBy.status}>
                                        {filterDateBy.chave} - {filterDateBy.status}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xl={6} lg={6} md={6} xs={12}>
                            <Grid container justifyContent='flex-end' spacing={2}>
                                <Grid item xl={6} lg={6} md={6} xs={12}>
                                    <DatePicker label="Data Início" slotProps={{ textField: { fullWidth: true } }} />
                                </Grid>
                                <Grid item xl={6} lg={6} md={6} xs={12}>
                                    <DatePicker label="Data Fim" slotProps={{ textField: { fullWidth: true } }} />
                                </Grid>
                            </Grid>
                        </Grid>
                        <Grid item xl={12} lg={12} md={12} xs={12}>
                            <Stack direction='row' justifyContent='flex-end' alignItems='center'>
                                <Button variant='contained'>Procurar</Button>
                            </Stack>
                        </Grid>
                        <Grid item xl={12} lg={12} md={12} xs={12}>
                            <Stack direction='row' justifyContent='flex-end' alignItems='center' spacing={2}>
                                <TextField id='instantSearch' variant='filled' label='Pesquisar' />
                            </Stack>
                        </Grid>
                    </Grid>
                )}
                {profileName === 'operacao' && viewName === 'medicosDoPrograma' && (
                    <Grid container spacing={2}>
                        <Grid item xl={8} lg={8} md={6} xs={12}>
                            <TextField fullWidth id='doctorFullName' variant='filled' label='Nome do Médico' />
                        </Grid>
                        <Grid item xl={4} lg={4} md={6} xs={12}>
                            <TextField fullWidth id='doctorCRMUF' variant='filled' label='CRMUF' />
                        </Grid>
                        <Grid item xl={3} lg={3} md={3} xs={12}>
                            {/*Todo: Tratar o defaultValue e a entrada vazia. operation doctor specialization*/}
                            <TextField fullWidth select id='doctorSpecialization' variant='filled' label='Especialidade' defaultValue=''>
                                {doctorSpecializations.map((doctorSpecialization) => (
                                    <MenuItem key={doctorSpecialization.chave} value={doctorSpecialization.status}>
                                        {doctorSpecialization.chave} - {doctorSpecialization.status}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xl={3} lg={3} md={3} xs={12}>
                            {/*Todo: Tratar o defaultValue e a entrada vazia. filter date by*/}
                            <TextField fullWidth select id='filterDateBy' variant='filled' label='Filtro Por Data de:' defaultValue=''>
                                {filterDateBy.map((filterDateBy) => (
                                    <MenuItem key={filterDateBy.chave} value={filterDateBy.status}>
                                        {filterDateBy.chave} - {filterDateBy.status}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xl={6} lg={6} md={6} xs={12}>
                            <Grid container justifyContent='flex-end' spacing={2}>
                                <Grid item xl={6} lg={6} md={6} xs={12}>
                                    <DatePicker label="Data Início" slotProps={{ textField: { fullWidth: true } }} />
                                </Grid>
                                <Grid item xl={6} lg={6} md={6} xs={12}>
                                    <DatePicker label="Data Fim" slotProps={{ textField: { fullWidth: true } }} />
                                </Grid>
                            </Grid>
                        </Grid>
                        <Grid item xl={12} lg={12} md={12} xs={12}>
                            <Stack direction='row' justifyContent='flex-end' alignItems='center'>
                                <Button variant='contained'>Procurar</Button>
                            </Stack>
                        </Grid>
                        <Grid item xl={12} lg={12} md={12} xs={12}>
                            <Stack direction='row' justifyContent='flex-end' alignItems='center' spacing={2}>
                                <TextField id='instantSearch' variant='filled' label='Pesquisar' />
                            </Stack>
                        </Grid>
                    </Grid>
                )}
            </Paper>
        </Grid>
    )
}