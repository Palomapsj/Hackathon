using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AccessProfile
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? AccessProfileTypeStringMapId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string? ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? OwnerId { get; set; }

    public string? OwnerIdName { get; set; }

    public bool? StateCode { get; set; }

    public Guid? StatusCodeStringMapId { get; set; }

    public string? EntityOriginalValues { get; set; }

    public virtual StringMap? AccessProfileTypeStringMap { get; set; }

    public virtual ICollection<AccessRightEntity>? AccessRightEntities { get; } = new List<AccessRightEntity>();

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<User>? Users { get; } = new List<User>();
}
