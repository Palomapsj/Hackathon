using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TblCare
{
    public string CodigoDoPaciente { get; set; }

    public string CpfCare { get; set; }

    public string VoucherCare { get; set; }

    public DateTime? DataAgendadaCare { get; set; }

    public DateTime? DataRealizadoCare { get; set; }

    public string TipoDoExameCare { get; set; }

    public string StatusDoExameCare { get; set; }

    public string LocalExameCare { get; set; }

    public Guid Diagnosticid { get; set; }

    public Guid? Exameid { get; set; }
}
