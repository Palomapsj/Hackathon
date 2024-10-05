using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpPacientesAtivosEmFrenteVisitum
{
    public int? QuantidadeDeVisitas { get; set; }

    public string FriendlyCode { get; set; }

    public DateTime? DataDaVisita { get; set; }
}
