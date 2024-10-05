using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class BaseTreatment
{
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? Medicamentid { get; set; }

    public Guid? Diseaseid { get; set; }

    public Guid? StrengthMedicamentId { get; set; }

    public Guid? PosologeId { get; set; }

    public int? Dosage { get; set; }

    public Guid? DosageUnitStringMapId { get; set; }

    public Guid? Doctorid { get; set; }

    public Guid? HealthCareProviderId { get; set; }

    public int? HealthInsuranceType { get; set; }

    public Guid? TreatmentSituationId { get; set; }

    public Guid? PhaseId { get; set; }

    public Guid? TreatmentStatusId { get; set; }

    public Guid? TreatmentStatusDetailId { get; set; }

    public int? ProgramParticipationConsentDate { get; set; }

    public int? TreatmentStartDate { get; set; }

    public int? SystemTreatmentStartDate { get; set; }

    public int? SystemAccessStartDate { get; set; }

    public int? TreatmentStopDate { get; set; }

    public DateTime? SystemTreatmentInativationDate { get; set; }

    public int? SystemLastContactDate { get; set; }

    public int? SystemLastSuccessfullContactDate { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? MainContactStringMapId { get; set; }

    public Guid? CaregiverId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get; set; }

    public int? Cpf { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Age { get; set; }

    public int? Telephone1 { get; set; }

    public int? Telephone2 { get; set; }

    public int? Telephone3 { get; set; }

    public int? Mobilephone1 { get; set; }

    public int? Mobilephone2 { get; set; }

    public int? Mobilephone3 { get; set; }

    public int? EmailAddress1 { get; set; }

    public int? EmailAddress2 { get; set; }

    public int? SkypeUser { get; set; }

    public int? Stature { get; set; }

    public int? Weight { get; set; }

    public Guid? GenderStringMapId { get; set; }

    public Guid? CivilStatusStringMapId { get; set; }

    public Guid? EducationStringMapId { get; set; }

    public int? Rg { get; set; }

    public Guid? OccupationId { get; set; }

    public int? FirstNameCaregiver { get; set; }

    public int? LastNameCaregiver { get; set; }

    public int? FullNameCaregiver { get; set; }

    public int? EmailAddress1Caregiver { get; set; }

    public int? Telephone1Caregiver { get; set; }

    public int? Mobilephone1Caregiver { get; set; }

    public int? BirthdateCaregiver { get; set; }

    public int? CpfCaregiver { get; set; }

    public int? SkypeUserCaregiver { get; set; }

    public Guid? KinshipStringMapId { get; set; }

    public int? AmpouleAmount { get; set; }

    public Guid? InfusionPlaceId { get; set; }

    public int? ProgramParticipationConsent { get; set; }

    public int? ConsentToReceivePhonecalls { get; set; }

    public int? ConsentToReceiveSms { get; set; }

    public int? ConsentToReceiveEmail { get; set; }

    public int? ConsentToReceiveVisit { get; set; }

    public int? ConsentToReceiveLogistics { get; set; }

    public int? ConsentToSendDataToDoctor { get; set; }

    public int? ConsentDataShare { get; set; }

    public int? PrescriptionReceived { get; set; }

    public int? PrescriptionReceivedDate { get; set; }

    public int? PrescriptionIsValid { get; set; }

    public int? PrescriptionValidationDate { get; set; }

    public int? PrescriptionValidatedByName { get; set; }

    public Guid? DiagnosticId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string CreatedByName { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public int? DeletedByName { get; set; }

    public string IsDeleted { get; set; }

    public Guid? OwnerId { get; set; }

    public string OwnerIdName { get; set; }

    public int Statecode { get; set; }

    public Guid? StatusCodeStringMapId { get; set; }

    public int? ReasonStateCode { get; set; }

    public int? ReasonDeleted { get; set; }

    public string FriendlyCode { get; set; }

    public double? Importcode { get; set; }

    public int? InternalControl { get; set; }

    public int? EntityOriginalValues { get; set; }

    public int? PatientSourceStringMapId { get; set; }

    public int? PatientDiagnosedDate { get; set; }

    public int? SystemRegistrationEndDate { get; set; }

    public int? Telephone1Observation { get; set; }

    public int? Telephone2Observation { get; set; }

    public int? Telephone3Observation { get; set; }

    public int? Mobilephone1Observation { get; set; }

    public int? Mobilephone2Observation { get; set; }

    public int? Mobilephone3Observation { get; set; }

    public int? Rne { get; set; }

    public Guid? TreatmentCustomDataId { get; set; }

    public int? AbbreviationName { get; set; }

    public int? PrescriptionDueDate { get; set; }

    public int? ProgramTime { get; set; }

    public int? TreatmentTime { get; set; }

    public int? SupportField { get; set; }

    public int? Password { get; set; }

    public int? Cid { get; set; }

    public int? Pncode { get; set; }

    public Guid? PreferredTimeStringMapId { get; set; }

    public Guid? ContractTypeStringMapId { get; set; }

    public int? GotAccessDate { get; set; }

    public Guid? PrescriptionStatusStringMapId { get; set; }

    public int? PrescriptionHasDivergentDosage { get; set; }

    public int? PrescriptionHasLackOfDosage { get; set; }

    public int? PrescriptionHasDivergentInterval { get; set; }

    public int? PrescriptionHasLackOfInterval { get; set; }

    public int? PrescriptionHasDateMissing { get; set; }

    public int? PrescriptionHasStampSignatureMissing { get; set; }

    public int? PrescriptionHasMissingMedicationName { get; set; }

    public int? WillDoctorMakeNewPrescription { get; set; }

    public int? MedicamentCompetitorId { get; set; }
}
