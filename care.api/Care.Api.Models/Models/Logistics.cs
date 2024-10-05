using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Logistics
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public Guid? LogisticsStuffId { get; set; }

    public int? Amount { get; set; }

    public Guid? LogisticsTypeStringMapId { get; set; }

    public Guid? SendStatusStringMapId { get; set; }

    public Guid? LogisticsPartnerId { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? PreviousDeliveryDate { get; set; }

    public string? TrackingCode { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? Observation { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public string? AddressReference { get; set; }

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

    public bool? UcbHasPrescription { get; set; }

    public bool? UcbValidatedPrescription { get; set; }

    public string? UcbPrescriptionValidatedBy { get; set; }

    public DateTime? UcbDateSendedPrescription { get; set; }

    public string? UcbReasonSendedBlank { get; set; }

    public Guid? UcbKitSentReasonStringMapId { get; set; }

    public DateTime? PostDate { get; set; }

    public int? DeliveryTime { get; set; }

    public Guid? SendSubStatusStringMapId { get; set; }

    public Guid? IncidentStatusStringMapId { get; set; }

    public string? IncidentDescription { get; set; }

    public string? Devolutive { get; set; }

    public DateTime? Devolutivedate { get; set; }

    public string? DevolutiveDescription { get; set; }

    public DateTime? ExpectecdDeliveryDate { get; set; }

    public string? RequestCode { get; set; }

    public Guid? MedicamentId { get; set; }

    public DateTime? DateActionLogistics { get; set; }

    public string? ReceivedBy { get; set; }

    public Guid? IntegrationStatusStringMapId { get; set; }

    public string? CorreiosTrackingCode { get; set; }

    public bool? ConfirmedReceipt { get; set; }

    public bool? CustomBoolean1 { get; set; }

    public bool? CustomBoolean2 { get; set; }

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

    public virtual StringMap? Custom1StringMap { get; set; }

    public virtual StringMap? Custom2StringMap { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual StringMap? IncidentStatusStringMap { get; set; }

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual StringMap? IntegrationStatusStringMap { get; set; }

    public virtual Account? LogisticsPartner { get; set; }

    public virtual LogisticsStuff? LogisticsStuff { get; set; }

    public virtual StringMap? LogisticsTypeStringMap { get; set; }

    public virtual Medicament? Medicament { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual StringMap? SendStatusStringMap { get; set; }

    public virtual StringMap? SendSubStatusStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Treatment? Treatment { get; set; }

    public virtual StringMap? UcbKitSentReasonStringMap { get; set; }
}
