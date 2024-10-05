using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Feriado
{
    public short NrAno { get; set; }

    public short NrMes { get; set; }

    public short NrDia { get; set; }

    public string TpFeriado { get; set; }

    public string DsFeriado { get; set; }

    public string SgUf { get; set; }
}
