import { toast, ToastOptions, ToastPosition } from "react-toastify";

export const info = (message: string, duration = 2000, position: ToastPosition = toast.POSITION.TOP_RIGHT) => {
    toast.info(message, {
        position,
        autoClose: duration,
        closeOnClick: true
    } as ToastOptions);
};

export const success = (message: string, duration = 2000, position: ToastPosition = toast.POSITION.TOP_RIGHT) => {
    toast.success(message, {
        position,
        autoClose: duration,
        closeOnClick: true
    } as ToastOptions);
};

export const warning = (message: string, duration = 2000, position: ToastPosition = toast.POSITION.TOP_RIGHT) => {
    toast.warning(message, {
        position,
        autoClose: duration,
        closeOnClick: true
    } as ToastOptions);
};

export const error = (message: string, duration = 2000, position: ToastPosition = toast.POSITION.TOP_RIGHT) => {
    toast.error(message, {
        position,
        autoClose: duration,
        closeOnClick: true
    } as ToastOptions);
};