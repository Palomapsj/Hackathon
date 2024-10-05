using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpVial
{
    public string TipoRegistro { get; set; }

    public Guid Id { get; set; }

    public string DataReferencia { get; set; }

    public string CodigoPaciente { get; set; }

    public Guid Infusionid { get; set; }

    public string TipoDeInfusao { get; set; }

    public string Local { get; set; }

    public string StatusInfusao { get; set; }

    public decimal? QtdAmpolas { get; set; }

    public decimal? QtdAmpolasIdeais { get; set; }
}
