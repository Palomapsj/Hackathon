import * as React from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

// Components
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import ImageList from '@mui/material/ImageList';
import ImageListItem from '@mui/material/ImageListItem';

// Images
import Logo from '../../assets/img/diagnostico.png';

// Nossos componentes
import Footer from '../../components/Footer';
import Dialog from '../../components/Dialog';
import { FormControl, InputLabel, MenuItem, Select, SelectChangeEvent } from '@mui/material';
import request from '../../services/api';

// Nossas pages






export function Login() {
    // Login-Routes-Navigate
    const navigate = useNavigate();
    function navigateTo(route: string) {
        navigate(route);
    }

    // Login-Modal-Handler
    const [openDialog, setOpenDialog] = useState(false);
    const [dialogTitle, setDialogTitle] = useState('');
    const [dialogDescription, setDialogDescription] = useState('');
    const [dialogContent, setDialogContent] = useState('');

    const handleOpenDialog = () => {
        setOpenDialog(true);

    }
    const handleCloseDialog = () => {
        setOpenDialog(false);
    }

    // Login-Perfil-Select
    const [perfilId, setPerfilId] = useState('');

    const handlePerfilIdChange = (event: SelectChangeEvent) => {
        setPerfilId(event.target.value as string);
    }

    // Login-Submit - Tem que mudar como fazemos isso, pois apertar qualquer botão dá submit
    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        const dataForm = new FormData(event.currentTarget);

        let payload = {
            email: dataForm.get('email'),
            password: dataForm.get('password'),
            code: '995',
        }

        request<any>('post', 'login', payload)
            .then(response => {
                if (response.status === 200) {
                    console.log(response.data)
                    if (response.data.perfis === 'DOCTOR;') {
                        navigate('/dashboard/medico')
                    }
                } else {
                    console.log(response.status, response.data)
                }
            })
            .catch(err => {
                console.log(err)
            })
    };

    return (
        <div>
            <Grid container component="main" sx={{ height: '100vh' }} >
                <Grid
                    component={Paper}
                    elevation={6}
                    square
                    item
                    xs={false}
                    sm={4}
                    md={7}
                    sx={{
                        backgroundImage: 'url(https://images.ctfassets.net/fhvti7ztpwfk/6VUjfzPgC84pG3RscNYXj1/d949fc87a4ff5b9ae7c0ec3370e7fa64/2x-half-billboard-lilly-life-picture-15033-4578.jpg)',
                        backgroundRepeat: 'no-repeat',
                        backgroundColor: (t: any) =>
                            t.palette.mode === 'light' ? t.palette.grey[50] : t.palette.grey[900],
                        backgroundSize: 'cover',
                        backgroundPosition: 'center',
                    }}
                />
                <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
                    <Box
                        sx={{
                            my: 6,
                            mx: 4,
                            display: 'flex',
                            flexDirection: 'column',
                            alignItems: 'center',
                        }}
                    >
                        <ImageList cols={1}>
                            <ImageListItem>
                                <img
                                    src={`${Logo}?fit=crop&auto=format`}
                                    loading="lazy"
                                />
                            </ImageListItem>
                        </ImageList>
                        <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 1 }}>
                            <TextField
                                margin="normal"
                                required
                                fullWidth
                                id="email"
                                label="E-mail"
                                name="email"
                                autoComplete="email"
                                autoFocus
                            />
                            <TextField
                                margin="normal"
                                required
                                fullWidth
                                name="password"
                                label="Senha"
                                type="password"
                                id="password"
                                autoComplete="current-password"
                            />
                            <Grid container direction="row" justifyContent="space-between" alignItems="center">
                                <Grid item>
                                    <FormControlLabel
                                        control={<Checkbox value="remember" color="primary" />}
                                        label="Lembrar-me"
                                    />
                                </Grid>
                                <Grid item>
                                    <Button onClick={() => {
                                        setDialogTitle('Esqueci minha senha');
                                        setDialogDescription('Digite seu CRM e CRMUF para redefinir sua senha.');
                                        setDialogContent('ForgotPassword')
                                        handleOpenDialog();
                                    }}>
                                        Esqueci a senha
                                    </Button>
                                </Grid>
                            </Grid>
                            {/*Todo: Melhorar a forma de fazer esse url compose do onClick*/}
                            <Button
                                type='submit'
                                fullWidth
                                variant="contained"
                                sx={{ mt: 3, mb: 1 }}
                            >
                                Entrar
                            </Button>
                            <Button
                                onClick={() => navigateTo('cadastro/medico')}
                                fullWidth
                                variant="contained"
                                sx={{ mt: 1, mb: 2 }}
                            >
                                Cadastro de Médico
                            </Button>
                            <Box sx={{ minWidth: 120 }}>
                                <FormControl fullWidth>
                                    <InputLabel id="profileId">Profile</InputLabel>
                                    <Select
                                        labelId="profileId"
                                        id="profileId-select"
                                        value={perfilId}
                                        label="Age"
                                        onChange={handlePerfilIdChange}
                                    >
                                        <MenuItem value={'medico'}>Médico</MenuItem>
                                        <MenuItem value={'operacao'}>Operação</MenuItem>
                                        <MenuItem value={'laboratorio'}>Laboratório</MenuItem>
                                    </Select>
                                </FormControl>
                            </Box>
                        </Box>
                    </Box>
                </Grid>
                <Footer />
                <Dialog
                    open={openDialog}
                    onClose={handleCloseDialog}
                    title={dialogTitle}
                    description={dialogDescription}
                    content={dialogContent}
                >
                </Dialog>
            </Grid>
        </div>
    )
}