using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Disease
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? AccessExam { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

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

    public virtual ICollection<AccessMannerByProgram> AccessMannerByPrograms { get; } = new List<AccessMannerByProgram>();

    public virtual ICollection<AccessProcedureByProgram> AccessProcedureByPrograms { get; } = new List<AccessProcedureByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByPrograms { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

    public virtual ICollection<DoctorsRepresentative> DoctorsRepresentatives { get; } = new List<DoctorsRepresentative>();

    public virtual ICollection<HealthProfessionalByProgram> HealthProfessionalByPrograms { get; } = new List<HealthProfessionalByProgram>();

    public virtual ICollection<HealthProgramDisease> HealthProgramDiseaseDiseases { get; } = new List<HealthProgramDisease>();

    public virtual ICollection<HealthProgramDisease> HealthProgramDiseaseSuspectDiseases { get; } = new List<HealthProgramDisease>();

    public virtual ICollection<IncidentItem> IncidentItems { get; } = new List<IncidentItem>();

    public virtual ICollection<Incident> Incidents { get; } = new List<Incident>();

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<MedicamentConcomitant> MedicamentConcomitants { get; } = new List<MedicamentConcomitant>();

    public virtual StringMap? StatusCodeStringMap { get; set; }
    public virtual ICollection<Treatment> TreatmentDiseases { get; } = new List<Treatment>();
    public virtual ICollection<Treatment> TreatmentDisease2s { get; } = new List<Treatment>();
    public virtual ICollection<Treatment> TreatmentDisease3s { get; } = new List<Treatment>();
    public virtual ICollection<Treatment> TreatmentDisease4s { get; } = new List<Treatment>();
    public virtual ICollection<Treatment> TreatmentDisease5s { get; } = new List<Treatment>();

    public virtual ICollection<MedicamentCompetitor> Diseases { get; } = new List<MedicamentCompetitor>();

    public virtual ICollection<Medicament> Medicaments { get; } = new List<Medicament>();
}
