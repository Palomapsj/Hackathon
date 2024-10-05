namespace Care.Api.Models;

public partial class Voucher
{

    public static int EntityTypeCode => 800;
    public static string EntityName => "Voucher";
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Number { get; set; }

    public DateTime? IssuanceDate { get; set; }

    public DateTime? UseDate { get; set; }

    public DateTime? DueDate { get; set; }

    public string? ExplainNotUsed { get; set; }

    public bool? NotSendViaSms { get; set; }

    public Guid? SourceStringMapId { get; set; }

    public Guid? VoucherStatusStringMapId { get; set; }

    public Guid? VoucherConfigurationId { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? DiagnosticId { get; set; }

    public Guid? RepresentativeId { get; set; }

    public Guid? HealthProgramId { get; set; }

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

    public Guid? ExamDefinitionId { get; set; }

    public Guid? ManagerId { get; set; }

    public Guid? DoctorId { get; set; }

    public Guid? AccountId { get; set; }

    public string? DiscountType { get; set; }

    public decimal? DiscountValue { get; set; }

    public string? Note { get; set; }

    public bool? CustomBoolean1 { get; set; }
    public bool? CustomBoolean2 { get; set; }
    public bool? CustomBoolean3 { get; set; }
    public bool? CustomBoolean4 { get; set; }
    public bool? CustomBoolean5 { get; set; }
    public bool? CustomBoolean6 { get; set; }
    public bool? CustomBoolean7 { get; set; }
    public DateTime? CustomDateTime1 { get; set; }
    public DateTime? CustomDateTime2 { get; set; }
    public DateTime? CustomDateTime3 { get; set; }
    public DateTime? CustomDateTime4 { get; set; }
    public DateTime? CustomDateTime5 { get; set; }
    public DateTime? CustomDateTime6 { get; set; }
    public DateTime? CustomDateTime7 { get; set; }
    public string? CustomString1 { get; set; }
    public string? CustomString2 { get; set; }
    public string? CustomString3 { get; set; }
    public string? CustomString4 { get; set; }
    public string? CustomString5 { get; set; }
    public string? CustomString6 { get; set; }
    public string? CustomString7 { get; set; }

    public Guid? Custom1StringMapId { get; set; }

    public Guid? Custom2StringMapId { get; set; }

    public Guid? Custom3StringMapId { get; set; }

    public Guid? Custom4StringMapId { get; set; }

    public Guid? Custom5StringMapId { get; set; }

    public Guid? Custom6StringMapId { get; set; }

    public Guid? Custom7StringMapId { get; set; }

    public StringMap? Custom1StringMap { get; set; }

    public StringMap? Custom2StringMap { get; set; }

    public StringMap? Custom3StringMap { get; set; }

    public StringMap? Custom4StringMap { get; set; }

    public StringMap? Custom5StringMap { get; set; }

    public StringMap? Custom6StringMap { get; set; }

    public StringMap? Custom7StringMap { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Benefit> Benefits { get; } = new List<Benefit>();

    public virtual Diagnostic? Diagnostic { get; set; }

    public virtual ICollection<DiagnosticExam> DiagnosticExams { get; } = new List<DiagnosticExam>();

    public virtual ICollection<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

    public virtual Doctor? Doctor { get; set; }

    public virtual ExamDefinition? ExamDefinition { get; set; }

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual ICollection<LogisticsScheduleItem> LogisticsScheduleItems { get; } = new List<LogisticsScheduleItem>();

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual Representative? Manager { get; set; }

    public virtual Representative? Representative { get; set; }

    public virtual StringMap? SourceStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Treatment? Treatment { get; set; }

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataIfxitcodes { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataIfxotcodes { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual VoucherConfiguration? VoucherConfiguration { get; set; }

    public virtual StringMap? VoucherStatusStringMap { get; set; }
}
