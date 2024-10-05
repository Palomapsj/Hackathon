using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TreatmentPayment
{
    public Guid Id { get; set; }

    public Guid? TreatmentPaymentStatusStringMapId { get; set; }

    public Guid? VisitId { get; set; }

    public Guid? ExamId { get; set; }

    public Guid? InfusionId { get; set; }

    public decimal ValueVisit { get; set; }

    public decimal ValueVisitPerKm { get; set; }

    public decimal ValueVisitCalculated { get; set; }

    public decimal EstimatedVisitkm { get; set; }

    public decimal PerformedVisitkm { get; set; }

    public decimal ValueVisitPay { get; set; }

    public decimal InvoiceAmount { get; set; }

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

    public Guid? HealthProgramId { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public Guid? PatientId { get; set; }

    public string ForwardReason { get; set; }

    public virtual Exam Exam { get; set; }

    public virtual HealthProfessional HealthProfessional { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual Infusion Infusion { get; set; }

    public virtual Patient Patient { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual Treatment Treatment { get; set; }

    public virtual StringMap TreatmentPaymentStatusStringMap { get; set; }

    public virtual Visit Visit { get; set; }
}
