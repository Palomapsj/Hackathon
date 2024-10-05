using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpLogisticSchedule
{
    public string NomeDoPrograma { get; set; }

    public string NomeDoMaterial { get; set; }

    public string CodigoNoMaterial { get; set; }

    public string DocumentStatus { get; set; }

    public string ProgramaNoCare { get; set; }

    public string IdProgramaCare { get; set; }

    public string IdMedicamentoCare { get; set; }
}
