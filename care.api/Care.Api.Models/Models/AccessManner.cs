using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AccessManner
{
    public Guid Id { get; set; }

    public string Name { get; set; }

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

    public virtual ICollection<AccessOrderByProgram> AccessOrderByPrograms { get; } = new List<AccessOrderByProgram>();

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual ICollection<MedicamentAccess> MedicamentAccesses { get; } = new List<MedicamentAccess>();

    public virtual StringMap StatusCodeStringMap { get; set; }
}
