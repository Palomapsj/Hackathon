using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class MedicamentAccess
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? AccessWayId { get; set; }

    public Guid? AccessMannerId { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? AccessStatusStringMapId { get; set; }

    public Guid? AccessSubStatusStringMapId { get; set; }

    public Guid? AccessTypeStringMapId { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? TreatmentId { get; set; }

    public DateTime? AttemptAccessDate { get; set; }

    public DateTime? DocumentSeparatedDate { get; set; }

    public DateTime? DocumentDeliveredDate { get; set; }

    public bool? AttemptAccessFinished { get; set; }

    public DateTime? LastAttemptAccessDate { get; set; }

    public DateTime? NextAttemptAccessDate { get; set; }

    public Guid? AttemptAccessModifiedById { get; set; }

    public DateTime? AttemptAccessCancelDate { get; set; }

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

    public Guid? DetailDifficultyWithAccessStringMapId { get; set; }

    public Guid? DetailNoDifficultyWithAccessStringMapId { get; set; }

    public Guid? DetailDifficultyWithDocumentsStringMapId { get; set; }

    public DateTime? AttemptAccessDateSystem { get; set; }

    public DateTime? DocumentSeparatedDateSystem { get; set; }

    public DateTime? DocumentDeliveredDateSystem { get; set; }

    public DateTime? GotAccessDate { get; set; }

    public DateTime? GotAccessDateSystem { get; set; }

    public string NextStepAccess { get; set; }

    public string NextAccessAction { get; set; }

    public virtual ICollection<AccessHistoryAttendance> AccessHistoryAttendances { get; } = new List<AccessHistoryAttendance>();

    public virtual AccessManner AccessManner { get; set; }

    public virtual StringMap AccessStatusStringMap { get; set; }

    public virtual StringMap AccessSubStatusStringMap { get; set; }

    public virtual StringMap AccessTypeStringMap { get; set; }

    public virtual AccessWay AccessWay { get; set; }

    public virtual Account Account { get; set; }

    public virtual User AttemptAccessModifiedBy { get; set; }

    public virtual StringMap DetailDifficultyWithAccessStringMap { get; set; }

    public virtual StringMap DetailDifficultyWithDocumentsStringMap { get; set; }

    public virtual StringMap DetailNoDifficultyWithAccessStringMap { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual Patient Patient { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual Treatment Treatment { get; set; }
}
