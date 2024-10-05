using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TblClinica
{
    public string NomePaciente { get; set; }

    public string CpfClinica { get; set; }

    public string VoucherClinica { get; set; }

    public DateTime? DataRealizadaClinica { get; set; }

    public string StatusVoucherClinica { get; set; }

    public string LocalExameClinica { get; set; }
}
