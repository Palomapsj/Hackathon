using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TblNovartisGeral
{
    public string Programa { get; set; }

    public Guid? PacienteId { get; set; }

    public string CodigoPaciente { get; set; }

    public string Cpfpaciente { get; set; }

    public string NomePaciente { get; set; }

    public string Fase { get; set; }

    public string Patologia { get; set; }

    public string FaseDaPatologia { get; set; }

    public string Medicamento { get; set; }

    public Guid? DoctorId { get; set; }

    public string TipoAnalise { get; set; }

    public DateTime? DataAniversario { get; set; }

    public string Genero { get; set; }

    public string NecessitaDevolucao { get; set; }

    public Guid? InstituicaoPacienteId { get; set; }

    public Guid? Healthprogramid { get; set; }

    public string TelefonePaciente { get; set; }

    public string EmailPaciente { get; set; }

    public string CidadeDoPaciente { get; set; }

    public string UfDoPaciente { get; set; }

    public bool? AlteraçãoManual { get; set; }

    public string PrecisaDeLogística { get; set; }

    public string TipoAnaliseMédico { get; set; }

    public string CreatedByName { get; set; }

    public DateTime? Criadoem { get; set; }

    public string Medico { get; set; }

    public string Crm { get; set; }

    public bool? StatusDoMédico { get; set; }

    public string Ufcrm { get; set; }

    public string Especialidade { get; set; }

    public string CodigoDoExame { get; set; }

    public DateTime? DataSolicitacaoExame { get; set; }

    public string ExameSolicitado { get; set; }

    public string StatusExame { get; set; }

    public Guid? ExamId { get; set; }

    public Guid? Voucherid { get; set; }

    public string Voucher { get; set; }

    public string ProgramaVoucher { get; set; }

    public DateTime? VoucherCriadoEm { get; set; }

    public DateTime? VoucherUsadoEm { get; set; }

    public string StatusVoucher { get; set; }

    public string ConsultorVoucher { get; set; }

    public string GerenteVoucher { get; set; }

    public string InstituicaoPaciente { get; set; }

    public string CnpjinstituicaoPaciente { get; set; }

    public Guid? TreatmentId { get; set; }

    public string UfinstituicaoPaciente { get; set; }

    public string EnderecoInstituicaoPaciente { get; set; }

    public string NumeroInstituicaoPaciente { get; set; }

    public Guid? LogisticsScheduleId { get; set; }

    public DateTime? DataAgendamentoLogistica { get; set; }

    public DateTime? DocumentosPendentesPfs { get; set; }

    public DateTime? DocumentosPendentes { get; set; }

    public DateTime? DataSolicitacaoProtocolo { get; set; }

    public string DataRecolhimento { get; set; }

    public DateTime? DataTransporte { get; set; }

    public DateTime? DataPendenciaRecebimentoColeta { get; set; }

    public string PendenciaRecebimentoColeta { get; set; }

    public DateTime? DataAgendadoPosPendenciaRecebimentoColeta { get; set; }

    public string DataColetaEmAnalise { get; set; }

    public string DataLaudoAnexado { get; set; }

    public DateTime? DataDevolucaoLogistica { get; set; }

    public DateTime? DataConclusao { get; set; }

    public string Visao { get; set; }

    public string ParceiroLogístico { get; set; }

    public string Motivo { get; set; }

    public string TipoDeColeta { get; set; }

    public string Resultado { get; set; }

    public string ResultadoCompleto { get; set; }

    public string Multirao { get; set; }

    public string CodigoMultirao { get; set; }

    public DateTime? DataMultirao { get; set; }

    public string Laboratorio { get; set; }

    public string Uflaboratorio { get; set; }

    public string MotivoCancelamentoVoucher { get; set; }

    public DateTime? DataCancelamentoVoucher { get; set; }

    public string CanceladoPor { get; set; }
}
