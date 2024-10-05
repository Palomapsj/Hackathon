using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpAmpola
{
    public Guid Treatmentid { get; set; }

    public Guid Infusionid { get; set; }

    public string Name { get; set; }

    public decimal? Weight { get; set; }

    public decimal? WeightAnterior { get; set; }

    public decimal? Ampouleamountexpected { get; set; }

    public decimal? Ampouleamountcorrigido { get; set; }

    public decimal? Ampouleamount { get; set; }
}
