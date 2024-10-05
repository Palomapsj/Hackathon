using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class EntityConfiguration
{
    public Guid Id { get; set; }

    public Guid? EntityMetadataId { get; set; }

    public string EntityMetadataIdName { get; set; }

    public bool HasSurvey { get; set; }

    public int? HasMap { get; set; }

    public bool HasCalendar { get; set; }

    public virtual ICollection<EntityMetadata> EntityMetadata { get; } = new List<EntityMetadata>();
}
