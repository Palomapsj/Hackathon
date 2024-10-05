using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class HealthProgramTemplateSetting
{

    public static int EntityTypeCode => 328;
    public static string EntityName => "HealthProgramTemplateSettingSettings";



    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? EntityMetadataId { get; set; }

    public string? AttributeName { get; set; }

    public int? ScheduleDays { get; set; }

    public Guid? EmailBoxSettingId { get; set; }

    public Guid? TemplateTypeStringMapId { get; set; }

    public Guid? TemplateId { get; set; }

    public string? To { get; set; }

    public string? Ccc { get; set; }

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

    public Guid? StatusCodeStringMapId { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public string? EntityOriginalValues { get; set; }

    public Guid? TemplateTypeStringMapStringMapId { get; set; }

    public virtual EmailBoxSetting EmailBoxSetting { get; set; }

    public virtual EntityMetadata EntityMetadata { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual Template Template { get; set; }

    public virtual StringMap TemplateTypeStringMapStringMap { get; set; }
}
