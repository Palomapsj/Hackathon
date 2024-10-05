import * as React from 'react';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import Link from '@mui/material/Link';

function Copyright() {
    return (
        <Typography variant="body2" color="text.secondary">
            {'Copyright © '}
            <Link color="inherit" href="#">
            Eli Lilly and Company. Todos os direitos reservados.
            </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

export default function StickyFooter() {
    return (
        <Grid component="footer" container direction="row" justifyContent="center" alignItems="center" spacing="10">
            <Grid item>
                <Typography>
                   
                </Typography>
            </Grid>
            <Grid item>
                <Copyright />
            </Grid>
        </Grid>
    );
}