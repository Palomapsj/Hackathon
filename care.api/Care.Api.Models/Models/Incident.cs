using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

public partial class Incident : BaseEntity
{
    [NotMapped]
    public static int EntityTypeCode => 1100;

    [NotMapped]
    public static string EntityName => "Incident";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("D4B41170-EC54-426D-8D49-ACE9C5D347D4");

    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? Subject { get; set; }

    public Guid? StatusStringMapId { get; set; }

    public Guid? OriginStringMapId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? CustomerTypeStringMapId { get; set; }

    public Guid? AccountTypeStringMapId { get; set; }

    public string? CustomerAccountName { get; set; }

    public string? Cnpj { get; set; }

    public Guid? AccountId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? Cpf { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? EmailAddress1 { get; set; }

    public Guid? PatientId { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public string? AddressReference { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? TelephoneFax { get; set; }

    public Guid? IncidentProductId { get; set; }

    public Guid? IncidentTypeId { get; set; }

    public Guid? IncidentTypeDetailId { get; set; }

    public string? Description { get; set; }

    public Guid? TreatmentId { get; set; }

    public string? Name { get; set; }





    public string? CreatedByName { get; set; }


    public string? ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }



    public string? OwnerIdName { get; set; }



    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public string? EntityOriginalValues { get; set; }

    public Guid? RegardingEntityId { get; set; }

    public Guid? ContactTypeStringMapId { get; set; }

    public Guid? DoctorId { get; set; }

    public string? DoctorCpf { get; set; }

    public string? LicenseNumber { get; set; }

    public Guid? RepresentativeId { get; set; }

    public Guid? RequestStatusStringMapId { get; set; }

    public int? Amount { get; set; }

    public int? SendPeriodicity { get; set; }

    public int? AmountPatientInfusing { get; set; }

    public DateTime? RequestDateStart { get; set; }

    public DateTime? RequestDateEnd { get; set; }

    public string? RequestBy { get; set; }

    public string? ResponsibleForReceiving { get; set; }

    public string? TelephoneReceiver { get; set; }

    public Guid? DistributorLogisticId { get; set; }

    public string? PartnerCode { get; set; }

    public string? Cte { get; set; }

    public DateTime? InformedDateByPartner { get; set; }

    public bool? DeliveryDone { get; set; }

    public bool? PartnerConfirmDelivery { get; set; }

    public Guid? IncidentSubjectId { get; set; }

    public string? Lot { get; set; }

    public string? AcquisitionLocation { get; set; }

    public Guid? DiseaseId { get; set; }

    public bool? ProgramParticipationConsent { get; set; }

    public bool? ConsentToReceivePhonecalls { get; set; }

    public bool? ConsentToReceiveSms { get; set; }

    public bool? ConsentToReceiveEmail { get; set; }

    public bool? ConsentToReceiveVisit { get; set; }

    public bool? ConsentToReceiveLogistics { get; set; }

    public bool? ConsentToSendDataToDoctor { get; set; }

    public bool? ConsentDataShare { get; set; }

    public bool? PrescriptionReceived { get; set; }

    public DateTime? PrescriptionReceivedDate { get; set; }

    public bool? PrescriptionIsValid { get; set; }

    public Guid? PrescriptionStatusStringMapId { get; set; }

    public DateTime? PrescriptionValidationDate { get; set; }

    public string? PrescriptionValidatedByName { get; set; }

    public decimal? Weight { get; set; }

    public Guid? PreviousMedicamentCompetitorId { get; set; }

    public string? SectorOfTheRequester { get; set; }

    public int? Age { get; set; }

    public Guid? MedicalSpecialtyId { get; set; }

    public Guid? TreatmentLineStringMapId { get; set; }

    public string? AccountAuthorizationNumber { get; set; }

    public string? AddressCityPatient { get; set; }

    public string? AddressStatePatient { get; set; }

    public string? AddressCityDoctor { get; set; }

    public string? AddressStateDoctor { get; set; }

    public bool? CustomBoolean1 { get; set; }

    public bool? CustomBoolean2 { get; set; }

    public bool? CustomBoolean3 { get; set; }

    public bool? CustomBoolean4 { get; set; }

    public string? CustomString1 { get; set; }

    public string? CustomString2 { get; set; }

    public string? CustomString3 { get; set; }

    public string? CustomString4 { get; set; }

    public string? CustomString5 { get; set; }

    public string? CustomString6 { get; set; }

    public DateTime? CustomDateTime1 { get; set; }

    public DateTime? CustomDateTime2 { get; set; }

    public Guid? Custom1StringMapId { get; set; }

    public Guid? Custom2StringMapId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual StringMap? AccountTypeStringMap { get; set; }

    public virtual StringMap? ContactTypeStringMap { get; set; }

    public virtual StringMap? Custom1StringMap { get; set; }

    public virtual StringMap? Custom2StringMap { get; set; }

    public virtual StringMap? CustomerTypeStringMap { get; set; }

    public virtual Disease? Disease { get; set; }

    public virtual Account? DistributorLogistic { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual ICollection<IncidentItem> IncidentItems { get; } = new List<IncidentItem>();

    public virtual IncidentProduct? IncidentProduct { get; set; }

    public virtual IncidentSubject? IncidentSubject { get; set; }

    public virtual IncidentType? IncidentType { get; set; }

    public virtual IncidentTypeDetail? IncidentTypeDetail { get; set; }

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual MedicalSpecialty? MedicalSpecialty { get; set; }

    public virtual StringMap? OriginStringMap { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<Pharmacovigilance> Pharmacovigilances { get; } = new List<Pharmacovigilance>();

    public virtual StringMap? PrescriptionStatusStringMap { get; set; }

    public virtual MedicamentCompetitor? PreviousMedicamentCompetitor { get; set; }

    public virtual RegardingEntity? RegardingEntity { get; set; }

    public virtual Representative? Representative { get; set; }

    public virtual StringMap? RequestStatusStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual StringMap? StatusStringMap { get; set; }

    public virtual ICollection<TherapeuticHistory> TherapeuticHistories { get; } = new List<TherapeuticHistory>();

    public virtual Treatment? Treatment { get; set; }

    public virtual ICollection<TreatmentAndDiagnosticAction> TreatmentAndDiagnosticActions { get; } = new List<TreatmentAndDiagnosticAction>();

    public virtual StringMap? TreatmentLineStringMap { get; set; }
}
