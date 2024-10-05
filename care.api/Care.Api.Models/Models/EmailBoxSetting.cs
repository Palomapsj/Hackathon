using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class EmailBoxSetting
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public int Port { get; set; }

    public string Host { get; set; }

    public string Smtp { get; set; }

    public Guid? HealthProgramId { get; set; }

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

    public virtual ICollection<Email> Emails { get; } = new List<Email>();

    public virtual ICollection<HealthProgramTemplateSetting> HealthProgramTemplateSettings { get; } = new List<HealthProgramTemplateSetting>();

    public virtual StringMap StatusCodeStringMap { get; set; }
}
