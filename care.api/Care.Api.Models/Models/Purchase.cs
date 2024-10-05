namespace Care.Api.Models;

public partial class Purchase : BaseEntity
{
    public Guid? HealthProgramId { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? MedicamentId { get; set; }

    public Guid? TreatmentId { get; set; }

    public int? Amount { get; set; }

    public string? Identifier { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public string? Lot { get; set; }

    public string? PointOfPurchase { get; set; }

    public string? Observations { get; set; }

    public string? Doctor { get; set; }

    public string? Name { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public Guid? AccountId { get; set; }

    public int? PenDosage { get; set; }

    public decimal? PrescribedDosage { get; set; }

    public int? AmpouleDuration { get; set; }

    public Guid? FrequencyStringMapId { get; set; }

    public Guid? PrescriptionTypeStringMapId { get; set; }

    public string? FriendlyCode { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonDeleted { get; set; }

    public virtual Account? Account { get; set; }

    public virtual StringMap? FrequencyStringMap { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual Medicament? Medicament { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual StringMap? PrescriptionTypeStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Treatment? Treatment { get; set; }
}
