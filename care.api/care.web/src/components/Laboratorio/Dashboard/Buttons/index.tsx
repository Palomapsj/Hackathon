import React from "react"
import { LaboratoryMenuButtonsProps } from "./types"
import { Button, ButtonGroup } from "@mui/material"
import { Link } from 'react-router-dom';



export const LaboratoryMenuButtons: React.FC<LaboratoryMenuButtonsProps> = (props: LaboratoryMenuButtonsProps) => {
    return (
        <ButtonGroup variant='text' orientation='vertical' aria-label='Opções de menu'>
            <Button component={Link} to='/dashboard/laboratorio'>
                Todos os exames
            </Button>
            {/*Todo: Implementar os links abaixo*/}
            <Button component={Link} to='/dashboard/laboratorio/exames/agendados'>
                Exames Agendados
            </Button>
            <Button component={Link} to='/dashboard/laboratorio/exames/analise'>
                Médicos do programa
            </Button>
        </ButtonGroup>
    )
}