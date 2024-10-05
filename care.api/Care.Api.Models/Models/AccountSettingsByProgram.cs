namespace Care.Api.Models;

public partial class AccountSettingsByProgram : BaseEntity
{
    public string? Name { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? MedicamentId { get; set; }

    public bool? HomeCare { get; set; }

    public Guid? PatientTypeStringMapId { get; set; }

    public bool? MakesInfusion { get; set; }

    public bool? MakesIt { get; set; }

    public bool? MakesOt { get; set; }

    public bool? MakesInfusionSubsidy { get; set; }

    public bool? SpecialtyDerm { get; set; }

    public bool? SpecialtyGastro { get; set; }

    public bool? SpecialtyRheumato { get; set; }

    public int CodeClinicIntegra { get; set; }

    public Guid? ExamDefinitionId { get; set; }

    public string? Reason { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? AccountStatusStringMapId { get; set; }

    public Guid? ExamTypeStringMapId { get; set; }

    public string? OtherExam { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public decimal? Price { get; set; }

    public string? MainContact { get; set; }

    public string? Area { get; set; }

    public string? RequestId { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public string? NickName { get; set; }

    public int? MounthlyVouchers { get; set; }

    public int? AnnualVouchers { get; set; }

    public string? Telephone1 { get; set; }

    public string? Cnpj { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public Guid? DoctorByProgramId { get; set; }

    public Guid? SystemUserId { get; set; }

    public string? EmailAddress { get; set; }

    public string? AnalysisTime { get; set; }

    public bool? HomeCollect { get; set; }

    public int? UntilKm { get; set; }

    public decimal? UntilKmvalue { get; set; }

    public int? BetweenKm { get; set; }

    public int? AndKm { get; set; }

    public decimal? BetweenKmvalue { get; set; }

    public int? OutsideCoverageAreaAboveKm { get; set; }

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

    public virtual ICollection<AccountInternalDemand> AccountInternalDemands { get; } = new List<AccountInternalDemand>();

    public virtual StringMap? AccountStatusStringMap { get; set; }

    public virtual ICollection<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

    public virtual Disease? Disease { get; set; }

    public virtual DoctorByProgram? DoctorByProgram { get; set; }

    public virtual ExamDefinition? ExamDefinition { get; set; }

    public virtual StringMap? ExamTypeStringMap { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual Medicament? Medicament { get; set; }

    public virtual StringMap? PatientTypeStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual User? SystemUser { get; set; }
}