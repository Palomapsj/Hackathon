using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class EntityMetadata
{
    public Guid EntityMetadataId { get; set; }

    public string? EntityName { get; set; }

    public int EntityTypeCode { get; set; }

    public string? EntityAbreviationCode { get; set; }

    public string? IconMenu { get; set; }

    public int? MenuDisplayOrder { get; set; }

    public bool? IsActivityEntity { get; set; }

    public bool? NoActivities { get; set; }

    public Guid? EntityConfigurationId { get; set; }

    public virtual ICollection<AttributeMetadata> AttributeMetadata { get; } = new List<AttributeMetadata>();

    public virtual EntityConfiguration EntityConfiguration { get; set; }

    public virtual ICollection<HealthProgramTemplateSetting> HealthProgramTemplateSettings { get; } = new List<HealthProgramTemplateSetting>();

    public virtual ICollection<IndexViewsEntityMetadatum> IndexViewsEntityMetadata { get; } = new List<IndexViewsEntityMetadatum>();

    public virtual ICollection<SectionExcludedByPhase> SectionExcludedByPhases { get; } = new List<SectionExcludedByPhase>();

    public virtual ICollection<SectionMetadatum> SectionMetadata { get; } = new List<SectionMetadatum>();

    public virtual ICollection<MenuMetadatum> MenuMetadata { get; } = new List<MenuMetadatum>();
}
