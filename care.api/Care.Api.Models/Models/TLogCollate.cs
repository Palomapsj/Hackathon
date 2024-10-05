using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TLogCollate
{
    public string Tabela { get; set; }

    public string Coluna { get; set; }

    public string Tipo { get; set; }

    public string Tamanho { get; set; }

    public string Query { get; set; }

    public bool? Status { get; set; }

    public string Obs { get; set; }
}
