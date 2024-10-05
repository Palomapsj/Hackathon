using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Especialidade
{
    public Guid? Doctorid { get; set; }

    public Guid? Healthprogramid { get; set; }

    public string Especialidade1 { get; set; }
}
