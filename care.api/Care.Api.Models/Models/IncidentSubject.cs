using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class IncidentSubject : BaseEntity
{

    public string? Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual ICollection<IncidentTypeDetailProgram>? IncidentTypeDetailPrograms { get; } = new List<IncidentTypeDetailProgram>();

    public virtual ICollection<Incident>? Incidents { get; } = new List<Incident>();

    public virtual StringMap? StatusCodeStringMap { get; set; }
}
