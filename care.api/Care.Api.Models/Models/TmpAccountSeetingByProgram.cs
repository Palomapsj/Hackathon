using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpAccountSeetingByProgram
{
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? ExamDefinitionId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string OwnerIdName { get; set; }

    public bool? StateCode { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? StatusCodeStringMapId { get; set; }
}
