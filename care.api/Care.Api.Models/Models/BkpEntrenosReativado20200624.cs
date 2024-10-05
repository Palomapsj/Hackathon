using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class BkpEntrenosReativado20200624
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? MedicamentId { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? StrengthMedicamentId { get; set; }

    public Guid? PosologeId { get; set; }

    public decimal? Dosage { get; set; }

    public Guid? DosageUnitStringMapId { get; set; }

    public Guid? DoctorId { get; set; }

    public Guid? HealthCareProviderId { get; set; }

    public string HealthInsuranceType { get; set; }

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

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get; set; }

    public string Cpf { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Age { get; set; }

    public string Telephone1 { get; set; }

    public string Telephone2 { get; set; }

    public string Telephone3 { get; set; }

    public string Mobilephone1 { get; set; }

    public string Mobilephone2 { get; set; }

    public string Mobilephone3 { get; set; }

    public string EmailAddress1 { get; set; }

    public string EmailAddress2 { get; set; }

    public string SkypeUser { get; set; }

    public decimal? Stature { get; set; }

    public decimal? Weight { get; set; }

    public Guid? GenderStringMapId { get; set; }

    public Guid? CivilStatusStringMapId { get; set; }

    public Guid? EducationStringMapId { get; set; }

    public string Rg { get; set; }

    public Guid? OccupationId { get; set; }

    public string FirstNameCaregiver { get; set; }

    public string LastNameCaregiver { get; set; }

    public string FullNameCaregiver { get; set; }

    public string EmailAddress1Caregiver { get; set; }

    public string Telephone1Caregiver { get; set; }

    public string Mobilephone1Caregiver { get; set; }

    public DateTime? BirthdateCaregiver { get; set; }

    public string CpfCaregiver { get; set; }

    public string SkypeUserCaregiver { get; set; }

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

    public string PrescriptionValidatedByName { get; set; }

    public Guid? DiagnosticId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string CreatedByName { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string DeletedByName { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? OwnerId { get; set; }

    public string OwnerIdName { get; set; }

    public bool? StateCode { get; set; }

    public Guid? StatusCodeStringMapId { get; set; }

    public string ReasonStateCode { get; set; }

    public string ReasonDeleted { get; set; }

    public string FriendlyCode { get; set; }

    public string ImportCode { get; set; }

    public string InternalControl { get; set; }

    public string EntityOriginalValues { get; set; }

    public Guid? PatientSourceStringMapId { get; set; }

    public DateTime? PatientDiagnosedDate { get; set; }

    public DateTime? SystemRegistrationEndDate { get; set; }

    public string Telephone1Observation { get; set; }

    public string Telephone2Observation { get; set; }

    public string Telephone3Observation { get; set; }

    public string Mobilephone1Observation { get; set; }

    public string Mobilephone2Observation { get; set; }

    public string Mobilephone3Observation { get; set; }

    public string Rne { get; set; }

    public Guid? TreatmentCustomDataId { get; set; }

    public string AbbreviationName { get; set; }

    public DateTime? PrescriptionDueDate { get; set; }

    public decimal? ProgramTime { get; set; }

    public decimal? TreatmentTime { get; set; }

    public string SupportField { get; set; }

    public string Password { get; set; }

    public string Cid { get; set; }

    public string Pncode { get; set; }

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

    public string SampleCode { get; set; }

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
}
