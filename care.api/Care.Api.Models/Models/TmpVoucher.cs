using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpVoucher
{
    public string Codigo { get; set; }

    public string PacientesQueReceberamOBeneficioDeIt { get; set; }

    public string AnoMês { get; set; }
}
