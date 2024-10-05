using Care.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

public partial class DoctorByProgram : BaseEntity
{
    [NotMapped]
    public static int EntityTypeCode => 208;

    [NotMapped]
    public static string EntityName => "DoctorByProgram";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("ECC363BD-8DA2-5CB4-BC3C-93DE653E0098");



    public bool? ProgramParticipationConsent { get; set; }

    public bool? DiagnosticConsent { get; set; }

    public bool? ConfirmPersonalInformation { get; set; }

    public DateTime? ProgramParticipationConsentDate { get; set; }

    public string? ProgramParticipationConsentComments { get; set; }

    public string? DiagnosticConsentComments { get; set; }

    public Guid? ConsultantId { get; set; }

    public DateTime? ProgramRequestDate { get; set; }

    public string? Reason { get; set; }

    public string? Password { get; set; }

    public bool? IsProgramParticipationApproved { get; set; }

    public bool? IsDiagnosticConsentApproved { get; set; }

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

    public Guid? DoctorId { get; set; }

    public Guid? AuthorizeVisitStringMapId { get; set; }

    public Guid? AuthorizeSmsstringMapId { get; set; }

    public Guid? AuthorizesTitrationofDosageStringMapId { get; set; }

    public bool? ConsentToReceiveEmail { get; set; }

    public DateTime? RequestDiagnosticConsentDate { get; set; }

    public bool? ProgramParticipationConsent2 { get; set; }

    public bool? DiagnosticConsent2 { get; set; }

    public Guid? SystemUserId { get; set; }

    public string? LicenseNumber { get; set; }

    public string? LicenseState { get; set; }

    public bool? ProgramParticipationConsent3 { get; set; }

    public string? Specialty { get; set; }

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

    public bool? ConsentToReceivePhonecalls { get; set; }

    public bool? ConsentToReceiveSms { get; set; }

    public bool? ConsentLgpd { get; set; }

    public DateTime? ConsentLgpddate { get; set; }

    public Guid? SourceConsentStringMapId { get; set; }

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByPrograms { get; } = new List<AccountSettingsByProgram>();

    public virtual StringMap? AuthorizeSmsstringMap { get; set; }

    public virtual StringMap? AuthorizeVisitStringMap { get; set; }

    public virtual StringMap? AuthorizesTitrationofDosageStringMap { get; set; }

    public virtual User? Consultant { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual StringMap? SourceConsentStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual User? SystemUser { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
