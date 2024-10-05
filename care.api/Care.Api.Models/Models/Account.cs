using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

public partial class Account : BaseEntity
{
    [NotMapped]
    public static int EntityTypeCode => 100;
    [NotMapped]
    public static string EntityName => "Account";
    [NotMapped]
    public static Guid EntityId => Guid.Parse("3B159E75-344D-4641-A435-0D1D10172738");

    public Guid? AccountTypeStringMapId { get; set; }

    public string? Name { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? TelephoneFax { get; set; }

    public string? MobilePhone { get; set; }

    public string? EmailAddress { get; set; }
    public string? EmailAddress2 { get; set; }

    public string? Site { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public string? AddressReference { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? Cnpj { get; set; }

    public string? StateRegistration { get; set; }

    public string? CompanyName { get; set; }

    public Guid? RegardingEntityId { get; set; }

    public Guid? AccessWayId { get; set; }

    public Guid? AccessMannerId { get; set; }

    public Guid? AccessCoverageAreaStringMapId { get; set; }

    public bool? AccessMakesStatement { get; set; }

    public bool? AccessMakesInformation { get; set; }

    public string? AccessObservation { get; set; }

    public Guid? ClinicTypeStringMapId { get; set; }

    public Guid? ClinicPublicOrPrivateStringMapId { get; set; }

    public Guid? DoctorResponsableId { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }
    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }
    public Guid? HealthProfessionalId { get; set; }

    public string? MainContact { get; set; }

    public string? OfficeHours { get; set; }

    public string? Ansnumber { get; set; }
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

    public virtual StringMap? AccessCoverageAreaStringMap { get; set; }

    public virtual AccessManner? AccessManner { get; set; }

    public virtual AccessWay? AccessWay { get; set; }

    public virtual ICollection<AccountCoverageArea> AccountCoverageAreas { get; } = new List<AccountCoverageArea>();

    public virtual ICollection<AccountExamTypeByProgram> AccountExamTypeByPrograms { get; } = new List<AccountExamTypeByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByPrograms { get; } = new List<AccountSettingsByProgram>();

    public virtual StringMap? AccountTypeStringMap { get; set; }

    public virtual ICollection<AdhesionAttendance> AdhesionAttendances { get; } = new List<AdhesionAttendance>();

    public virtual ICollection<Benefit> Benefits { get; } = new List<Benefit>();

    public virtual ICollection<Campaign> Campaigns { get; } = new List<Campaign>();

    public virtual StringMap? ClinicPublicOrPrivateStringMap { get; set; }

    public virtual StringMap? ClinicTypeStringMap { get; set; }

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();

    public virtual ICollection<Diagnostic> DiagnosticAccounts { get; } = new List<Diagnostic>();

    public virtual ICollection<DiagnosticExam> DiagnosticExams { get; } = new List<DiagnosticExam>();

    public virtual ICollection<Diagnostic> DiagnosticHealthCareProviders { get; } = new List<Diagnostic>();

    public virtual Doctor? DoctorResponsable { get; set; }

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual ICollection<DoctorsRepresentative> DoctorsRepresentatives { get; } = new List<DoctorsRepresentative>();

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual ICollection<HealthProfessionalByProgram> HealthProfessionalByPrograms { get; } = new List<HealthProfessionalByProgram>();

    public virtual ICollection<HealthProgram> HealthProgramAccounts { get; } = new List<HealthProgram>();

    public virtual ICollection<HealthProgram> HealthProgramLogisticPartners { get; } = new List<HealthProgram>();

    public virtual ICollection<Incident> IncidentAccounts { get; } = new List<Incident>();

    public virtual ICollection<Incident> IncidentDistributorLogistics { get; } = new List<Incident>();

    public virtual ICollection<IncidentItem> IncidentItems { get; } = new List<IncidentItem>();

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual ICollection<Logistics> Logistics { get; } = new List<Logistics>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleClients { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleDeliveryLaboratories { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleLocals { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleLogisticsPartners { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsStuff> LogisticsStuffs { get; } = new List<LogisticsStuff>();

    public virtual ICollection<MedicamentAccess> MedicamentAccesses { get; } = new List<MedicamentAccess>();

    public virtual ICollection<PatientSalesOrder> PatientSalesOrders { get; } = new List<PatientSalesOrder>();

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();

    public virtual RegardingEntity? RegardingEntity { get; set; }

    public virtual ICollection<Representative> Representatives { get; } = new List<Representative>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<Treatment> TreatmentAccounts { get; } = new List<Treatment>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataAccounts { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataInfusionSites { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<Treatment> TreatmentHealthCareProviders { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentInfusionPlaces { get; } = new List<Treatment>();

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual ICollection<Voucher> Vouchers { get; } = new List<Voucher>();

    public virtual ICollection<AccessProcedureByProgram> AccessProcedureByPrograms { get; } = new List<AccessProcedureByProgram>();

    public virtual ICollection<DoctorByProgram> DoctorByPrograms { get; } = new List<DoctorByProgram>();

    public virtual ICollection<HealthProgram> HealthPrograms { get; } = new List<HealthProgram>();
}
