import { Route, createBrowserRouter, createRoutesFromElements, useLocation } from 'react-router-dom'
import { Login } from '../pages/Login';
import { Dashboard } from '../components/Dashboard';
import { CadastroMedico } from '../pages/Medico/Cadastro/Medico';

// Todo: Error page

export const router = createBrowserRouter(
    createRoutesFromElements(
        <Route path='/'>
            <Route index element={<Login />} />

            {/*Medico*/}
            <Route path='cadastro/medico' element={<CadastroMedico />} />
            <Route path='dashboard/medico' element={<Dashboard viewName='pacientes' profileName='medico' />} />
            <Route path='dashboard/medico/pacienteexame/cadastro' element={<Dashboard viewName='novoPacienteExame' profileName='medico' />} />
            <Route path='dashboard/medico/protocolos/pendentes' element={<Dashboard viewName='protocolosPendentes' profileName='medico' />} />
            {/*Operação*/}
            <Route path='dashboard/operacao' element={<Dashboard viewName='pacientes' profileName='operacao' />} />
            <Route path='dashboard/operacao/pacienteexame/cadastro' element={<Dashboard viewName='novoPacienteExame' profileName='operacao' />} />
            <Route path='dashboard/operacao/medicos' element={<Dashboard viewName='medicosDoPrograma' profileName='operacao' />} />
            {/*Laboratório*/}
            <Route path='dashboard/laboratorio' element={<Dashboard viewName='exames' profileName='laboratorio' />} />
            <Route path='dashboard/laboratorio/exames/agendados' element={<Dashboard viewName='examesAgendados' profileName='laboratorio' />} />
            <Route path='dashboard/laboratorio/exames/analise' element={<Dashboard viewName='examesEmAnalise' profileName='laboratorio' />} />

        </Route>
    )
);