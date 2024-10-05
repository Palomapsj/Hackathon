using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

public partial class Doctor : BaseEntity
{
    [NotMapped]
    public static int EntityTypeCode => 202;

    [NotMapped]
    public static string EntityName => "Doctor";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("760BD4A3-A941-4804-A9E7-AE36A26689CB");

    public Guid? ClinicId { get; set; }

    public string? Name { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? Rg { get; set; }

    public string? Cpf { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? Telephone3 { get; set; }

    public string? Mobilephone1 { get; set; }

    public string? Mobilephone2 { get; set; }

    public string? Mobilephone3 { get; set; }

    public string? EmailAddress1 { get; set; }

    public string? EmailAddress2 { get; set; }

    public string? SkypeUser { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public Guid? LicenseTypeStringMapId { get; set; }

    public string? LicenseNumber { get; set; }

    public string? LicenseState { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? Observation { get; set; }

    public Guid? LicenseStatusStringMapId { get; set; }

    public Guid? GenderStringMapId { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual Account? Clinic { get; set; }

    public virtual ICollection<Diagnostic> DiagnosticDoctorPrescribers { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticDoctors { get; } = new List<Diagnostic>();

    public virtual ICollection<DiagnosticExam> DiagnosticExams { get; } = new List<DiagnosticExam>();

    public virtual ICollection<DoctorByProgram> DoctorByPrograms { get; } = new List<DoctorByProgram>();

    public virtual ICollection<DoctorsRepresentative> DoctorsRepresentatives { get; } = new List<DoctorsRepresentative>();

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual StringMap? GenderStringMap { get; set; }

    public virtual ICollection<IncidentItem> IncidentItems { get; } = new List<IncidentItem>();

    public virtual ICollection<Incident> Incidents { get; } = new List<Incident>();

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual StringMap? LicenseStatusStringMap { get; set; }

    public virtual StringMap? LicenseTypeStringMap { get; set; }

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<PatientSalesOrder> PatientSalesOrders { get; } = new List<PatientSalesOrder>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<TherapeuticHistory> TherapeuticHistories { get; } = new List<TherapeuticHistory>();

    public virtual ICollection<Treatment> TreatmentDoctorPrescribers { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentDoctors { get; } = new List<Treatment>();

    public virtual ICollection<TreatmentHistory> TreatmentHistories { get; } = new List<TreatmentHistory>();

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual ICollection<Voucher> Vouchers { get; } = new List<Voucher>();

    public virtual ICollection<MedicalSpecialty> MedicalSpecialties { get; } = new List<MedicalSpecialty>();

    public virtual ICollection<RepresentativeDoctorByProgram>? RepresentativeDoctorByPrograms { get; } = new List<RepresentativeDoctorByProgram>();
}
