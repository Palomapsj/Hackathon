using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AccessHistoryAttendance
{
    public Guid Id { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? MedicamentAccessId { get; set; }

    public bool? AttemptAccess { get; set; }

    public DateTime? AttemptAccessDate { get; set; }

    public bool? KeepAttempt { get; set; }

    public DateTime? NextAttemptAccess { get; set; }

    public bool? DocumentDelivered { get; set; }

    public DateTime? DocumentDeliveredDate { get; set; }

    public bool? DocumentSeparated { get; set; }

    public DateTime? DocumentSeparatedDate { get; set; }

    public bool? DifficultyWithDocument { get; set; }

    public bool? ExplainedByAttendant { get; set; }

    public bool? GotAccess { get; set; }

    public DateTime? GotAccessDate { get; set; }

    public bool? KeepAttemptAccess { get; set; }

    public bool? DifficultyWithAccess { get; set; }

    public Guid? WaiverDetailStringMapId { get; set; }

    public bool? TreatmentStarted { get; set; }

    public bool? WillStart { get; set; }

    public DateTime? DateToStart { get; set; }

    public DateTime? TreatmentStartDate { get; set; }

    public string Description { get; set; }

    public Guid? HealthProgramId { get; set; }

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

    public string Name { get; set; }

    public Guid? DetailDifficultyWithAccessStringMapId { get; set; }

    public Guid? DetailNoDifficultyWithAccessStringMapId { get; set; }

    public Guid? DetailDifficultyWithDocumentsStringMapId { get; set; }

    public Guid? TreatmentSettingsId { get; set; }

    public bool? ConsentDataShare { get; set; }

    public bool? InactivateTreatment { get; set; }

    public virtual StringMap DetailDifficultyWithAccessStringMap { get; set; }

    public virtual StringMap DetailDifficultyWithDocumentsStringMap { get; set; }

    public virtual StringMap DetailNoDifficultyWithAccessStringMap { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual MedicamentAccess MedicamentAccess { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual Treatment Treatment { get; set; }

    public virtual TreatmentSetting TreatmentSettings { get; set; }

    public virtual StringMap WaiverDetailStringMap { get; set; }
}
