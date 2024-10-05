using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AkkaMessage
{
    public Guid Id { get; set; }

    public Guid? AkkaActorsId { get; set; }

    public string AkkaActorsIdName { get; set; }

    public Guid? AkkaActorsProgramId { get; set; }

    public string AkkaActorsProgramIdName { get; set; }

    public Guid? EntityMetadataId { get; set; }

    public string EntityMetadataIdName { get; set; }

    public Guid? SourceEntityMetadataId { get; set; }

    public string SourceEntityMetadataIdName { get; set; }

    public string Name { get; set; }

    public bool? IsActive { get; set; }
}
