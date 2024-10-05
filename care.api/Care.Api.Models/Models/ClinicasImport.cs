using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ClinicasImport
{
    public string Tipo { get; set; }

    public string Cnpj { get; set; }

    public string Doenca { get; set; }

    public string Procedimento { get; set; }

    public int ColunaIdentity { get; set; }
}
