using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

public partial class Patient : BaseEntity
{
    [NotMapped]
    public static int EntityTypeCode => 200;

    [NotMapped]
    public static string EntityName => "Patient";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("7d70e1e1-3cc8-4d66-b77f-929ab4b8a06d");

    public string? Name { get; set; }

    public string? AbbreviationName { get; set; }

    public Guid? CivilStatusStringMapId { get; set; }

    public Guid? EducationStringMapId { get; set; }

    public Guid? OccupationId { get; set; }

    public decimal? Stature { get; set; }

    public decimal? Weight { get; set; }

    public int? Age { get; set; }

    public Guid? GenderStringMapId { get; set; }

    public Guid? HealthProgramId { get; set; }

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

    public Guid? PatientTypeStringMapId { get; set; }

    public Guid? SystemUserId { get; set; }

    public virtual StringMap? CivilStatusStringMap { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; } = new List<CustomerAddress>();

    public virtual ICollection<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

    public virtual StringMap? EducationStringMap { get; set; }

    public virtual StringMap? GenderStringMap { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual ICollection<Incident> Incidents { get; } = new List<Incident>();

    public virtual ICollection<Logistics> Logistics { get; } = new List<Logistics>();

    public virtual ICollection<MedicamentAccess> MedicamentAccesses { get; } = new List<MedicamentAccess>();

    public virtual Occupation? Occupation { get; set; }

    public virtual ICollection<PatientSalesOrder> PatientSalesOrders { get; } = new List<PatientSalesOrder>();

    public virtual StringMap? PatientTypeStringMap { get; set; }

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual User? SystemUser { get; set; }

    public virtual ICollection<TreatmentPayment> TreatmentPayments { get; } = new List<TreatmentPayment>();

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();
}
