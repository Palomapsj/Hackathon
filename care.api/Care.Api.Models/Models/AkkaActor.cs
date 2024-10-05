using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AkkaActor
{
    public Guid Id { get; set; }

    public Guid? EntityMetadataId { get; set; }

    public string EntityMetadataIdName { get; set; }

    public string Name { get; set; }

    public string Path { get; set; }

    public bool? IsHealthProgramActor { get; set; }

    public bool? IsBroadCastActor { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AkkaPublishEvent> AkkaPublishEvents { get; } = new List<AkkaPublishEvent>();

    public virtual ICollection<AkkaSubscribeEvent> AkkaSubscribeEvents { get; } = new List<AkkaSubscribeEvent>();

    public virtual ICollection<HealthProgram> HealthPrograms { get; } = new List<HealthProgram>();
}
