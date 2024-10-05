import { TextField, Container, Paper, Typography, Box, MenuItem, Grid, Checkbox, FormGroup, FormControlLabel, Button } from "@mui/material";
import { light } from "@mui/material/styles/createPalette";

const estados = [
    {
        nome: 'Acre',
        sigla: 'AC'
    },
    {
        nome: 'Alagoas',
        sigla: 'AL'
    },
    {
        nome: 'Amapá',
        sigla: 'AP'
    },
    {
        nome: 'Amazonas',
        sigla: 'AM'
    },
    {
        nome: 'Bahia',
        sigla: 'BA'
    },
    {
        nome: 'Ceará',
        sigla: 'CE'
    },
    {
        nome: 'Distrito Federal',
        sigla: 'DF'
    },
    {
        nome: 'Espírito Santo',
        sigla: 'ES'
    },
    {
        nome: 'Goiás',
        sigla: 'GO'
    },
    {
        nome: 'Maranhão',
        sigla: 'MA'
    },
    {
        nome: 'Mato Grosso',
        sigla: 'MT'
    },
    {
        nome: 'Mato Grosso do Sul',
        sigla: 'MS'
    },
    {
        nome: 'Minas Gerais',
        sigla: 'MG'
    },
    {
        nome: 'Pará',
        sigla: 'PA'
    },
    {
        nome: 'Paraíba',
        sigla: 'PB'
    },
    {
        nome: 'Paraná',
        sigla: 'PR'
    },
    {
        nome: 'Pernambuco',
        sigla: 'PE'
    },
    {
        nome: 'Piauí',
        sigla: 'PI'
    },
    {
        nome: 'Roraima',
        sigla: 'RR'
    },
    {
        nome: 'Rondônia',
        sigla: 'RO'
    },
    {
        nome: 'Rio de Janeiro',
        sigla: 'RJ'
    },
    {
        nome: 'Rio Grande do Norte',
        sigla: 'RN'
    },
    {
        nome: 'Rio Grande do Sul',
        sigla: 'RS'
    },
    {
        nome: 'Santa Catarina',
        sigla: 'SC'
    },
    {
        nome: 'São Paulo',
        sigla: 'SP'
    },
    {
        nome: 'Sergipe',
        sigla: 'SE'
    },
    {
        nome: 'Tocantins',
        sigla: 'TO'
    }
]
const cidades = [
    {
        estado: 'SP',
        cidade: 'São Paulo'
    }
]
const especialidades = [
    {
        area: 'oncologia',
        especialidade: 'cirurgia'
    }
]

export function CadastroMedico() {
    return (
        <Container component='main' maxWidth='md'>
            <Grid container justifyContent='center' alignItems='center'>
                <Grid item>
                    <Paper elevation={6} sx={{  my: '10vh' }}>
                        <Typography component='h1' variant='h4' align='center' color='primary' sx={{ pt: 1 }}>
                            Cadastro Médico
                        </Typography>
                        <Box component='form' noValidate sx={{ mx: 2 }} >
                            <Box component='hr' mb={2} />
                            <Grid container component='section' spacing={2}>
                                <Grid item xs={6} >
                                    <TextField fullWidth id='doctorCRM' variant='filled' label='CRM' />
                                </Grid>
                                <Grid item xs={6}>
                                    <TextField fullWidth id='doctorCRMUF' select variant='filled' label='UF do CRM'>
                                        {estados.map((estados) => (
                                            <MenuItem key={estados.nome} value={estados.nome}>
                                                {estados.sigla}
                                            </MenuItem>
                                        ))}
                                    </TextField>
                                </Grid>
                                <Grid item xs={12}>
                                    <TextField fullWidth id='doctorFullName' variant='filled' label='Nome completo' />
                                </Grid>
                                <Grid item xs={6}>
                                    <TextField fullWidth id='doctorEmail' variant='filled' label='E-mail' />
                                </Grid>
                                <Grid item xs={6}>
                                    <TextField fullWidth id='doctorPhone1' variant='filled' label='Celular' />
                                </Grid>
                                <Grid item sm={3} xs={6}>
                                    <TextField fullWidth id='doctorUF' select variant='filled' label='UF'>
                                        <TextField fullWidth id='doctorCEP' variant='filled' label='CEP' />
                                        {estados.map((estados) => (
                                            <MenuItem key={estados.nome} value={estados.nome}>
                                                {estados.sigla}
                                            </MenuItem>
                                        ))}
                                    </TextField>
                                </Grid>
                                <Grid item sm={4} xs={6}>
                                    <TextField fullWidth id='doctorCity' select variant='filled' label='Cidade'>
                                        {cidades.map((cidades) => (
                                            <MenuItem key={cidades.cidade} value={cidades.cidade}>
                                                {cidades.cidade}
                                            </MenuItem>
                                        ))}
                                    </TextField>
                                </Grid>
                                <Grid item sm={5} xs={12}>
                                    <TextField fullWidth id='doctorSpecialty' select variant='filled' label='Especialidade'>
                                        {especialidades.map((especialidades) => (
                                            <MenuItem key={especialidades.especialidade} value={especialidades.especialidade}>
                                                {especialidades.especialidade + ' ' + especialidades.area}
                                            </MenuItem>
                                        ))}
                                    </TextField>
                                </Grid>
                                <Grid item xs={12}>
                                    <FormGroup>
                                        <FormControlLabel control={<Checkbox />} label="Li e aceito a política de privacidade" />
                                        <FormControlLabel control={<Checkbox />} label="Li e aceito o regulamento do programa" />
                                        <FormControlLabel control={<Checkbox />} label="Li e aceito o termo de consentimento" />
                                        <FormControlLabel control={<Checkbox />} label="Afirmo que li e conferi meus dados pessoais e que todas as informações aqui preenchidas são verdadeiras." />
                                    </FormGroup>
                                </Grid>
                                <Grid item xs={12} >
                                    <Button variant='contained' sx={{ mb: 1 }}>Salvar</Button>
                                </Grid>
                            </Grid>
                        </Box>
                    </Paper>
                </Grid>
            </Grid>
        </Container >
    );
}

