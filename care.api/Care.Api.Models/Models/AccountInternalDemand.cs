using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AccountInternalDemand
{
    public Guid Id { get; set; }

    public Guid LaboratoryId { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? ValidationResultId { get; set; }

    public Guid? AccountSettingsByProgramId { get; set; }

    public virtual AccountSettingsByProgram AccountSettingsByProgram { get; set; }

    public virtual ValidationResult ValidationResult { get; set; }
}
