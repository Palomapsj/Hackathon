﻿using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpRetorno2
{
    public Guid? TreatmentId { get; set; }

    public Guid? TreatmentSituationId { get; set; }

    public Guid? Phaseid { get; set; }

    public Guid? Treatmentstatusid { get; set; }

    public Guid? Treatmentstatusdetailid { get; set; }
}
