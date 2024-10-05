using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TblCorrecaoInfuso
{
    public long? Ordem { get; set; }

    public Guid Id { get; set; }

    public Guid? InfusionId { get; set; }

    public string Name { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? PreviewDate { get; set; }

    public DateTime? ActualDate { get; set; }

    public string OptionName { get; set; }

    public string InternalControl { get; set; }
}
