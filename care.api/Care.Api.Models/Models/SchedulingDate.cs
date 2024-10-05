using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class SchedulingDate
{
    public long? Ordem { get; set; }

    public Guid? LogisticsScheduleId { get; set; }

    public DateTime? Data { get; set; }

    public string StatusBefore { get; set; }

    public string StatusAfter { get; set; }

    public string Description { get; set; }
}
