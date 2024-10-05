using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class RelatorioPacientesAtivosEmFrenteTotalVisita
{
    public DateTime? Referencia { get; set; }

    public string FriendlyCode { get; set; }

    public int? TotalDeVisita { get; set; }
}
