using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class VMonitoramentoEnzimai
{
    public string AnoMes { get; set; }

    public string CodigoPaciente { get; set; }

    public Guid IdInfusaoCare { get; set; }

    public string StatusInfusaoCare { get; set; }

    public string TipoDeInfusao { get; set; }

    public string ClassificacaoInfusoes { get; set; }

    public string IdInfusaoClinica { get; set; }

    public string IdSiteAprovacao { get; set; }

    public string StatusAprovacao { get; set; }

    public string Clinica { get; set; }

    public string LoteClinica { get; set; }

    public string DeclaracaoClinica { get; set; }

    public string DescricaoDeclaracaoClinica { get; set; }

    public string LoteSiteAprovacao { get; set; }

    public string TipoAcesso { get; set; }

    public string Fase { get; set; }

    public string Situacao { get; set; }

    public string Doenca { get; set; }

    public string Medicamento { get; set; }
}
