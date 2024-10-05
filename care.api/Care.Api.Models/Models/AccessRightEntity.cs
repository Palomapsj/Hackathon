using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AccessRightEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string EntityMetadataIdName { get; set; }

    public Guid? EntityMetadataId { get; set; }

    public bool? Create { get; set; }

    public bool? Read { get; set; }

    public bool? Update { get; set; }

    public bool? Delete { get; set; }

    public bool? HasActivities { get; set; }

    public bool? IsVisibleMenu { get; set; }

    public bool? Annotations { get; set; }

    public bool? Inactivation { get; set; }

    public Guid? AccessProfileId { get; set; }

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

    public string EntityOriginalValues { get; set; }

    public bool? HasSurvey { get; set; }

    public virtual AccessProfile AccessProfile { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }
}
