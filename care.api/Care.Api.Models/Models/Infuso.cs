using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Infuso
{
    public long? Ordem { get; set; }

    public long? OrdemSequencial { get; set; }

    public string TipoInfusaoAnterior { get; set; }

    public string LocalAnterior { get; set; }

    public Guid Treatmentid { get; set; }

    public Guid Infusionid { get; set; }

    public string TipoInfusao { get; set; }

    public string Local { get; set; }

    public decimal? QtdAmpolas { get; set; }

    public decimal? QtdAmpolasIdeais { get; set; }

    public string TipoAcesso { get; set; }

    public string InfusaoIdAprovadaClinicas { get; set; }

    public int? StatusInfusaoClinicas { get; set; }

    public string StatusInfusao { get; set; }

    public string Datareferencia { get; set; }

    public DateTime? DataRealizada { get; set; }

    public DateTime? Data { get; set; }

    public string DataInativacao { get; set; }

    public string Doenca { get; set; }
}
