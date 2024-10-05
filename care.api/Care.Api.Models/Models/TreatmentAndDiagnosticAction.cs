using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TreatmentAndDiagnosticAction
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? ActionConfigurationId { get; set; }

    public DateTime? ScheduledDate { get; set; }

    public int? SuccessAttempt { get; set; }

    public int? FailAttempt { get; set; }

    public string? SourceEntityName { get; set; }

    public string? SourceEntityTypeCode { get; set; }

    public Guid? SourceEntityObjectId { get; set; }

    public string? Description { get; set; }

    public Guid? DiagnosticId { get; set; }

    public Guid? TreatmentId { get; set; }

    public DateTime? ActualDate { get; set; }

    public Guid? PhoneCallId { get; set; }

    public Guid? ActionReceiverId { get; set; }

    public int Type { get; set; }

    public int ActionStatus { get; set; }

    public int Receiver { get; set; }

    public Guid? ActionCategoryId { get; set; }

    public Guid? ActionRuleId { get; set; }

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

    public Guid? HealthProgramId { get; set; }

    public int? PeriodSubject { get; set; }

    public Guid? IncidentId { get; set; }

    public virtual ActionCategory? ActionCategory { get; set; }

    public virtual ActionConfiguration? ActionConfiguration { get; set; }

    public virtual ActionRule? ActionRule { get; set; }

    public virtual ICollection<AttemptCallLog> AttemptCallLogs { get; } = new List<AttemptCallLog>();

    public virtual Diagnostic? Diagnostic { get; set; }

    public virtual Incident? Incident { get; set; }

    public virtual PhoneCall? PhoneCall { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Treatment? Treatment { get; set; }
}
