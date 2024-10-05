using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class HealthProfessionalByProgram : BaseEntity 
{

    public decimal ValueAttendance { get; set; }

    public decimal ValuePerKm { get; set; }

    public Guid? HealthProfessionalId { get; set; }

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


    public Guid? HealthProgramId { get; set; }

    public bool HasTraining { get; set; }

    public DateTime EffectiveDateInitialDocument { get; set; }

    public DateTime EffectiveDateFinalDocument { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? ConsultantId { get; set; }

    public string? IndicatedConsultantName { get; set; }

    public string? IndicatedConsultantEmail { get; set; }

    public Guid? NurceStatusStringMapId { get; set; }

    public string? Password { get; set; }

    public Guid? LocalId { get; set; }

    public virtual User Consultant { get; set; }

    public virtual Disease Disease { get; set; }

    public virtual HealthProfessional HealthProfessional { get; set; }

    public virtual Account Local { get; set; }

    public virtual StringMap NurceStatusStringMap { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }
}
