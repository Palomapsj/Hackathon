using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class StepLog
{
    public Guid Id { get; set; }

    public Guid? ProcessLogId { get; set; }

    public string Description { get; set; }

    public int Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? EndStepOn { get; set; }

    public string ErrorMessage { get; set; }

    public byte[] Version { get; set; }

    public virtual ProcessLog ProcessLog { get; set; }
}
