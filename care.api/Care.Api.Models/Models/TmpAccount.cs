using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpAccount
{
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? ExamDefinitionId { get; set; }

    public string AddressCity { get; set; }

    public string AddressState { get; set; }

    public string AddressDistrict { get; set; }

    public string Cnpj { get; set; }

    public string AddressName { get; set; }

    public string AddressPostalCode { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string OwnerIdName { get; set; }

    public string Telephone1 { get; set; }

    public string EmailAddress { get; set; }

    public string MainContact { get; set; }

    public string ImportCode { get; set; }
}
