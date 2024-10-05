using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Benefit
{
    public Guid Id { get; set; }

    public Guid? BenefitTypeStringMapId { get; set; }

    public Guid? VoucherId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? TreatmentId { get; set; }

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

    public DateTime? ScheduleDate { get; set; }

    public DateTime? RealizationDate { get; set; }

    public Guid? LocalId { get; set; }

    public Guid? DiagnosticId { get; set; }

    public Guid? BenefitStatusStringMapId { get; set; }

    public Guid? SourceStringMapId { get; set; }

    public DateTime? PreviewDate { get; set; }

    public bool? CustomBoolean1 { get; set; }

    public bool? CustomBoolean2 { get; set; }

    public string CustomString1 { get; set; }

    public string CustomString2 { get; set; }

    public string CustomString3 { get; set; }

    public Guid? Custom1StringMapId { get; set; }

    public Guid? Custom2StringMapId { get; set; }

    public virtual StringMap BenefitStatusStringMap { get; set; }

    public virtual StringMap BenefitTypeStringMap { get; set; }

    public virtual StringMap Custom1StringMap { get; set; }

    public virtual StringMap Custom2StringMap { get; set; }

    public virtual Diagnostic Diagnostic { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual Account Local { get; set; }

    public virtual StringMap SourceStringMap { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual Treatment Treatment { get; set; }

    public virtual Voucher Voucher { get; set; }
}
