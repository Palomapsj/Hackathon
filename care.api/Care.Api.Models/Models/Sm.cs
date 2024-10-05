using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Sm
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string TicketNumber { get; set; }

    public Guid? SmsTypeStringMapId { get; set; }

    public Guid? SmsfromRegardingEntityId { get; set; }

    public Guid? SmstoRegardingEntityId { get; set; }

    public string ToPhoneNumber { get; set; }

    public Guid? RegardingEntityId { get; set; }

    public string Message { get; set; }

    public DateTime? ScheduledSend { get; set; }

    public DateTime? ActualSend { get; set; }

    public Guid? SmsStatusStringMapId { get; set; }

    public Guid? ParentSmsid { get; set; }

    public int? MessageLevel { get; set; }

    public Guid? HealthProgramId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string CreatedByName { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string DeletedByName { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? OwnerId { get; set; }

    public string OwnerIdName { get; set; }

    public bool? StateCode { get; set; }

    public Guid? StatusCodeStringMapId { get; set; }

    public string ReasonStateCode { get; set; }

    public string ReasonDeleted { get; set; }

    public string FriendlyCode { get; set; }

    public string ImportCode { get; set; }

    public string InternalControl { get; set; }

    public string EntityOriginalValues { get; set; }

    public Guid? OriginRegardingEntityId { get; set; }

    public Guid? SubjectTypeStringMapId { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual ICollection<Sm> InverseParentSms { get; } = new List<Sm>();

    public virtual RegardingEntity OriginRegardingEntity { get; set; }

    public virtual Sm ParentSms { get; set; }

    public virtual RegardingEntity RegardingEntity { get; set; }

    public virtual StringMap SmsStatusStringMap { get; set; }

    public virtual StringMap SmsTypeStringMap { get; set; }

    public virtual RegardingEntity SmsfromRegardingEntity { get; set; }

    public virtual RegardingEntity SmstoRegardingEntity { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual StringMap SubjectTypeStringMap { get; set; }
}
