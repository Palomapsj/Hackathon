using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TreatmentCustomData
{
    public Guid Id { get; set; }

    public int? PatientCode { get; set; }

    public bool? DoctorAutorizeStartTreatment { get; set; }

    public bool? AcceptPartnershipDrugstores { get; set; }

    public Guid? MedicalInstructionAccessWayStringMapId { get; set; }

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

    public string? Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? MedicalIndicationStringMapId { get; set; }

    public bool? TransplantedPatient { get; set; }

    public int? AmountOfCyclesPrescribed { get; set; }

    public Guid? PatientTypeStringMapId { get; set; }

    public Guid? ReasonForNotAcceptingSmsstringMapId { get; set; }

    public Guid? VisitRefusalReasonStringMapId { get; set; }

    public DateTime? PatientTypeDateChanged { get; set; }

    public DateTime? TransplantedDate { get; set; }

    public bool? PatientUsedAnotherMedication { get; set; }

    public Guid? PreviousMedicamentId { get; set; }

    public bool? PatientWillBeginItbenefit { get; set; }

    public bool? PatientWillBeginOtbenefit { get; set; }

    public bool? PatientWillGetLocationCode { get; set; }

    public Guid? AccessWayId { get; set; }

    public string? SusprotocolNumber { get; set; }

    public bool? ChecklistRequired { get; set; }

    public int? WithdrawnMedicamentQuantity { get; set; }

    public Guid? AccessDetailStringMapId { get; set; }

    public Guid? OptimizationSubTypeStringMapId { get; set; }

    public Guid? PlanCoverageStringMapId { get; set; }

    public bool? ContractHasCoparticipation { get; set; }

    public Guid? IfxitcodeId { get; set; }

    public bool? ChecklistReceived { get; set; }

    public bool? LeftTheBenefit { get; set; }

    public DateTime? DateLeftTheBenefit { get; set; }

    public Guid? IfxitstatusStringMapId { get; set; }

    public Guid? JanssenitstatusStringMapId { get; set; }

    public Guid? IfxotcodeId { get; set; }

    public bool? PerformInfusionEvery8Weeks { get; set; }

    public Guid? IfxotstatusStringMapId { get; set; }

    public Guid? JanssenotstatusStringMapId { get; set; }

    public bool? OtprescriptionSent { get; set; }

    public bool? OtprescriptionValidated { get; set; }

    public DateTime? OtprescriptionValidatedOn { get; set; }

    public string? OtprescriptionValidatedBy { get; set; }

    public bool? ItbenefitApproved { get; set; }

    public string? ItbenefitRefusalReason { get; set; }

    public bool? OtbenefitApproved { get; set; }

    public string? OtbenefitRefusalReason { get; set; }

    public Guid? InfusionTypeStringMapId { get; set; }

    public Guid? InfusionSiteId { get; set; }

    public Guid? StorageLocationStringMapId { get; set; }

    public int? AmpoulesUsed { get; set; }

    public int? ItperformedInfusions { get; set; }

    public int? PerformedInfusions { get; set; }

    public int? OtperformedInfusions { get; set; }

    public int? ItbilledInfusions { get; set; }

    public Guid? SupplyMethodStringMapId { get; set; }

    public Guid? IsWorkingStringMapId { get; set; }

    public bool? HemCasaPatient { get; set; }

    public bool? MyPkfiTpatient { get; set; }

    public Guid? IsWorkingStringMapStringMapId { get; set; }

    public bool? OldDatabasePatient { get; set; }

    public Guid? TreatmentTypeStringMapId { get; set; }

    public bool? CoagulationFactorReplacement { get; set; }

    public bool? WillStartTreatmentFactorReplacement { get; set; }

    public string? FactorReplacementMedicament { get; set; }

    public Guid? AccountId { get; set; }

    public string? PreviousMedicamentSt { get; set; }

    public Guid? HemophiliaDegreeStringMapId { get; set; }

    public bool? PatientHasInternetAccess { get; set; }

    public bool? AcceptsFutureLabContacts { get; set; }

    public bool? AcceptsMedicalContactAdverseReactions { get; set; }

    public bool? FirstcontactwithBayer { get; set; }

    public bool? PatientsentauthorizationtoBetamens { get; set; }

    public bool? AcceptOnlineContacts { get; set; }

    public bool? AcceptsDailySmsdelivery { get; set; }

    public bool? AcceptReceiveMaintenanceKit { get; set; }

    public bool? AcceptsIbetaplusRegistration { get; set; }

    public Guid? DoctorAuthorizesDosageTitrationStringMapId { get; set; }

    public int? ApplicationHours { get; set; }

    public bool? Betaferonisthefirsttreatmentdrug { get; set; }

    public Guid? RiskRatingStringMapId { get; set; }

    public int? CyclePeriod { get; set; }

    public Guid? ApplicatorTypeStringMapId { get; set; }

    public string? ApplicatorTypeCustom { get; set; }

    public string? ApplicatorLot { get; set; }

    public DateTime? DateoflastMri { get; set; }

    public DateTime? DateOfLastMedicalAppointment { get; set; }

    public DateTime? DateOfLastSuswithdrawal { get; set; }

    public Guid? TreatmentCyclesStringMapId { get; set; }

    public Guid? FormofAccessStringMapId { get; set; }

    public Guid? RepresentativeId { get; set; }

    public string? LocationsInfusion { get; set; }

    public DateTime? DateOfNextInfusion { get; set; }

    public Guid? PreviousMedicamentCompetitorId { get; set; }

    public Guid? OptimizationTypeStringMapId { get; set; }

    public bool? PharmacovigilanceReported { get; set; }

    public string? EmailNumber { get; set; }

    public Guid? TreatmentIntervalStringMapId { get; set; }

    public bool? AcceptVoucher { get; set; }

    public Guid? ContractTypeStringMapId { get; set; }

    public Guid? ContractHasCoparticipationStringMapId { get; set; }

    public bool? ItbenefitException { get; set; }

    public bool? ConsentReceiveSpecificStuff { get; set; }

    public bool? HasOps { get; set; }

    public bool? CurrentAccess { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public DateTime? WithdrawalDate { get; set; }

    public DateTime? MedicalReturnDate { get; set; }

    public int? PreviousTreatmentAmount { get; set; }

    public string? MultipleMedicamentCompetitor { get; set; }

    public Guid? StageOfDiseaseStringMapId { get; set; }

    public bool? InInductionStage { get; set; }

    public DateTime? UpdateRiskRatingDate { get; set; }

    public bool? TermPrivacy { get; set; }

    public bool? TermConsentReceived { get; set; }

    public DateTime? DateReceivementTerm { get; set; }

    public bool? TermValidated { get; set; }

    public DateTime? DateValidation { get; set; }

    public string? TermValidatedBy { get; set; }

    public DateTime? DiseaseDiagnosticDate2 { get; set; }

    public bool? DiagnosticDisease { get; set; }

    public DateTime? DiseaseDiagnosticDate { get; set; }

    public bool? SupportFieldBool { get; set; }

    public DateTime? StartDate { get; set; }

    public int? SupportFieldInt { get; set; }

    public int? SupportFieldInt2 { get; set; }

    public int? SupportFieldInt3 { get; set; }

    public string? Dosage { get; set; }

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

    public virtual StringMap? AccessDetailStringMap { get; set; }

    public virtual AccessWay? AccessWay { get; set; }

    public virtual Account? Account { get; set; }

    public virtual StringMap? ApplicatorTypeStringMap { get; set; }

    public virtual StringMap? ContractHasCoparticipationStringMap { get; set; }

    public virtual StringMap? ContractTypeStringMap { get; set; }

    public virtual StringMap? Custom1StringMap { get; set; }

    public virtual StringMap? Custom2StringMap { get; set; }

    public virtual StringMap? DoctorAuthorizesDosageTitrationStringMap { get; set; }

    public virtual StringMap? FormofAccessStringMap { get; set; }

    public virtual StringMap? HemophiliaDegreeStringMap { get; set; }

    public virtual Voucher? Ifxitcode { get; set; }

    public virtual StringMap? IfxitstatusStringMap { get; set; }

    public virtual Voucher? Ifxotcode { get; set; }

    public virtual StringMap? IfxotstatusStringMap { get; set; }

    public virtual Account? InfusionSite { get; set; }

    public virtual StringMap? InfusionTypeStringMap { get; set; }

    public virtual StringMap? IsWorkingStringMapStringMap { get; set; }

    public virtual StringMap? JanssenitstatusStringMap { get; set; }

    public virtual StringMap? JanssenotstatusStringMap { get; set; }

    public virtual StringMap? MedicalIndicationStringMap { get; set; }

    public virtual StringMap? MedicalInstructionAccessWayStringMap { get; set; }

    public virtual StringMap? OptimizationTypeStringMap { get; set; }

    public virtual StringMap? PatientTypeStringMap { get; set; }

    public virtual StringMap? PlanCoverageStringMap { get; set; }

    public virtual Medicament? PreviousMedicament { get; set; }

    public virtual MedicamentCompetitor? PreviousMedicamentCompetitor { get; set; }

    public virtual StringMap? ReasonForNotAcceptingSmsstringMap { get; set; }

    public virtual Representative? Representative { get; set; }

    public virtual StringMap? RiskRatingStringMap { get; set; }

    public virtual StringMap? StageOfDiseaseStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual StringMap? StorageLocationStringMap { get; set; }

    public virtual StringMap? SupplyMethodStringMap { get; set; }

    public virtual StringMap? TreatmentCyclesStringMap { get; set; }

    public virtual StringMap? TreatmentIntervalStringMap { get; set; }

    public virtual StringMap? TreatmentTypeStringMap { get; set; }

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();

    public virtual StringMap? VisitRefusalReasonStringMap { get; set; }
}
