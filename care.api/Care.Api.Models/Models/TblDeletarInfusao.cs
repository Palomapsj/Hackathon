using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TblDeletarInfusao
{
    public long? Ordem { get; set; }

    public Guid Id { get; set; }

    public DateTime? CreatedOn { get; set; }
}
