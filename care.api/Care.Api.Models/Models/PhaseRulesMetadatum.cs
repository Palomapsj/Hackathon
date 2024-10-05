using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class PhaseRulesMetadatum
{
    public Guid PhaseRulesMetadataId { get; set; }

    public Guid? PhaseId { get; set; }

    public Guid? RulesAttributeMetadataId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid EntityMetadataId { get; set; }

    public Guid AttributeMetadataId { get; set; }

    public string AttributeMetadataIdName { get; set; }

    public string AttributeType { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsRequired { get; set; }
    
}
