using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class IndexViewsEntityMetadatum
{
    public Guid IndexViewsEntityMetadataId { get; set; }

    public Guid? EntityMetadataId { get; set; }

    public Guid? AttributeMetadataId { get; set; }

    public string EntityMetadataIdName { get; set; }

    public string AttributeMetadataIdName { get; set; }

    public string Name { get; set; }

    public bool? IsDefault { get; set; }

    public bool? IsSystemView { get; set; }

    public string Criteria { get; set; }

    public int? DisplayOrder { get; set; }

    public Guid? ProgramId { get; set; }

    public int? ViewCode { get; set; }

    public virtual EntityMetadata EntityMetadata { get; set; }
}
