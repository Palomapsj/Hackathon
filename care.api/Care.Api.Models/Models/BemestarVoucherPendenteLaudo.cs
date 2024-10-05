using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class BemestarVoucherPendenteLaudo
{
    public string CódigoDoPaciente { get; set; }

    public string Nome { get; set; }

    public string StatusAtualizado { get; set; }

    public string NúmeroVoucherAzimute { get; set; }

    public DateTime DataProcedimento { get; set; }

    public string LocalProcedimento { get; set; }

    public string TipoDeAnálise { get; set; }
}
