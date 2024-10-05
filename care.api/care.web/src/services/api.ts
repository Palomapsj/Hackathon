import axios, { AxiosRequestConfig, AxiosResponse, Method } from "axios";
import { AxiosInstance } from "axios";

const api: AxiosInstance = axios.create({
    baseURL: 'https://homologacao.suporteaopaciente.com.br/Rest_Lilly',
    timeout: 10000,
});

const request = async<T>(
    method: Method,
    url: string,
    data?: any,
    headers?: AxiosRequestConfig['headers'],
): Promise<AxiosResponse<T>> => {
    const config: AxiosRequestConfig = { method, url, headers }
    if (data) {
        config.data = data
    }
    return api.request<T>(config)
}

export default request