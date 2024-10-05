using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpPacienteEnrolled
{
    public Guid? Doctorid { get; set; }

    public int? Qtde { get; set; }
}
