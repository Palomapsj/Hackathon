using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpMedico
{
    public Guid Doctorid { get; set; }

    public string Licensenumber { get; set; }

    public string Licensestate { get; set; }

    public string ClienteIdentificacao { get; set; }

    public string ClienteNome { get; set; }
}
