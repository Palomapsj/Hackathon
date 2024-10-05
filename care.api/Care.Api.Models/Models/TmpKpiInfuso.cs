using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpKpiInfuso
{
    public string NewTratamentoname { get; set; }

    public string InfusionId { get; set; }

    public decimal? QtdAmpolas { get; set; }

    public decimal? QtdAmpolasIdeais { get; set; }

    public string Local { get; set; }

    public string StatusInfusao { get; set; }
}
