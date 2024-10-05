using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class MenuMetadatum
{
    public Guid Id { get; set; }

    public string Menu { get; set; }

    public string IconMenu { get; set; }

    public int? MenuDisplayOrder { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? ParentMenuMetadataId { get; set; }

    public virtual ICollection<MenuMetadatum> InverseParentMenuMetadata { get; } = new List<MenuMetadatum>();

    public virtual ICollection<LanguageMenuMetadatum> LanguageMenuMetadata { get; } = new List<LanguageMenuMetadatum>();

    public virtual MenuMetadatum ParentMenuMetadata { get; set; }

    public virtual ICollection<EntityMetadata> EntityMetadata { get; } = new List<EntityMetadata>();
}
