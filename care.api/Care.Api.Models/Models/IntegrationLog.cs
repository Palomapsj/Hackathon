using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class IntegrationLog
{
    public Guid Id { get; set; }

    public string Send { get; set; }

    public string Return { get; set; }

    public string Description { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string CreatedByName { get; set; }

    public int Attempt { get; set; }
}
