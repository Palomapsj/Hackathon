import React, { Suspense } from 'react';
import ReactDOM from 'react-dom/client';
import CssBaseline from '@mui/material/CssBaseline';
// Theme e Date
import theme from '../src/styles/Theme';
import { ThemeProvider } from '@mui/material/styles';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import 'dayjs/locale/pt-br';
// Routing
import { RouterProvider } from 'react-router-dom';
import { router } from '../src/routes/router';

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

// Todo: Loading fallback page

root.render(
    <React.StrictMode>
        <CssBaseline enableColorScheme />
        <ThemeProvider theme={theme}>
            <LocalizationProvider dateAdapter={AdapterDayjs} adapterLocale='pt-br'>
                <RouterProvider router={router} fallbackElement={null} />
            </LocalizationProvider>
        </ThemeProvider>
    </React.StrictMode >
);


// Todo: Rever todas as telas antes da integração total