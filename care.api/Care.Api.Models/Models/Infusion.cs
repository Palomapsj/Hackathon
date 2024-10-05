using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Infusion
{
    public static int EntityTypeCode => 804;
    public static string EntityName => "Infusion";
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? InfusionTypeStringMapId { get; set; }

    public Guid? InfusionPlaceTypeStringMapId { get; set; }

    public Guid? PlaceId { get; set; }

    public Guid? InfusionPlaceProfessionalId { get; set; }

    public Guid? DoctorId { get; set; }

    public DateTime? ScheduledDate { get; set; }

    public Guid? VoucherId { get; set; }

    public Guid? InfusionStatusStringMapId { get; set; }

    public string? Observations { get; set; }

    public DateTime? ActualDate { get; set; }

    public decimal? AmpouleAmount { get; set; }

    public decimal? Dosage { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? HealthProgramId { get; set; }

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

    public Guid? ApplicationTypeStringMapId { get; set; }

    public Guid? AccountableHealthProfessionalId { get; set; }

    public Guid? InfusionWeekStringMapId { get; set; }

    public bool? ApprovalRequired { get; set; }

    public bool? InfusionApproved { get; set; }

    public string? ExceptionReason { get; set; }

    public DateTime? PreviousInfusionDate { get; set; }

    public int? RemipackKitQuantity { get; set; }

    public string? Lot { get; set; }

    public bool? IsPaid { get; set; }

    public string? PaidBy { get; set; }

    public DateTime? PaymentSubmissionDate { get; set; }

    public bool? PrescriptionSent { get; set; }

    public bool? PrescriptionValidated { get; set; }

    public DateTime? PrescriptionValidationDate { get; set; }

    public string? ValidatedBy { get; set; }

    public DateTime? PreviewDate { get; set; }

    public decimal? Weight { get; set; }

    public decimal? AmpouleAmountStored { get; set; }

    public decimal? AmpouleAmountExpected { get; set; }

    public string? Reason { get; set; }

    public Guid? ReasonInfusionNotDoneStringMapId { get; set; }

    public Guid? InfusionDispatchNumberStringMapId { get; set; }

    public int? UseNumber { get; set; }

    public int? Days { get; set; }

    public int? Month { get; set; }

    public Guid? LogisticsId { get; set; }

    public Guid? PatientSalesOrderId { get; set; }

    public Guid? MedicamentId { get; set; }

    public int? Week { get; set; }

    public Guid? SupportFieldStringMapId { get; set; }

    public virtual HealthProfessional? AccountableHealthProfessional { get; set; }

    public virtual StringMap? ApplicationTypeStringMap { get; set; }

    public virtual Disease? Disease { get; set; }

    public virtual Doctor? Doctor { get; set; }
    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual StringMap? InfusionDispatchNumberStringMap { get; set; }

    public virtual HealthProfessional? InfusionPlaceProfessional { get; set; }

    public virtual StringMap? InfusionPlaceTypeStringMap { get; set; }

    public virtual StringMap? InfusionStatusStringMap { get; set; }

    public virtual StringMap? InfusionTypeStringMap { get; set; }

    public virtual StringMap? InfusionWeekStringMap { get; set; }

    public virtual Logistics? Logistics { get; set; }

    public virtual Medicament? Medicament { get; set; }

    public virtual PatientSalesOrder? PatientSalesOrder { get; set; }

    public virtual Account? Place { get; set; }

    public virtual StringMap? ReasonInfusionNotDoneStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual StringMap? SupportFieldStringMap { get; set; }

    public virtual Treatment? Treatment { get; set; }

    public virtual ICollection<TreatmentPayment> TreatmentPayments { get; } = new List<TreatmentPayment>();

    public virtual Voucher? Voucher { get; set; }
}
