using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class LanguageAttribute
{
    public Guid Id { get; set; }

    public Guid AttributeMetadataId { get; set; }

    public Guid EntityMetadataId { get; set; }

    public string? AttributeMetadataIdName { get; set; }

    public string? EntityMetadataIdName { get; set; }

    public int LangId { get; set; }

    public string? Translate { get; set; }

    public string? Label { get; set; }

    public string? Description { get; set; }

    public string? ToolTip { get; set; }

    public string? ErrorMessageForRequeried { get; set; }

    public string? ErrorMessageForMask { get; set; }

    public string? ErrorMessageForCustomValidation { get; set; }

    public string? ErrorMessageForRegexValidation { get; set; }

    public string? ErrorMessageDefault { get; set; }

    public Guid? ProgramId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string? ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? OwnerId { get; set; }

    public string? OwnerIdName { get; set; }

    public bool? StateCode { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public string? EntityOriginalValues { get; set; }

    public string? Name { get; set; }
}
