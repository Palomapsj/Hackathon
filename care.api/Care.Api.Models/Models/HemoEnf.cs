using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class HemoEnf
{
    public string Enfremeio { get; set; }

    public string Hemocentro { get; set; }

    public string Referência { get; set; }

    public string Local { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Doença { get; set; }
}
