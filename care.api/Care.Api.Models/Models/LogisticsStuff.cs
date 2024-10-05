namespace Care.Api.Models;

public partial class LogisticsStuff : BaseEntity
{
    public string? Name { get; set; }

    public string? CodeNumber { get; set; }

    public string? Description { get; set; }

    public int? AvailableQuantity { get; set; }

    public Guid? LogisticsStuffTypeStringMapId { get; set; }

    public Guid? StuffStatusStringMapId { get; set; }

    public string? Sapcode { get; set; }

    public string? Anvisacode { get; set; }

    public string? BarCode { get; set; }

    public string? TaxClassification { get; set; }

    public decimal? ListPrice { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? ManufacturerId { get; set; }

    public Guid? MedicamentId { get; set; }

    public Guid? StrengthMedicamentId { get; set; }

    public string? Packing { get; set; }

    public bool? IsInStock { get; set; }

    public string? ProductFeatures { get; set; }

    public DateTime? ForecastCast { get; set; }

    public bool? IsControlled { get; set; }

    public bool? NeedsAprovals { get; set; }

    public bool? HasPeriodicSend { get; set; }

    public bool? IsReset { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public Guid? KitId { get; set; }

    public bool? PrescritionIsRequired { get; set; }

    public Guid? LogisticsScheduleId { get; set; }

    public bool? HasServFarmaIntegration { get; set; }

    public string? LaboratoryCode { get; set; }

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual ICollection<LogisticsStuff> InverseKit { get; } = new List<LogisticsStuff>();

    public virtual LogisticsStuff? Kit { get; set; }

    public virtual ICollection<Logistics> Logistics { get; } = new List<Logistics>();

    public virtual LogisticsSchedule? LogisticsSchedule { get; set; }

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual StringMap? LogisticsStuffTypeStringMap { get; set; }

    public virtual Account? Manufacturer { get; set; }

    public virtual Medicament? Medicament { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual StrengthMedicament? StrengthMedicament { get; set; }

    public virtual StringMap? StuffStatusStringMap { get; set; }

    public virtual ICollection<LogisticsStuff> Kits { get; } = new List<LogisticsStuff>();

    public virtual ICollection<LogisticsStuff> LogisticsStuffs { get; } = new List<LogisticsStuff>();
}
