using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ActionConfiguration
{
    public Guid Id { get; set; }

    public string? ActionCode { get; set; }

    public string? Name { get; set; }

    public string? SourceEntityName { get; set; }

    public string? SourceEntityTypeCode { get; set; }

    public Guid? ProgramId { get; set; }

    public int Type { get; set; }

    public int Receiver { get; set; }

    public string? Description { get; set; }

    public Guid? ActionCategoryId { get; set; }

    public string? ActionColorHex { get; set; }

    public string? BaseDateField { get; set; }

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

    public Guid? HealthProgramId { get; set; }

    public bool? UnplannedSubject { get; set; }

    public Guid? ActionOwnerStringMapId { get; set; }

    public virtual ActionCategory? ActionCategory { get; set; }

    public virtual StringMap? ActionOwnerStringMap { get; set; }

    public virtual ICollection<ActionRule> ActionRules { get; } = new List<ActionRule>();

    public virtual HealthProgram? Program { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<TreatmentAndDiagnosticAction> TreatmentAndDiagnosticActions { get; } = new List<TreatmentAndDiagnosticAction>();
}
