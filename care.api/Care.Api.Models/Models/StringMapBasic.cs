namespace Care.Api.Models;

public partial class StringMapBasic
{
    public Guid StringMapId { get; set; }

    public Guid EntityMetadataId { get; set; }

    public string? EntityMetadataIdName { get; set; }

    public Guid AttributeMetadataId { get; set; }

    public string? AttributeMetadataIdName { get; set; }

    public int? OptionValue { get; set; }

    public string? OptionName { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsDisabled { get; set; }

    public string? OptionNameLangEn { get; set; }

    public Guid? ProgramId { get; set; }

    public bool? IsSystemOption { get; set; }

    public string? Flag { get; set; }

   
}
