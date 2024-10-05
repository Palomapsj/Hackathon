using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class SectionExcludedByPhase
{
    public Guid SectionExcludedByPhaseId { get; set; }

    public Guid PhaseId { get; set; }

    public Guid SectionMetadataId { get; set; }

    public Guid HealthProgramId { get; set; }

    public Guid EntityMetadataId { get; set; }

    public virtual EntityMetadata EntityMetadata { get; set; }
}
