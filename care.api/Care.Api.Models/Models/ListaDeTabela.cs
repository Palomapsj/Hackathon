using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ListaDeTabela
{
    public long? Linha { get; set; }

    public string Tabela { get; set; }

    public string Coluna { get; set; }
}
