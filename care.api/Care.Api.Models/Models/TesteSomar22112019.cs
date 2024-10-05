using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TesteSomar22112019
{
    public Guid Id { get; set; }

    public string Situacao { get; set; }

    public string StatusDoTratamento { get; set; }

    public string StatusDetalheDoTratamento { get; set; }

    public int? AnoInativacao { get; set; }

    public string MesInativacao { get; set; }

    public string Medico { get; set; }

    public string FriendlyCode { get; set; }
}
