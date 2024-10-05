namespace Care.Api.Models;

public partial class TreatmentAddress : BaseEntity
{
    public string? Name { get; set; }

    public Guid? CustomerAddressId { get; set; }

    public Guid? CoverageAreaId { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public bool? VisitAddress { get; set; }

    public bool? ReceiveMail { get; set; }

    public bool? MainAddress { get; set; }

    public Guid? TreatmentId { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public string? AddressReference { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public bool? IsintheAreaofCoverage { get; set; }

    public Guid? AddressTypeStringMapId { get; set; }

    public virtual StringMap? AddressTypeStringMap { get; set; }

    public virtual CoverageArea? CoverageArea { get; set; }

    public virtual CustomerAddress? CustomerAddress { get; set; }

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Treatment? Treatment { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
