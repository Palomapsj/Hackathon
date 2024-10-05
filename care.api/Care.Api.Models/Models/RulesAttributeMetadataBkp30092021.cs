using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class RulesAttributeMetadataBkp30092021
{
    public Guid RulesAttributeMetadataId { get; set; }

    public Guid EntityMetadataId { get; set; }

    public Guid AttributeMetadataId { get; set; }

    public string AttributeMetadataIdName { get; set; }

    public string AttributeType { get; set; }

    public bool? IsReadOnly { get; set; }

    public bool? IsOnlyNumber { get; set; }

    public bool? IsOnlyNumberDecimal { get; set; }

    public bool? IsOnlyString { get; set; }

    public bool IsRequired { get; set; }

    public bool IsVisible { get; set; }

    public bool IsAllowNull { get; set; }

    public string MaskValidation { get; set; }

    public string Mask { get; set; }

    public bool? IsPickList { get; set; }

    public string HidePickListOptions { get; set; }

    public string CustomValidation { get; set; }

    public string Regex { get; set; }

    public string SectionName { get; set; }

    public int? SectionOrder { get; set; }

    public string DefaultCssClass { get; set; }

    public string ExtensionCssClassExtension { get; set; }

    public string ScreenAttribuiteSize { get; set; }

    public int? DisplayOrder { get; set; }

    public Guid? ProgramId { get; set; }

    public Guid? SectionMetadataId { get; set; }

    public bool? IsVisibleInFormAdd { get; set; }

    public bool? IsVisibleInFormEdit { get; set; }

    public string PremiseFilter { get; set; }

    public string ScreenFilter { get; set; }

    public bool? IsDisabledByHealthProgram { get; set; }

    public string EntityMetadataIdName { get; set; }
}
