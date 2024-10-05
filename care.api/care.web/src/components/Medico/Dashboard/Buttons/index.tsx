import React from "react"
import { MenuButtonsProps } from "./types"
import { Button, ButtonGroup } from "@mui/material"
import { Link } from 'react-router-dom';



export const DoctorMenuButtons: React.FC<MenuButtonsProps> = (props: MenuButtonsProps) => {
    return (
        <ButtonGroup variant='text' orientation='vertical' aria-label='Opções de menu'>
            <Button component={Link} to='/dashboard/medico'>
                Pacientes cadastrados
            </Button>
            <Button component={Link} to='/dashboard/medico/pacienteexame/cadastro'>
                Cadastrar paciente / exame
            </Button>
            <Button component={Link} to='/dashboard/medico/protocolos/pendentes'>
                Protocolos pendentes
            </Button>
        </ButtonGroup>
    )
}