using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpNaoEncontrado
{
    public string TipoRegistro { get; set; }

    public string DataReferência { get; set; }

    public string Doença { get; set; }

    public string TipoDeAcesso { get; set; }

    public string Local { get; set; }

    public string Medico { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Representante { get; set; }

    public string Gerente { get; set; }

    public string NewTratamentoname { get; set; }

    public string InfusionId { get; set; }

    public string StatusInfusao { get; set; }

    public decimal? QtdAmpolasIdeais { get; set; }

    public decimal? QtdAmpolas { get; set; }

    public DateTime? DataPrimeiraInfusao { get; set; }

    public DateTime? NewDatadeinativao { get; set; }

    public string NewStatusdotratamentoname { get; set; }

    public string NewSituacaoname { get; set; }
}
