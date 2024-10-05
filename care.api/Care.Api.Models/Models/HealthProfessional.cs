using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class HealthProfessional : BaseEntity
{

    public string? Pis { get; set; }

    public Guid? HiringTypeStringMapId { get; set; }

    public Guid? NurseProfessionalTypeStringMapId { get; set; }

    public Guid? BankId { get; set; }

    public string? BankAgencyNumber { get; set; }

    public string? BankAccountNumber { get; set; }

    public Guid? BankAccountTypeStringMapId { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

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


    public Guid? ProfessionalLicenseTypeStringMapId { get; set; }

    public string? LicenseNumber { get; set; }

    public string? LicenseState { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public Guid? UserId { get; set; }

    public Guid? GenderStringMapId { get; set; }

    public string? ContactHours { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual Bank? Bank { get; set; }

    public virtual StringMap? BankAccountTypeStringMap { get; set; }

    public virtual ICollection<CalendarScheduled> CalendarScheduleds { get; } = new List<CalendarScheduled>();

    public virtual ICollection<Communication> Communications { get; } = new List<Communication>();

    public virtual ICollection<CoverageArea> CoverageAreas { get; } = new List<CoverageArea>();

    public virtual ICollection<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual StringMap? GenderStringMap { get; set; }

    public virtual ICollection<HealthProfessionalByProgram> HealthProfessionalByPrograms { get; } = new List<HealthProfessionalByProgram>();

    public virtual StringMap? HiringTypeStringMap { get; set; }

    public virtual ICollection<Infusion> InfusionAccountableHealthProfessionals { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionInfusionPlaceProfessionals { get; } = new List<Infusion>();

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual StringMap? NurseProfessionalTypeStringMap { get; set; }

    public virtual StringMap? ProfessionalLicenseTypeStringMap { get; set; }

    public virtual ICollection<ResourceWorkSetting> ResourceWorkSettings { get; } = new List<ResourceWorkSetting>();

    public virtual ICollection<SchedulingHistory> SchedulingHistories { get; } = new List<SchedulingHistory>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<TrainingRecord> TrainingRecords { get; } = new List<TrainingRecord>();

    public virtual ICollection<TreatmentAddress> TreatmentAddresses { get; } = new List<TreatmentAddress>();

    public virtual ICollection<TreatmentPayment> TreatmentPayments { get; } = new List<TreatmentPayment>();

    public virtual User? User { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual ICollection<Campaign> Campaigns { get; } = new List<Campaign>();

    public virtual ICollection<HealthProgram> HealthPrograms { get; } = new List<HealthProgram>();

    public virtual ICollection<MedicalSpecialty> MedicalSpecialties { get; } = new List<MedicalSpecialty>();
}
