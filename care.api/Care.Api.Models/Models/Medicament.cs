using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Medicament : BaseEntity
{

    public string? Name { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }


    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }


    public int? UseInterval { get; set; }

    public virtual ICollection<AccessMannerByProgram> AccessMannerByPrograms { get; } = new List<AccessMannerByProgram>();

    public virtual ICollection<AccessProcedureByProgram> AccessProcedureByPrograms { get; } = new List<AccessProcedureByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByPrograms { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<ActionRule> ActionRules { get; } = new List<ActionRule>();

    public virtual ICollection<AdhesionAttendance> AdhesionAttendances { get; } = new List<AdhesionAttendance>();

    public virtual ICollection<DoctorsRepresentative> DoctorsRepresentatives { get; } = new List<DoctorsRepresentative>();

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual ICollection<Logistics> Logistics { get; } = new List<Logistics>();

    public virtual ICollection<LogisticsStuff> LogisticsStuffs { get; } = new List<LogisticsStuff>();

    public virtual ICollection<PatientSalesOrder> PatientSalesOrders { get; } = new List<PatientSalesOrder>();

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<TherapeuticHistory> TherapeuticHistories { get; } = new List<TherapeuticHistory>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomData { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();

    public virtual ICollection<Disease> Diseases { get; } = new List<Disease>();

    public virtual ICollection<HealthProgram> HealthPrograms { get; } = new List<HealthProgram>();

    public virtual ICollection<Posologe> Posologes { get; } = new List<Posologe>();

    public virtual ICollection<StrengthMedicament> StrengthMedicaments { get; } = new List<StrengthMedicament>();

    public virtual ICollection<ExamDefinition> ExamDefinitions { get; } = new List<ExamDefinition>();
}
