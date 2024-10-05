using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class RepresentativeRegion
{
    public Guid Id { get; set; }

    public string AddressState { get; set; }

    public bool? IsMainRepresentative { get; set; }

    public Guid? ValidationResultId { get; set; }

    public Guid? RepresentativeId { get; set; }

    public Guid? ProgramId { get; set; }

    public virtual Representative Representative { get; set; }

    public virtual ValidationResult ValidationResult { get; set; }
}
