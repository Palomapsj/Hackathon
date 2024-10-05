using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class HealthProfessionalAccount
{
    public Guid AccountId { get; set; }

    public Guid HealthProfessionalId { get; set; }
}
