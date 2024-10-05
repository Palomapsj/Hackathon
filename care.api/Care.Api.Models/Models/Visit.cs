namespace Care.Api.Models;

public partial class Visit : BaseEntity
{
    public Guid? ServiceTypeId { get; set; }

    public string? Name { get; set; }

    public DateTime? ScheduleDateStart { get; set; }

    public DateTime? ScheduleDateEnd { get; set; }

    public DateTime? ConclusionDateStart { get; set; }

    public DateTime? ConclusionDateEnd { get; set; }

    public string? Code { get; set; }

    public Guid? StatusStringMapId { get; set; }

    public Guid? PreSchedulingStatusStringMapId { get; set; }

    public string? Description { get; set; }

    public string? Observation { get; set; }

    public Guid? TreatmentAddressId { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? DiagnosticId { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public decimal? DistanceBetweenPatientHealthProfessional { get; set; }

    public Guid? LocalId { get; set; }

    public string? Contact { get; set; }

    public Guid? DoctorId { get; set; }

    public bool? VisitFormForwarded { get; set; }

    public int? NumberEstablishedVisits { get; set; }

    public Guid? VoucherId { get; set; }

    public bool? CustomBoolean1 { get; set; }

    public bool? CustomBoolean2 { get; set; }

    public bool? CustomBoolean3 { get; set; }

    public bool? CustomBoolean4 { get; set; }

    public string? CustomString1 { get; set; }

    public string? CustomString2 { get; set; }

    public string? CustomString3 { get; set; }

    public string? CustomString4 { get; set; }

    public string? CustomString5 { get; set; }

    public string? CustomString6 { get; set; }

    public DateTime? CustomDateTime1 { get; set; }

    public DateTime? CustomDateTime2 { get; set; }

    public Guid? Custom1StringMapId { get; set; }

    public Guid? Custom2StringMapId { get; set; }

    public Guid? CampaignId { get; set; }

    public virtual ICollection<CalendarScheduled>? CalendarScheduleds { get; } = new List<CalendarScheduled>();

    public virtual Campaign? Campaign { get; set; }

    public virtual StringMap? Custom1StringMap { get; set; }

    public virtual StringMap? Custom2StringMap { get; set; }

    public virtual Diagnostic? Diagnostic { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual ICollection<InformationCollect>? InformationCollects { get; } = new List<InformationCollect>();

    public virtual ICollection<InformationVisit>? InformationVisits { get; } = new List<InformationVisit>();

    public virtual Account? Local { get; set; }

    public virtual StringMap? PreSchedulingStatusStringMap { get; set; }

    public virtual ICollection<SchedulingHistory>? SchedulingHistories { get; } = new List<SchedulingHistory>();

    public virtual ServiceType? ServiceType { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual StringMap? StatusStringMap { get; set; }

    public virtual Treatment? Treatment { get; set; }

    public virtual TreatmentAddress? TreatmentAddress { get; set; }

    public virtual ICollection<TreatmentPayment>? TreatmentPayments { get; } = new List<TreatmentPayment>();

    public virtual Voucher? Voucher { get; set; }
}