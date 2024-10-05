using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ServiceType : BaseEntity
{

    public string Name { get; set; }

    public string ServiceCode { get; set; }

    public Guid? DeletedBy { get; set; }

    public string DeletedByName { get; set; }

    public string ReasonStateCode { get; set; }

    public string ReasonDeleted { get; set; }

    public string FriendlyCode { get; set; }

    public string ImportCode { get; set; }

    public string InternalControl { get; set; }

    public virtual ICollection<ResourceWorkSetting> ResourceWorkSettings { get; } = new List<ResourceWorkSetting>();

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual ICollection<HealthProgram> HealthPrograms { get; } = new List<HealthProgram>();
}
