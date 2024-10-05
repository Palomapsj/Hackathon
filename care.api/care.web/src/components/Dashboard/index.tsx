import React, { useEffect, useState } from 'react';
import { styled } from '@mui/material/styles';
import MuiDrawer from '@mui/material/Drawer';
import Box from '@mui/material/Box';
import MuiAppBar, { AppBarProps as MuiAppBarProps } from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import Badge from '@mui/material/Badge';
import Container from '@mui/material/Container';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import NotificationsIcon from '@mui/icons-material/Notifications';
import { useNavigate } from 'react-router-dom';

// General
import Footer from '../Footer';
import { DashboardProps } from './types';
// Doctor
import { DoctorMenuButtons } from '../Medico/Dashboard/Buttons';
import { DoctorMainSection } from '../Medico/Dashboard/Main';
// Operation
import { OperationMenuButtons } from '../Operacao/Dashboard/Buttons';
import { OperationMainSection } from '../Operacao/Dashboard/Main';
// Laboratory
import { LaboratoryMenuButtons } from '../Laboratorio/Dashboard/Buttons';
import { LaboratoryMainSection } from '../Laboratorio/Dashboard/Main';

const drawerWidth: number = 280;

interface AppBarProps extends MuiAppBarProps {
    open?: boolean;
}

const AppBar = styled(MuiAppBar, {
    shouldForwardProp: (prop) => prop !== 'open',
})<AppBarProps>(({ theme, open }) => ({
    zIndex: theme.zIndex.drawer + 1,
    transition: theme.transitions.create(['width', 'margin'], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
    }),
    ...(open && {
        marginLeft: drawerWidth,
        width: `calc(100% - ${drawerWidth}px)`,
        transition: theme.transitions.create(['width', 'margin'], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.enteringScreen,
        }),
    }),
}));

const Drawer = styled(MuiDrawer, { shouldForwardProp: (prop) => prop !== 'open' })(
    ({ theme, open }) => ({
        '& .MuiDrawer-paper': {
            position: 'relative',
            whiteSpace: 'nowrap',
            width: drawerWidth,
            transition: theme.transitions.create('width', {
                easing: theme.transitions.easing.sharp,
                duration: theme.transitions.duration.enteringScreen,
            }),
            boxSizing: 'border-box',
            ...(!open && {
                overflowX: 'hidden',
                transition: theme.transitions.create('width', {
                    easing: theme.transitions.easing.sharp,
                    duration: theme.transitions.duration.leavingScreen,
                }),
                width: theme.spacing(7),
                [theme.breakpoints.up('sm')]: {
                    width: theme.spacing(9),
                },
            }),
        },
    }),
);


export const Dashboard: React.FC<DashboardProps> = ({ viewName, profileName }) => {
    // Texts
    const [appBarTitle, setAppBarTitle] = useState('');

    useEffect(() => {
        // Title - Doctor
        // Main Page
        if (profileName === 'medico' && viewName === 'pacientes') {
            setAppBarTitle('Pacientes Cadastrados')
        }
        // New Patient and Exam
        if (profileName === 'medico' && viewName === 'novoPacienteExame') {
            setAppBarTitle('Cadastro do Paciente / Solicitação de Exame')
        }
        // Pending Protocols
        if (profileName === 'medico' && viewName === 'protocolosPendentes') {
            setAppBarTitle('Protocolos Pendentes')
        }

        // Title - Operation
        // Main Page
        if (profileName === 'operacao' && viewName === 'pacientes') {
            setAppBarTitle('Pacientes Cadastrados')
        }
        // New Patient and Exam
        if (profileName === 'operacao' && viewName === 'novoPacienteExame') {
            setAppBarTitle('Cadastro do Paciente / Solicitação de Exame')
        }
        // Doctors from Program
        if (profileName === 'operacao' && viewName === 'medicosDoPrograma') {
            setAppBarTitle('Médicos do Programa')
        }

        // Title - Laboratory
        // Main Page
        if (profileName === 'laboratorio' && viewName === 'exames') {
            setAppBarTitle('Todos os Exames')
        }
        // Scheduled Exams
        if (profileName === 'laboratorio' && viewName === 'examesAgendados') {
            setAppBarTitle('Exames Agendados')
        }
        // Exams Under Analysis
        if (profileName === 'laboratorio' && viewName === 'examesEmAnalise') {
            setAppBarTitle('Exames em Análise')
        }

    })

    // Drawer
    const [open, setOpen] = useState(true);
    const toggleDrawer = () => {
        setOpen(!open);
    };

    // Routes-Navigate
    const navigate = useNavigate();
    function navigateTo(route: string) {
        navigate(route);
    }

    return (
        <Box sx={{ display: 'flex' }}>
            <AppBar position="absolute" open={open}>
                <Toolbar
                    sx={{
                        pr: '24px', // keep right padding when drawer closed
                    }}
                >
                    <IconButton
                        edge="start"
                        color="inherit"
                        aria-label="open drawer"
                        onClick={toggleDrawer}
                        sx={{
                            marginRight: '36px',
                            ...(open && { display: 'none' }),
                        }}
                    >
                        <MenuIcon />
                    </IconButton>
                    <Typography
                        component="h1"
                        variant="h6"
                        color="inherit"
                        noWrap
                        sx={{ flexGrow: 1 }}
                    >
                        {appBarTitle}
                    </Typography>
                    <IconButton color="inherit">
                        <Badge badgeContent={4} color="secondary">
                            <NotificationsIcon />
                        </Badge>
                    </IconButton>
                </Toolbar>
            </AppBar>
            <Drawer variant="permanent" open={open}>
                <Toolbar
                    sx={{
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'flex-end',
                        px: [1],
                    }}
                >
                    <IconButton onClick={toggleDrawer}>
                        <ChevronLeftIcon />
                    </IconButton>
                </Toolbar>
                <Divider />
                <List component="nav" sx={{ ml: 2 }}>
                    {profileName === 'medico' && (
                        <DoctorMenuButtons />
                    )}
                    {/*Todo: Fazer o perfilhação e inserção de botões do menu*/}
                    {profileName === 'operacao' && (
                        <OperationMenuButtons />
                    )}
                    {profileName === 'laboratorio' && (
                        <LaboratoryMenuButtons />
                    )}
                </List>
            </Drawer>
            <Box
                component="main"
                sx={{
                    backgroundColor: (theme) =>
                        theme.palette.mode === 'light'
                            ? theme.palette.grey[100]
                            : theme.palette.grey[900],
                    flexGrow: 1,
                    height: '100vh',
                    overflow: 'auto',
                }}
            >
                <Toolbar />
                <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
                    {/*Todo: Implementar a perfilhação corretamente*/}
                    {profileName === 'medico' && (
                        <DoctorMainSection viewName={viewName} profileName={profileName} />
                    )}
                    {profileName === 'operacao' && (
                        <OperationMainSection viewName={viewName} profileName={profileName} />
                    )}
                    {profileName === 'laboratorio' && (
                        <LaboratoryMainSection viewName={viewName} profileName={profileName} />
                    )}
                    <Footer />
                </Container>
            </Box>
        </Box >
    );
}