using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class IncidentItem
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Age { get; set; }

    public Guid? GenderStringMapId { get; set; }

    public string Cpf { get; set; }

    public string Telephone1 { get; set; }

    public string Telephone2 { get; set; }

    public Guid? DoctorId { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? IncidentId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public bool? Used { get; set; }

    public bool? Elegible { get; set; }

    public bool? Aproved { get; set; }

    public bool? Haspatientusedbiologiccmedicationbefore { get; set; }

    public Guid? LogisticsScheduleId { get; set; }

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

    public DateTime? RequestAccessDate { get; set; }

    public DateTime? AprovedAccessDate { get; set; }

    public virtual Account Account { get; set; }

    public virtual Disease Disease { get; set; }

    public virtual Doctor Doctor { get; set; }

    public virtual StringMap GenderStringMap { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual Incident Incident { get; set; }

    public virtual LogisticsSchedule LogisticsSchedule { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }
}
