using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ValidationResult
{
    public Guid Id { get; set; }

    public bool IsValidSpecific { get; set; }

    public string Message { get; set; }

    public virtual ICollection<AccountInternalDemand> AccountInternalDemands { get; } = new List<AccountInternalDemand>();

    public virtual ICollection<RepresentativeRegion> RepresentativeRegions { get; } = new List<RepresentativeRegion>();

    public virtual ICollection<Template> Templates { get; } = new List<Template>();
}
