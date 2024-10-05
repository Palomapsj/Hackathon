using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TreatmentHistory
{
    public Guid Id { get; set; }

    public Guid? TreatmentId { get; set; }

    public DateTime? DetailModifiedDate { get; set; }

    public Guid? TreatmentSituationId { get; set; }

    public Guid? PhaseId { get; set; }

    public Guid? TreatmentStatusId { get; set; }

    public Guid? TreatmentStatusDetailId { get; set; }

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

    public Guid? HistoryModalityStringMapId { get; set; }

    public Guid? HistoryPhaseStringMapId { get; set; }

    public Guid? HistoryStatusStringMapId { get; set; }

    public Guid? HistoryStatusDetailStringMapId { get; set; }

    public Guid? HistoryDoctorId { get; set; }

    public virtual Doctor HistoryDoctor { get; set; }

    public virtual StringMap HistoryModalityStringMap { get; set; }

    public virtual StringMap HistoryPhaseStringMap { get; set; }

    public virtual StringMap HistoryStatusDetailStringMap { get; set; }

    public virtual StringMap HistoryStatusStringMap { get; set; }

    public virtual Phase Phase { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual Treatment Treatment { get; set; }

    public virtual TreatmentSituation TreatmentSituation { get; set; }

    public virtual TreatmentStatus TreatmentStatus { get; set; }

    public virtual TreatmentStatusDetail TreatmentStatusDetail { get; set; }
}
