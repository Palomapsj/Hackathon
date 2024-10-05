using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class IdentityCode
{
    public Guid? Id { get; set; }

    public string? Prefix { get; set; }

    public string? SequentialValue { get; set; }

    public string? Sufix { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? HealthProgramId { get; set; }
}
