using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ProcessLog
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public int EntityCode { get; set; }

    public string EntityName { get; set; }

    public Guid ObjectId { get; set; }

    public int Status { get; set; }

    public bool IsScreenLocker { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? EndProcessOn { get; set; }

    public string ErrorMessage { get; set; }

    public byte[] Version { get; set; }

    public virtual ICollection<StepLog> StepLogs { get; } = new List<StepLog>();
}
