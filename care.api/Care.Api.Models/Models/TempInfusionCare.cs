using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TempInfusionCare
{
    public long? Row { get; set; }

    public Guid? TreatmentId { get; set; }

    public DateTime? MostRecentAdministrationDate { get; set; }

    public string WhoAdministerTreatment { get; set; }
}
