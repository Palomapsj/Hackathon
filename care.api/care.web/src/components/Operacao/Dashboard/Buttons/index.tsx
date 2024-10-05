import React from "react"
import { OperationMenuButtonsProps } from "./types"
import { Button, ButtonGroup } from "@mui/material"
import { Link } from 'react-router-dom';



export const OperationMenuButtons: React.FC<OperationMenuButtonsProps> = (props: OperationMenuButtonsProps) => {
    return (
        <ButtonGroup variant='text' orientation='vertical' aria-label='Opções de menu'>
            <Button component={Link} to='/dashboard/operacao'>
                Pacientes cadastrados
            </Button>
            {/*Todo: Implementar os links abaixo*/}
            <Button component={Link} to='/dashboard/operacao/pacienteexame/cadastro'>
                Cadastrar paciente / exame
            </Button>
            <Button component={Link} to='/dashboard/operacao/medicos'>
                Médicos do programa
            </Button>
        </ButtonGroup>
    )
}