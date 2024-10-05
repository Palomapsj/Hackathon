using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TbRelatorioJanssenSustenna
{
    public string Código { get; set; }

    public string OrigemCadastro { get; set; }

    public string Patologia { get; set; }

    public string MedicamentoAtual { get; set; }

    public string MedicamentoAnterior { get; set; }

    public string MedicamentoAnterior1 { get; set; }

    public string OrigemTratamento { get; set; }

    public string InformaçõesPrimeiroLaudo { get; set; }

    public string NovoLaudoEnviadoEstáCorreto { get; set; }

    public string StatusDoPaciente { get; set; }

    public string Fase { get; set; }

    public string DtCadastro { get; set; }

    public string MêsCadastro { get; set; }

    public string AnoCadastro { get; set; }

    public string FormaDeAquisição { get; set; }

    public string PossuiPlanoDeSaúde { get; set; }

    public string PlanoDeSaúde { get; set; }

    public string PlanoDeSaúdeDetalhe { get; set; }

    public string TipoDeAcesso { get; set; }

    public string StatusAcesso { get; set; }

    public string SubstatusAcesso { get; set; }

    public string DtInícioTentativa { get; set; }

    public string DtFinalTentativa { get; set; }

    public string MesAcesso { get; set; }

    public string AnoAcesso { get; set; }

    public int TempoDeAcessoDias { get; set; }

    public string TempoDeAcessoDiasResumo { get; set; }

    public string CidadePaciente { get; set; }

    public string UfPaciente { get; set; }

    public string MédicoPrescritor { get; set; }

    public string CrmMédicoPrescritor { get; set; }

    public string CrmUfMédicoPrescritor { get; set; }

    public string MédicoAcompanhamento { get; set; }

    public string CrmMédicoAcompanhamento { get; set; }

    public string CrmUfMédicoAcompanhamento { get; set; }

    public string CidadeMédicoAcompanhamento { get; set; }

    public string DtInícioTratamento { get; set; }

    public int TempoDeTratamentoEmMesesPersistência { get; set; }

    public string TempoDeTratamentoEmMesesPersistênciaResumo { get; set; }

    public string DtInativação { get; set; }

    public string MotivoDeInativação { get; set; }

    public string MêsInativação { get; set; }

    public int AnoInativação { get; set; }

    public int? TempoDeProgramaEmMeses { get; set; }

    public string TempoDeProgramaEmMesesResumo { get; set; }

    public string PacientesQueSolicitaramOBeneficioDeIt { get; set; }

    public string PacientesQueReceberamOBenefícioDeIt { get; set; }

    public string DataDoÚltimoEnvioDoBenefícioDeIt { get; set; }

    public int QtdDeEnviosBenefícioDeIt { get; set; }

    public int? DiaDoTratamentoDoBenefícioDeIt { get; set; }

    public string DoseDoBenefícioDeIt { get; set; }

    public string MigrouDoBeneficioDeIt { get; set; }

    public string DtDaMigração { get; set; }

    public string LocalQueRecebeuOBenefícioDeIt { get; set; }

    public string DtÚltimoContato { get; set; }

    public string DtÚltimoContatoSucesso { get; set; }

    public int? QtdContatosSemSucesso { get; set; }

    public string ExcedeuLimiteDoBenefício { get; set; }

    public int? MêsCadastroNum { get; set; }

    public string MesAcessoNum { get; set; }

    public int MêsInativaçãoNum { get; set; }
}
