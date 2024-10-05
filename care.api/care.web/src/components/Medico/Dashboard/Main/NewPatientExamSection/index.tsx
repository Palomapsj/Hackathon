import React from "react"
import { DoctorNewPatientExamSectionProps } from "./types"
import { Autocomplete, Box, Button, Card, CardActions, CardContent, Grid, MenuItem, Paper, Stack, TextField, Typography } from "@mui/material"
import { DatePicker } from "@mui/x-date-pickers"

const exams = [
    {
        id: '1',
        label: 'NGS'
    },
    {
        id: '2',
        label: 'Pré-triagem + NGS'
    }
]
const laboratories = [
    {
        id: '1',
        label: 'Onks'
    },
    {
        id: '2',
        label: 'Dasa'
    }
]
const patologies = [
    {
        label: 'Patologia 1', id: 1
    },
    {
        label: 'Patologia 2', id: 2
    },
    {
        label: 'Patologia 3', id: 3
    },
    {
        label: 'Patologia 4', id: 4
    },
    {
        label: 'Patologia 5', id: 5
    },
    {
        label: 'Patologia 6', id: 6
    },
    {
        label: 'Patologia 7', id: 7
    },
    {
        label: 'Patologia 8', id: 8
    },

]

export const DoctorNewPatientExamSection: React.FC<DoctorNewPatientExamSectionProps> = (props: DoctorNewPatientExamSectionProps) => {
    return (
        <Grid item xs={12} md={12} lg={12}>
            <Paper elevation={6}>
                <Typography component='h1' variant='h4' align='center' color='primary' sx={{ pt: 1 }}>
                    Cadastrar Paciente / Exame
                </Typography>
                <Box component='form' noValidate sx={{ mx: 2 }}>
                    <Box component='hr' mb={2} />
                    <Grid container spacing={2}>
                        <Grid item xs={6} >
                            <TextField fullWidth disabled id='doctorCRM' variant='filled' label='CRM/UF' />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth disabled id='doctorFullName' variant='filled' label='Nome do Médico' />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='patientCPF' variant='filled' label='CPF' />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='patientFullName' variant='filled' label='Nome completo do paciente' />
                        </Grid>
                        <Grid item xs={6}>
                            <DatePicker label="Data de nascimento" slotProps={{ textField: { fullWidth: true } }} />
                        </Grid>
                        <Grid item xs={6}>
                            <Autocomplete
                                disablePortal
                                id="patology"
                                options={patologies}
                                renderInput={(params) => <TextField {...params} label="Patologia" />}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='doctorExame' select variant='filled' label='Exame'>
                                {exams.map((exam) => (
                                    <MenuItem key={exam.id} value={exam.label}>
                                        {exam.id} - {exam.label}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xs={6}>
                            <TextField fullWidth id='labSelected' select variant='filled' label='Laboratório de análise'>
                                {laboratories.map((laboratory) => (
                                    <MenuItem key={laboratory.id} value={laboratory.label}>
                                        {laboratory.id} - {laboratory.label}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xs={12}>
                            <Paper elevation={6}>
                                <Typography component='h4' variant='h5' align='center' color='primary' sx={{ pt: 1 }}>
                                    Endereço de retirada da amostra
                                </Typography>
                                <Box component='form' noValidate sx={{ mx: 2 }}>
                                    <Box component='hr' mb={2} />
                                    <Grid container spacing={2}>
                                        <Grid item xs={2}>
                                            <TextField fullWidth id='pickUpCEP' variant='filled' label='CEP' />
                                        </Grid>
                                        <Grid item xs={10}>
                                            <TextField fullWidth id='pickUpFullName' variant='filled' label='Nome do local de retirada' />
                                        </Grid>
                                        <Grid item xs={8}>
                                            <TextField fullWidth id='pickUpAddress' variant='filled' label='Logradouro' />
                                        </Grid>
                                        <Grid item xs={4}>
                                            <TextField fullWidth id='pickUpAddressNumber' variant='filled' label='Número' />
                                        </Grid>
                                        <Grid item xs={4}>
                                            <TextField fullWidth id='pickUpAddressNeighborhood' variant='filled' label='Bairro' />
                                        </Grid>
                                        <Grid item xs={4}>
                                            <TextField fullWidth id='pickUpAddressCity' variant='filled' label='Cidade' />
                                        </Grid>
                                        <Grid item xs={4}>
                                            <TextField fullWidth id='pickUpAddressState' variant='filled' label='Estado' />
                                        </Grid>
                                    </Grid>
                                </Box>
                                <Typography component='h4' variant='h5' align='center' color='primary' sx={{ pt: 1 }}>
                                    Contato responsável
                                </Typography>
                                <Box component='form' noValidate sx={{ mx: 2 }}>
                                    <Box component='hr' mb={2} />
                                    <Grid container spacing={2}>
                                        <Grid item xs={6}>
                                            <TextField fullWidth id='pickUpResponsiblePersonFullName' variant='filled' label='Nome do responsável' />
                                        </Grid>
                                        <Grid item xs={2}>
                                            <TextField fullWidth id='pickUpResponsiblePersonPhoneNumber' variant='filled' label='Contato' />
                                        </Grid>
                                        <Grid item xs={4}>
                                            <TextField fullWidth id='pickUpResponsiblePersonSector' variant='filled' label='Setor' />
                                        </Grid>
                                    </Grid>
                                </Box>
                                <Typography component='h4' variant='h5' align='center' color='primary' sx={{ pt: 1 }}>
                                    Documentos do programa
                                </Typography>
                                <Box component='form' noValidate sx={{ mx: 2 }}>
                                    <Box component='hr' mb={2} />
                                    <Grid container spacing={2} paddingBottom={2}>
                                        <Grid item xs={4}>
                                            <Paper elevation={6}>
                                                <Typography component='p' variant='h6' align='center' color='primary' sx={{ pt: 1 }}>
                                                    Termo de consentimento
                                                </Typography>
                                                <Grid container spacing={2}>
                                                    <Grid item xs={12}>
                                                        <Stack direction='row' justifyContent='space-evenly' alignItems='center' margin={2}>
                                                            <Button variant='contained' color='secondary'>Download</Button>
                                                            <Button variant='contained' color='secondary'>Upload</Button>
                                                        </Stack>
                                                    </Grid>
                                                </Grid>
                                            </Paper>
                                        </Grid>
                                        <Grid item xs={4}>
                                            <Paper elevation={6}>
                                                <Typography component='p' variant='h6' align='center' color='primary' sx={{ pt: 1 }}>
                                                    Pedido médico
                                                </Typography>
                                                <Grid container spacing={2}>
                                                    <Grid item xs={12}>
                                                        <Stack direction='row' justifyContent='space-evenly' alignItems='center' margin={2}>
                                                            <Button variant='contained' color='secondary'>Download</Button>
                                                            <Button variant='contained' color='secondary'>Upload</Button>
                                                        </Stack>
                                                    </Grid>
                                                </Grid>
                                            </Paper>
                                        </Grid>
                                        <Grid item xs={4}>
                                            <Paper elevation={6}>
                                                <Typography component='p' variant='h6' align='center' color='primary' sx={{ pt: 1 }}>
                                                    Laudo anatomopatológico
                                                </Typography>
                                                <Grid container spacing={2}>
                                                    <Grid item xs={12}>
                                                        <Stack direction='row' justifyContent='space-evenly' alignItems='center' margin={2}>
                                                            <Button variant='contained' color='secondary'>Download</Button>
                                                            <Button variant='contained' color='secondary'>Upload</Button>
                                                        </Stack>
                                                    </Grid>
                                                </Grid>
                                            </Paper>
                                        </Grid>
                                    </Grid>
                                </Box>
                            </Paper>
                        </Grid>
                        <Grid item xs={12} padding={2}>
                            <Stack direction='row' justifyContent='flex-end' alignItems='center'>
                                <Button variant='contained'>Salvar</Button>
                            </Stack>
                        </Grid>
                    </Grid>
                </Box>
            </Paper>
        </Grid>
    )
}