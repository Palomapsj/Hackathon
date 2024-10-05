using Care.Api.Models.Interfaces;
using Care.Api.Models.Models;
using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Email : BaseEntity
{

    public static int EntityTypeCode => 601;
    public static string EntityName => "Email";

    //public Guid Id { get; set; }

    public Guid? EmailBoxSettingId { get; set; }

    public string? To { get; set; }

    public string? Ccc { get; set; }

    public string? Cco { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public string? MimeType { get; set; }

    public DateTime? SendedOn { get; set; }

    public Guid? RegardingEntityId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public DateTime? ScheduleDate { get; set; }

    public DateTime? LastAttempt { get; set; }

    public int? Attempts { get; set; }

    public string? MessageError { get; set; }

    public Guid? TemplateId { get; set; }

    //public DateTime? CreatedOn { get; set; }

    //public DateTime? ModifiedOn { get; set; }

    //public DateTime? DeletedOn { get; set; }

    //public Guid? CreatedBy { get; set; }

    //public string CreatedByName { get; set; }

    //public Guid? ModifiedBy { get; set; }

    //public string? ModifiedByName { get; set; }
    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    //public bool IsDeleted { get; set; }

    //public Guid? OwnerId { get; set; }

    //public string? OwnerIdName { get; set; }
    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    //public string? EntityOriginalValues { get; set; }

    public string? Name { get; set; }

    public Guid? OriginRegardingEntityId { get; set; }

    public virtual EmailBoxSetting? EmailBoxSetting { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual RegardingEntity? OriginRegardingEntity { get; set; }

    public virtual RegardingEntity? RegardingEntity { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Template? Template { get; set; }

    public virtual ICollection<ClickTracking> ClickTrackings { get; set; }
}
