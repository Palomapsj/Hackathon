﻿using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ActionRule
{
    public Guid Id { get; set; }

    public int PeriodicityDays { get; set; }

    public int Attempt { get; set; }

    public bool IsSuccess { get; set; }

    public bool IsContinuous { get; set; }

    public Guid? ActionConfigurationId { get; set; }

    public string Name { get; set; }

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

    public Guid? HealthProgramId { get; set; }

    public Guid? MedicamentId { get; set; }

    public virtual ActionConfiguration ActionConfiguration { get; set; }

    public virtual Medicament Medicament { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual ICollection<TreatmentAndDiagnosticAction> TreatmentAndDiagnosticActions { get; } = new List<TreatmentAndDiagnosticAction>();
}
