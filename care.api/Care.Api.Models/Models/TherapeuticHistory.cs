using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TherapeuticHistory
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? MedicamentCompetitorId { get; set; }

    public int? Order { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinishDate { get; set; }

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

    public Guid? SupplyMethodStringMapId { get; set; }

    public decimal? Dosage { get; set; }

    public Guid? DosageUnitStringMapId { get; set; }

    public DateTime? DateModificationDosage { get; set; }

    public Guid? MedicamentId { get; set; }

    public Guid? DoctorId { get; set; }

    public string Description { get; set; }

    public Guid? IncidentId { get; set; }

    public virtual Doctor Doctor { get; set; }

    public virtual StringMap DosageUnitStringMap { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual Incident Incident { get; set; }

    public virtual Medicament Medicament { get; set; }

    public virtual MedicamentCompetitor MedicamentCompetitor { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual StringMap SupplyMethodStringMap { get; set; }

    public virtual Treatment Treatment { get; set; }
}
