using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class SchedulingHistory : BaseEntity
{

    public DateTime? ScheduledDate { get; set; }
    public Guid? ReschedulingReasonStringMapId { get; set; }

    public string? Description { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? ExamId { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public string? Name { get; set; }

    public DateTime? ScheduledDateBefore { get; set; }

    public string? StatusBefore { get; set; }

    public string? StatusAfter { get; set; }

    public Guid? LogisticsScheduleId { get; set; }

    public Guid? VisitId { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public Guid? CampaignId { get; set; }

    public virtual Campaign? Campaign { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual LogisticsSchedule? LogisticsSchedule { get; set; }

    public virtual StringMap? ReschedulingReasonStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Visit? Visit { get; set; }
}
