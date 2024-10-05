using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpInfusionTeste
{
    public Guid Id { get; set; }

    public Guid TreatmentId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? PreviewDate { get; set; }

    public DateTime? ActualDate { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string ModifiedByName { get; set; }

    public string CreatedByName { get; set; }

    public string OptionName { get; set; }
}
