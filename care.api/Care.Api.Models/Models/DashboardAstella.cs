using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class DashboardAstella
{
    public int TableId { get; set; }

    public string CodigoDoPaciente { get; set; }

    public string Fase { get; set; }

    public string OperadoraDeSaude { get; set; }

    public DateTime? DataLigacao { get; set; }

    public int? LigacaoAtiva { get; set; }

    public int? LigacaoReceptiva { get; set; }

    public string FormaDeAcesso { get; set; }

    public string TipoDeAcesso { get; set; }

    public string AccessStatus { get; set; }

    public string LocalDeAcesso { get; set; }

    public int? TempoEmAcessoEmDias { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Ufmedico { get; set; }

    public string PerfilPaciente { get; set; }

    public string Glosas { get; set; }
}
