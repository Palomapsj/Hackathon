import { createTheme, responsiveFontSizes } from '@mui/material/styles';
import { ptBR as MaterialptBR } from '@mui/material/locale';
import { ptBR as MaterialDataGridptBR } from '@mui/x-data-grid/locales';
import { ptBR as MaterialDataPickersptBR } from '@mui/x-date-pickers/locales';

let theme = createTheme({
    palette: {
        primary: {
            main: '#d52b1e',
            light: '#FFFFFF',
            dark: '#000000'
        },
        secondary: {
            main: '#AF9D95',
            light: '#AF9D95',
            dark: '#82786F'
        },
    },
}, MaterialptBR, MaterialDataGridptBR, MaterialDataPickersptBR );
theme = responsiveFontSizes(theme);

export default theme;