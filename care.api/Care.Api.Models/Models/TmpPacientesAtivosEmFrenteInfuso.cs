using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpPacientesAtivosEmFrenteInfuso
{
    public int? Infusões { get; set; }

    public string FriendlyCode { get; set; }

    public DateTime? DataDaInfusão { get; set; }
}
