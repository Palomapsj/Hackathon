using Care.Api.Models.Models;

namespace Care.Api.Models;

public partial class Caregiver : BaseEntity
{
    public Guid? CivilStatusStringMapId { get; set; }

    public Guid? EducationStringMapId { get; set; }

    public Guid? OccupationId { get; set; }

    public decimal? Stature { get; set; }

    public decimal? Weight { get; set; }

    public int? Age { get; set; }

    public Guid? GenderStringMapId { get; set; }

    public Guid? KinshipStringMapId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public string? Name { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? Rg { get; set; }

    public string? Cpf { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? Telephone3 { get; set; }

    public string? Mobilephone1 { get; set; }

    public string? Mobilephone2 { get; set; }

    public string? Mobilephone3 { get; set; }

    public string? EmailAddress1 { get; set; }

    public string? EmailAddress2 { get; set; }

    public string? SkypeUser { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public virtual StringMap? CivilStatusStringMap { get; set; }

    public virtual ICollection<CustomerAddress>? CustomerAddresses { get; } = new List<CustomerAddress>();

    public virtual ICollection<Diagnostic>? Diagnostics { get; } = new List<Diagnostic>();

    public virtual StringMap? EducationStringMap { get; set; }

    public virtual StringMap? GenderStringMap { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual StringMap? KinshipStringMap { get; set; }

    public virtual Occupation? Occupation { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }
    public virtual ICollection<Treatment>? Treatments { get; } = new List<Treatment>();

    public virtual ICollection<CaregiverTreatment>? CaregiverTreatments { get; } = new List<CaregiverTreatment>();

    public string? CustomString1 { get; set; }
}
