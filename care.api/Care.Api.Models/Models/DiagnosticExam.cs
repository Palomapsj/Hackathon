using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class DiagnosticExam
{
    public Guid Id { get; set; }

    public Guid? ExamDefinitionId { get; set; }

    public Guid? VoucherId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? LocalId { get; set; }

    public Guid? DoctorId { get; set; }

    public Guid? ExamTypeStringMapId { get; set; }

    public DateTime? ScheduleDate { get; set; }

    public DateTime? RealizationDate { get; set; }

    public bool? NeedCaptation { get; set; }

    public string Description { get; set; }

    public Guid? DiagnosticStatusStringMapId { get; set; }

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

    public string ResponsibleForReceiving { get; set; }

    public virtual StringMap DiagnosticStatusStringMap { get; set; }

    public virtual Doctor Doctor { get; set; }

    public virtual ExamDefinition ExamDefinition { get; set; }

    public virtual StringMap ExamTypeStringMap { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual Account Local { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual Treatment Treatment { get; set; }

    public virtual Voucher Voucher { get; set; }
}
