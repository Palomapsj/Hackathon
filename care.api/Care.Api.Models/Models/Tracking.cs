using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Tracking
{
    public Guid Id { get; set; }

    public Guid? IdRegardingObject { get; set; }

    public Guid? ObjectNewValue { get; set; }

    public Guid? ObjectOldValue { get; set; }

    public string Field { get; set; }

    public Guid? HealthProgramId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string CreatedByName { get; set; }

    public bool IsDeleted { get; set; }
}
