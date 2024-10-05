using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class UserSystemLog
{
    public Guid Id { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? UserId { get; set; }

    public string? ActionName { get; set; }

    public int? ActionOrder { get; set; }

    public string? ActionKey { get; set; }

    public string? ActionValue { get; set; }

    public string? ActionDescription { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual User? User { get; set; }
}
