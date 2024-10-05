using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class PacientesPesquisa
{
    public string Programa { get; set; }

    public string OrigemPaciente { get; set; }

    public Guid PatientId { get; set; }

    public string CodigoPaciente { get; set; }
}
