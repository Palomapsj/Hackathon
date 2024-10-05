using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TempPesquisa
{
    public Guid? Diagnosticid { get; set; }

    public DateTime? DataPesquisa { get; set; }

    public string Pergunta1 { get; set; }

    public string Pergunta2 { get; set; }
}
