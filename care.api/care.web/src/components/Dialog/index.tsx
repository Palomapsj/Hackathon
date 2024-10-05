import { Dialog as DialogMui } from '@mui/material';
import { MyDialogProps } from './types';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';

export default function Dialog(props: MyDialogProps) {
    const content = props.content;
    return (
        <div>
            {content === 'ForgotPassword' ?
                <DialogMui open={props.open} onClose={props.onClose} aria-labelledby='modal-modal-title' aria-describedby='modal-modal-description'>
                    <Grid container justifyContent='center' alignItems='center'>
                        <Grid item>
                            <Card>
                                <CardContent>
                                    <Typography variant='h3' align='center'>{props.title}</Typography>
                                    <Typography component='p' align='center'>{props.description}</Typography>
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="CRM"
                                        label="CRM"
                                        name="CRM"
                                        autoComplete="CRM"
                                        autoFocus
                                    />
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        name="CRMUF"
                                        label="CRMUF"
                                        type="CRMUF"
                                        id="CRMUF"
                                        autoComplete="CRMUF"
                                    />
                                    <Button
                                        onClick={(event) => props.onClose(event, 'backdropClick')}
                                        size='small'
                                        variant="contained"
                                        sx={{ mt: 3, mb: 1 }}
                                    >
                                        Solicitar senha
                                    </Button>
                                </CardContent>
                            </Card>
                        </Grid>
                    </Grid>
                </DialogMui>
                : ''
            }
        </div >
    )
}