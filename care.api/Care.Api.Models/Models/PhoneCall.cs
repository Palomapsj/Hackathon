using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class PhoneCall
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? PhoneCallTypeStringMapId { get; set; }

    public Guid? CallForRegardingEntityId { get; set; }

    public Guid? CallFromRegardingEntityId { get; set; }

    public string PhoneNumber1 { get; set; }

    public string PhoneNumber2 { get; set; }

    public string PhoneNumber3 { get; set; }

    public int Direction { get; set; }

    public Guid? RegardingEntityId { get; set; }

    public bool? UnSuccessfully { get; set; }

    public Guid? UnSuccessfulReasonStringMapId { get; set; }

    public DateTime? ScheduleReturnDate { get; set; }

    public string Description { get; set; }

    public Guid? PhoneCallStatusStringMapId { get; set; }

    public DateTime? ScheduledStart { get; set; }

    public DateTime? ScheduledEnd { get; set; }

    public DateTime? ActualStart { get; set; }

    public DateTime? ActualEnd { get; set; }

    public int? Duration { get; set; }

    public int? UserAttempts { get; set; }

    public int? Counter { get; set; }

    public string AgentId { get; set; }

    public string CallId { get; set; }

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

    public virtual ICollection<AttemptCallLog> AttemptCallLogs { get; } = new List<AttemptCallLog>();

    public virtual RegardingEntity CallForRegardingEntity { get; set; }

    public virtual RegardingEntity CallFromRegardingEntity { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual RegardingEntity OriginRegardingEntity { get; set; }

    public virtual StringMap PhoneCallStatusStringMap { get; set; }

    public virtual StringMap PhoneCallTypeStringMap { get; set; }

    public virtual RegardingEntity RegardingEntity { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual ICollection<TreatmentAndDiagnosticAction> TreatmentAndDiagnosticActions { get; } = new List<TreatmentAndDiagnosticAction>();

    public virtual StringMap UnSuccessfulReasonStringMap { get; set; }
}
