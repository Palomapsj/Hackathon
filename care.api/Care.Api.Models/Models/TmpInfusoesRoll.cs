using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpInfusoesRoll
{
    public Guid CódigoDoTratamento { get; set; }

    public Guid Código { get; set; }

    public string ImportCode { get; set; }

    public string DataRealizada { get; set; }

    public string DataAgendada { get; set; }

    public string Paciente { get; set; }

    public Guid CódigoPaciente { get; set; }

    public string Cpf { get; set; }

    public string OptionName { get; set; }

    public string Doença { get; set; }

    public string Médico { get; set; }

    public string Medicamento { get; set; }

    public string TipoDeAcesso { get; set; }

    public decimal? AmpouleAmount { get; set; }

    public decimal? AmpouleAmountExpected { get; set; }

    public string Situação { get; set; }

    public Guid? StatusCodeStringMapId { get; set; }

    public string LocalDaInfusão { get; set; }

    public Guid? InfusionStatusStringMapId { get; set; }

    public string StatusDaInfusão { get; set; }

    public Guid? InfusionTypeStringMapId { get; set; }

    public string Local { get; set; }

    public string DataInativação { get; set; }

    public string MotivoDoAfastamento { get; set; }

    public string DataInícioDoTratamento { get; set; }

    public string DataPrimeiroAtendimento { get; set; }

    public string DataReferência { get; set; }

    public DateTime? DataReferência2 { get; set; }

    public string CidadeDoPaciente { get; set; }

    public string EstadoDoPaciente { get; set; }

    public string DataPrimeiraInfusão { get; set; }

    public int FlagRealizado { get; set; }
}
