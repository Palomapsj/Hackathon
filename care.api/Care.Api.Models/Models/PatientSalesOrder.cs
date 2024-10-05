using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class PatientSalesOrder
{
    public Guid Id { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? PatientId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get; set; }

    public string Cpfcnpj { get; set; }

    public string Telephone1 { get; set; }

    public string Telephone2 { get; set; }

    public string Mobilephone1 { get; set; }

    public bool? IsNewPatient { get; set; }

    public bool? HasUsedProductBefore { get; set; }

    public Guid? PatientSourceStringMapId { get; set; }

    public Guid? SolicitorStringMapId { get; set; }

    public string AddressPostalCode { get; set; }

    public string AddressName { get; set; }

    public string AddressNumber { get; set; }

    public string AddressComplement { get; set; }

    public string AddressDistrict { get; set; }

    public string AddressCity { get; set; }

    public string AddressState { get; set; }

    public bool? HasPrescription { get; set; }

    public string DoctorFullName { get; set; }

    public string DoctorLicenseNumber { get; set; }

    public string DoctorLicenseState { get; set; }

    public string MedicalSpecialty { get; set; }

    public Guid? DoctorId { get; set; }

    public bool? HasHealthcareProvider { get; set; }

    public Guid? HealthcareProviderId { get; set; }

    public string DiagnosticDescription { get; set; }

    public DateTime? BillingDate { get; set; }

    public DateTime? PurchaseAskDate { get; set; }

    public bool? HasStoreSent { get; set; }

    public DateTime? StoreSentDate { get; set; }

    public bool? HasReturned { get; set; }

    public bool? IsPurchaseDone { get; set; }

    public bool? HasBoughtOnFirstContact { get; set; }

    public string InvoiceNumber { get; set; }

    public string FormOfPayment { get; set; }

    public string PaymentTerms { get; set; }

    public Guid? MedicamentId { get; set; }

    public Guid? StrengthMedicamentId { get; set; }

    public int? Amount { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool? HasUsedProgramClinic { get; set; }

    public DateTime? ActualDeliveryDate { get; set; }

    public string ReasonOrderFailed { get; set; }

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

    public string Name { get; set; }

    public string MedicalInsurance { get; set; }

    public virtual Doctor Doctor { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual Account HealthcareProvider { get; set; }

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual Medicament Medicament { get; set; }

    public virtual Patient Patient { get; set; }

    public virtual StringMap PatientSourceStringMap { get; set; }

    public virtual StringMap SolicitorStringMap { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }

    public virtual StrengthMedicament StrengthMedicament { get; set; }
}
