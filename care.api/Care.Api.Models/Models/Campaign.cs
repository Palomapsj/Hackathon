using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Campaign
{
    public Guid Id { get; set; }

    public DateTime DateScheduledStart { get; set; }

    public DateTime DateScheduledEnd { get; set; }

    public Guid AccountId { get; set; }

    public string Responsible { get; set; }

    public string Telephone { get; set; }

    public string Observation { get; set; }

    public Guid? HealthProgramId { get; set; }

    public int NumberOfHealthProfessional { get; set; }

    public Guid? StatusStringMapId { get; set; }

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

    public virtual Account Account { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual ICollection<SchedulingHistory> SchedulingHistories { get; } = new List<SchedulingHistory>();

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual StringMap StatusStringMap { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual ICollection<HealthProfessional> HealthProfessionals { get; } = new List<HealthProfessional>();
}
