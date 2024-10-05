using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TreatmentReceitadevidaFind
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public string FullName { get; set; }

    public string Cpf { get; set; }
}
