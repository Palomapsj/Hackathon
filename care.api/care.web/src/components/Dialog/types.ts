import { DialogProps } from '@mui/material/Dialog';

export interface MyDialogProps extends DialogProps {
    title: string;
    description: string;
    content: string;
    onClose: (event: any, reason: any ) => void;
}