using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class CustomerAddress : BaseEntity
{

    public string? AddressState { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressCountry { get; set; }

    public Guid? AddressTypeStringMapId { get; set; }

    public string? AddressName { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public bool? PrincipalAddress { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? CaregiverId { get; set; }

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

    public string? Name { get; set; }

    public virtual StringMap? AddressTypeStringMap { get; set; }

    public virtual Caregiver? Caregiver { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<TreatmentAddress> TreatmentAddresses { get; } = new List<TreatmentAddress>();
}
