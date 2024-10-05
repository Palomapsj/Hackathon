namespace Care.Api.Models;

public partial class CalendarScheduled : BaseEntity
{
    public string? Name { get; set; }

    public Guid? ScheduleTypeStringMapId { get; set; }

    public bool? AllDay { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public Guid? VisitId { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? ScheduleTypeStringMapStringMapId { get; set; }

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual StringMap? ScheduleTypeStringMapStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Visit? Visit { get; set; }
}