using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AdhesionAttendance
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? TreatmentId { get; set; }

    public bool? HasUsed { get; set; }

    public Guid? MedicationNonadherenceReasonId { get; set; }

    public bool? KeepOnTheProgram { get; set; }

    public DateTime? TreatmentFinishedDate { get; set; }

    public DateTime? ExpectedDateToReturn { get; set; }

    public Guid? TreatmentSettingsId { get; set; }

    public Guid? MedicamentCompetitorId { get; set; }

    public string Description { get; set; }

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

    public bool? TreatmentStarted { get; set; }

    public DateTime? TreatmentStartDate { get; set; }

    public bool? WillStart { get; set; }

    public DateTime? DateToStart { get; set; }

    public Guid? DetailDifficultyWithAccessStringMapId { get; set; }

    public bool? ConsentDataShare { get; set; }

    public Guid? OriginStringMapId { get; set; }

    public int? Month { get; set; }

    public int? Week { get; set; }

    public bool? FollowedPrescription { get; set; }

    public Guid? DosageStringMapId { get; set; }

    public Guid? FrequencyStringMapId { get; set; }

    public Guid? MedicamentId { get; set; }

    public Guid? AccountId { get; set; }

    public DateTime? LastDate { get; set; }

    public bool? ReleaseNextShipment { get; set; }

    public DateTime? NextDate { get; set; }

    public Guid? TreatmentIntervalStringMapId { get; set; }

    public DateTime? DateofLastInfusion { get; set; }

    public DateTime? DateofNextInfusion { get; set; }

    public DateTime? DateofLastConsultation { get; set; }

    public DateTime? DateoftheNextConsultation { get; set; }

    public DateTime? DateofUse { get; set; }

    public int? Cycle { get; set; }

    public bool? PharmacovigilanceReported { get; set; }

    public string Dosage { get; set; }

    public bool? DoseOptimizationPatient { get; set; }

    public virtual Account Account { get; set; }

    public virtual StringMap DetailDifficultyWithAccessStringMap { get; set; }

    public virtual StringMap FrequencyStringMap { get; set; }

    public virtual Medicament Medicament { get; set; }

    public virtual MedicamentCompetitor MedicamentCompetitor { get; set; }

    public virtual MedicationNonadherenceReason MedicationNonadherenceReason { get; set; }

    public virtual StringMap OriginStringMap { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual Treatment Treatment { get; set; }

    public virtual StringMap TreatmentIntervalStringMap { get; set; }

    public virtual TreatmentSetting TreatmentSettings { get; set; }
}
