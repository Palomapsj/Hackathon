using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Care.Api.Models.Models;

namespace Care.Api.Models;

public partial class Treatment : BaseEntity
{
    [NotMapped]
    public static int EntityTypeCode => 500;

    [NotMapped]
    public static string? EntityName => "Treatment";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("5CADD566-ABD6-4265-9DF0-3783A73E18D0");


    public string? Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? MedicamentId { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? StrengthMedicamentId { get; set; }

    public Guid? PosologeId { get; set; }

    public decimal? Dosage { get; set; }

    public Guid? DosageUnitStringMapId { get; set; }

    public Guid? DoctorId { get; set; }

    public Guid? HealthCareProviderId { get; set; }

    public string? HealthInsuranceType { get; set; }

    public Guid? TreatmentSituationId { get; set; }

    public Guid? PhaseId { get; set; }

    public Guid? TreatmentStatusId { get; set; }

    public Guid? TreatmentStatusDetailId { get; set; }

    public DateTime? ProgramParticipationConsentDate { get; set; }

    public DateTime? TreatmentStartDate { get; set; }

    public DateTime? SystemTreatmentStartDate { get; set; }

    public DateTime? SystemAccessStartDate { get; set; }

    public DateTime? TreatmentStopDate { get; set; }

    public DateTime? SystemTreatmentInativationDate { get; set; }

    public DateTime? SystemLastContactDate { get; set; }

    public DateTime? SystemLastSuccessfullContactDate { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? MainContactStringMapId { get; set; }

    public Guid? CaregiverId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? Cpf { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Age { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? Telephone3 { get; set; }

    public string? Mobilephone1 { get; set; }

    public string? Mobilephone2 { get; set; }

    public string? Mobilephone3 { get; set; }

    public string? EmailAddress1 { get; set; }

    public string? EmailAddress2 { get; set; }

    public string? SkypeUser { get; set; }

    public decimal? Stature { get; set; }

    public decimal? Weight { get; set; }

    public Guid? GenderStringMapId { get; set; }

    public Guid? CivilStatusStringMapId { get; set; }

    public Guid? EducationStringMapId { get; set; }

    public string? Rg { get; set; }

    public Guid? OccupationId { get; set; }

    public string? FirstNameCaregiver { get; set; }

    public string? LastNameCaregiver { get; set; }

    public string? FullNameCaregiver { get; set; }

    public string? EmailAddress1Caregiver { get; set; }

    public string? Telephone1Caregiver { get; set; }

    public string? Mobilephone1Caregiver { get; set; }

    public DateTime? BirthdateCaregiver { get; set; }

    public string? CpfCaregiver { get; set; }

    public string? SkypeUserCaregiver { get; set; }

    public Guid? KinshipStringMapId { get; set; }

    public decimal? AmpouleAmount { get; set; }

    public Guid? InfusionPlaceId { get; set; }

    public bool? ProgramParticipationConsent { get; set; }

    public bool? ConsentToReceivePhonecalls { get; set; }

    public bool? ConsentToReceiveSms { get; set; }

    public bool? ConsentToReceiveEmail { get; set; }

    public bool? ConsentToReceiveVisit { get; set; }

    public bool? ConsentToReceiveLogistics { get; set; }

    public bool? ConsentToSendDataToDoctor { get; set; }

    public bool? ConsentDataShare { get; set; }

    public bool? PrescriptionReceived { get; set; }

    public DateTime? PrescriptionReceivedDate { get; set; }

    public bool? PrescriptionIsValid { get; set; }

    public DateTime? PrescriptionValidationDate { get; set; }

    public string? PrescriptionValidatedByName { get; set; }

    public Guid? DiagnosticId { get; set; }
    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }
    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }


    public Guid? PatientSourceStringMapId { get; set; }

    public DateTime? PatientDiagnosedDate { get; set; }

    public DateTime? SystemRegistrationEndDate { get; set; }

    public string? Telephone1Observation { get; set; }

    public string? Telephone2Observation { get; set; }

    public string? Telephone3Observation { get; set; }

    public string? Mobilephone1Observation { get; set; }

    public string? Mobilephone2Observation { get; set; }

    public string? Mobilephone3Observation { get; set; }

    public string? Rne { get; set; }

    public Guid? TreatmentCustomDataId { get; set; }

    public string? AbbreviationName { get; set; }

    public DateTime? PrescriptionDueDate { get; set; }

    public decimal? ProgramTime { get; set; }

    public decimal? TreatmentTime { get; set; }

    public string? SupportField { get; set; }

    public string? Password { get; set; }

    public string? Cid { get; set; }

    public string? Pncode { get; set; }

    public Guid? PreferredTimeStringMapId { get; set; }

    public Guid? ContractTypeStringMapId { get; set; }

    public DateTime? GotAccessDate { get; set; }

    public Guid? PrescriptionStatusStringMapId { get; set; }

    public bool? PrescriptionHasDivergentDosage { get; set; }

    public bool? PrescriptionHasLackOfDosage { get; set; }

    public bool? PrescriptionHasDivergentInterval { get; set; }

    public bool? PrescriptionHasLackOfInterval { get; set; }

    public bool? PrescriptionHasDateMissing { get; set; }

    public bool? PrescriptionHasStampSignatureMissing { get; set; }

    public bool? PrescriptionHasMissingMedicationName { get; set; }

    public bool? WillDoctorMakeNewPrescription { get; set; }

    public Guid? MedicamentCompetitorId { get; set; }

    public bool? OnlyCareMigration { get; set; }

    public Guid? DoctorPrescriberId { get; set; }

    public bool? Haspatientusedmedicationbefore { get; set; }

    public Guid? AccountId { get; set; }

    public bool? GotAccess { get; set; }

    public bool? PatientDiagnosed { get; set; }

    public string? SampleCode { get; set; }

    public Guid? PhaseStringMapId { get; set; }

    public Guid? TreatmentStatusStringMapId { get; set; }

    public Guid? TreatmentStatusDetailStringMapId { get; set; }

    public Guid? ReasonInactivationStringMapId { get; set; }

    public bool? ProgramParticipationDiagnosticConsent { get; set; }

    public DateTime? ProgramParticipationDiagnosticConsentDate { get; set; }

    public bool? ConsentToReceiveDiagnosticPhonecalls { get; set; }

    public DateTime? DiagnosticPhonecallConsentDate { get; set; }

    public bool? ConsentToReceiveDiagnosticEmail { get; set; }

    public DateTime? DiagnosticEmailConsentDate { get; set; }

    public Guid? ModalityStringMapId { get; set; }

    public Guid? AccessTypeStringMapId { get; set; }

    public int? InfusionInterval { get; set; }

    public Guid? TherapeuticTypeId { get; set; }

    public string? RequestBy { get; set; }

    public string? SectorOfTheRequester { get; set; }

    public Guid? VisitRefusalReasonStringMapId { get; set; }

    public bool? ConsentLgpd { get; set; }

    public DateTime? ConsentLgpddate { get; set; }

    public Guid? SourceConsentStringMapId { get; set; }

    public bool? HasOps { get; set; }

    public string? CardNumber { get; set; }

    public bool? DoctorConsentToReceivePhonecalls { get; set; }

    public DateTime? DoctorPhonecallsConsentDate { get; set; }

    public Guid? StageOfDiseaseStringMapId { get; set; }

    public Guid? UserId { get; set; }

    public bool? CustomBoolean { get; set; }

    public bool? CustomBoolean1 { get; set; }

    public Guid? Disease2Id { get; set; }
    public Guid? Disease3Id { get; set; }
    public Guid? Disease4Id { get; set; }
    public Guid? Disease5Id { get; set; }

    public bool? CustomBoolean2 { get; set; }

    public bool? CustomBoolean3 { get; set; }

    public bool? CustomBoolean4 { get; set; }

    public bool? CustomBoolean11 { get; set; }

    public bool? CustomBoolean21 { get; set; }

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
    public Guid? Custom3StringMapId { get; set; }

    public virtual ICollection<AccessHistoryAttendance> AccessHistoryAttendances { get; } = new List<AccessHistoryAttendance>();

    public virtual StringMap? AccessTypeStringMap { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<AdhesionAttendance> AdhesionAttendances { get; } = new List<AdhesionAttendance>();

    public virtual ICollection<AttemptCallLog> AttemptCallLogs { get; } = new List<AttemptCallLog>();

    public virtual ICollection<Benefit> Benefits { get; } = new List<Benefit>();

    public virtual Caregiver? Caregiver { get; set; }

    public virtual StringMap? CivilStatusStringMap { get; set; }

    public virtual StringMap? ContractTypeStringMap { get; set; }

    public virtual StringMap? Custom1StringMap { get; set; }

    public virtual StringMap? Custom2StringMap { get; set; }
    public virtual StringMap? Custom3StringMap { get; set; }

    public virtual Diagnostic? Diagnostic { get; set; }

    public virtual ICollection<DiagnosticExam> DiagnosticExams { get; } = new List<DiagnosticExam>();

    public virtual Disease? Disease { get; set; }

    public virtual Disease? Disease2 { get; set; }
    public virtual Disease? Disease3 { get; set; }
    public virtual Disease? Disease4 { get; set; }
    public virtual Disease? Disease5 { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Doctor? DoctorPrescriber { get; set; }

    public virtual StringMap? DosageUnitStringMap { get; set; }

    public virtual StringMap? EducationStringMap { get; set; }

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual StringMap? GenderStringMap { get; set; }

    public virtual Account? HealthCareProvider { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual ICollection<Incident> Incidents { get; } = new List<Incident>();

    public virtual Account? InfusionPlace { get; set; }

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual StringMap? KinshipStringMap { get; set; }

    public virtual ICollection<Logistics> Logistics { get; } = new List<Logistics>();

    public virtual StringMap? MainContactStringMap { get; set; }

    public virtual Medicament? Medicament { get; set; }

    public virtual ICollection<MedicamentAccess> MedicamentAccesses { get; } = new List<MedicamentAccess>();

    public virtual MedicamentCompetitor? MedicamentCompetitor { get; set; }

    public virtual ICollection<MedicamentConcomitant> MedicamentConcomitants { get; } = new List<MedicamentConcomitant>();

    public virtual StringMap? ModalityStringMap { get; set; }

    public virtual Occupation? Occupation { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual StringMap? PatientSourceStringMap { get; set; }

    public virtual ICollection<Pharmacovigilance> Pharmacovigilances { get; } = new List<Pharmacovigilance>();

    public virtual Phase? Phase { get; set; }

    public virtual StringMap? PhaseStringMap { get; set; }

    public virtual Posologe? Posologe { get; set; }

    public virtual StringMap? PreferredTimeStringMap { get; set; }

    public virtual StringMap? PrescriptionStatusStringMap { get; set; }

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();

    public virtual StringMap? ReasonInactivationStringMap { get; set; }

    public virtual StringMap? SourceConsentStringMap { get; set; }

    public virtual StringMap? StageOfDiseaseStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual StrengthMedicament? StrengthMedicament { get; set; }

    public virtual ICollection<TherapeuticHistory> TherapeuticHistories { get; } = new List<TherapeuticHistory>();

    public virtual TherapeuticType? TherapeuticType { get; set; }

    public virtual ICollection<TreatmentAddress> TreatmentAddresses { get; } = new List<TreatmentAddress>();

    public virtual ICollection<TreatmentAndDiagnosticAction> TreatmentAndDiagnosticActions { get; } = new List<TreatmentAndDiagnosticAction>();

    public virtual ICollection<TreatmentAttendance> TreatmentAttendances { get; } = new List<TreatmentAttendance>();

    public virtual TreatmentCustomData? TreatmentCustomData { get; set; }

    public virtual ICollection<TreatmentHistory> TreatmentHistories { get; } = new List<TreatmentHistory>();

    public virtual ICollection<TreatmentPayment> TreatmentPayments { get; } = new List<TreatmentPayment>();

    public virtual TreatmentSituation? TreatmentSituation { get; set; }

    public virtual TreatmentStatus? TreatmentStatus { get; set; }

    public virtual TreatmentStatusDetail? TreatmentStatusDetail { get; set; }

    public virtual StringMap? TreatmentStatusDetailStringMap { get; set; }

    public virtual StringMap? TreatmentStatusStringMap { get; set; }

    public virtual User? User { get; set; }

    public virtual StringMap? VisitRefusalReasonStringMap { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual ICollection<Voucher> Vouchers { get; } = new List<Voucher>();
    public virtual ICollection<CaregiverTreatment> CaregiverTreatments { get; } = new List<CaregiverTreatment>();

}
