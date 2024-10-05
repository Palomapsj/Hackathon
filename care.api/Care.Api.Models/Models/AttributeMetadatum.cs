using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AttributeMetadata
{
    public Guid AttributeMetadataId { get; set; }

    public Guid EntityMetadataId { get; set; }

    public string? AttributeName { get; set; }

    public string? AttributeType { get; set; }

    public bool? IsCollection { get; set; }

    public bool? IsManyToMany { get; set; }

    public bool? IsLookup { get; set; }

    public bool? IsPickList { get; set; }

    public bool? IsPrimaryKey { get; set; }

    public bool? IsStateCode { get; set; }

    public bool? IsStatusCode { get; set; }

    public bool? IsSystemField { get; set; }

    public bool? IsNotMapped { get; set; }

    public string? InnerTable { get; set; }

    public bool? IsTextArea { get; set; }

    public bool? IsDateTimeWithHour { get; set; }

    public bool? IsTimeLine { get; set; }

    public string? EntityMetadataIdName { get; set; }

    public int? AttributeHashCode { get; set; }

    public virtual EntityMetadata EntityMetadata { get; set; }

    public virtual ICollection<StringMap> StringMaps { get; } = new List<StringMap>();
}
