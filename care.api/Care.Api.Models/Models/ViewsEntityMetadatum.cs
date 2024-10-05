using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ViewsEntityMetadatum
{
    public Guid ViewsEntityMetadataId { get; set; }

    public Guid? SourceEntityMetadataId { get; set; }

    public Guid? SourceAttributeMetadataId { get; set; }

    public string SourceEntityMetadataIdName { get; set; }

    public string SourceAttributeMetadataIdName { get; set; }

    public Guid? TargetEntityMetadataId { get; set; }

    public Guid? TargetAttributeMetadataId { get; set; }

    public string TargetAttributeMetadataIdName { get; set; }

    public string TargetEntityMetadataIdName { get; set; }

    public bool? IsCollection { get; set; }

    public bool? IsLookup { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public string AttributeName { get; set; }

    public Guid? ProgramId { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsVisible { get; set; }
}
