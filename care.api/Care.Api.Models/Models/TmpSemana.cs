using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpSemana
{
    public Guid Id { get; set; }

    public string Codigo { get; set; }

    public string StatusTratamento { get; set; }

    public string Nome { get; set; }

    public string Mes { get; set; }

    public string Semana { get; set; }

    public int? Qtde { get; set; }

    public Guid InfusionId { get; set; }

    public string StatusInfusao { get; set; }

    public DateTime? DataInfusao { get; set; }

    public string RazaoNaoRealizacao { get; set; }

    public string TipoDeInfusão { get; set; }

    public string EstaNoKpi { get; set; }
}
