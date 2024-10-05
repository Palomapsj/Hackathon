using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpDataDeAdesao
{
    public Guid Id { get; set; }

    public string CodigoPaciente { get; set; }

    public string Programa { get; set; }

    public DateTime? DataDaAdesao { get; set; }
}
