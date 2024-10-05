namespace Care.Api.Models;

public partial class ResourceWorkSetting : BaseEntity
{
    public string? PeriodMorning { get; set; }

    public string? PeriodAfternoon { get; set; }

    public string? PeriodNocturnal { get; set; }

    public bool? Sunday { get; set; }

    public bool? Monday { get; set; }

    public bool? Tuesday { get; set; }

    public bool? Wednesday { get; set; }

    public bool? Thursday { get; set; }

    public bool? Friday { get; set; }

    public bool? Saturday { get; set; }

    public string? Name { get; set; }

    public Guid? CalendarTypeStringMapId { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public Guid? ServiceTypeId { get; set; }

    public int? ServiceDuration { get; set; }

    public DateTime? ValityStart { get; set; }

    public DateTime? ValityEnd { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? CalendarTypeStringMapStringMapId { get; set; }

    public virtual StringMap? CalendarTypeStringMapStringMap { get; set; }

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual ServiceType? ServiceType { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }
}