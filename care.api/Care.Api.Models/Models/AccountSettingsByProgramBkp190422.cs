using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AccountSettingsByProgramBkp190422
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? MedicamentId { get; set; }

    public bool? HomeCare { get; set; }

    public Guid? PatientTypeStringMapId { get; set; }

    public bool? MakesInfusion { get; set; }

    public bool? MakesIt { get; set; }

    public bool? MakesOt { get; set; }

    public bool? MakesInfusionSubsidy { get; set; }

    public bool? SpecialtyDerm { get; set; }

    public bool? SpecialtyGastro { get; set; }

    public bool? SpecialtyRheumato { get; set; }

    public int CodeClinicIntegra { get; set; }

    public Guid? ExamDefinitionId { get; set; }

    public string Reason { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? AccountStatusStringMapId { get; set; }

    public Guid? ExamTypeStringMapId { get; set; }

    public string OtherExam { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public decimal? Price { get; set; }

    public string MainContact { get; set; }

    public string Area { get; set; }

    public string RequestId { get; set; }

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

    public string NickName { get; set; }

    public int? MounthlyVouchers { get; set; }

    public int? AnnualVouchers { get; set; }

    public string Telephone1 { get; set; }

    public string Cnpj { get; set; }

    public string AddressPostalCode { get; set; }

    public string AddressName { get; set; }

    public string AddressNumber { get; set; }

    public string AddressComplement { get; set; }

    public string AddressDistrict { get; set; }

    public string AddressCity { get; set; }

    public string AddressState { get; set; }

    public string AddressCountry { get; set; }

    public Guid? DoctorByProgramId { get; set; }

    public Guid? SystemUserId { get; set; }

    public string EmailAddress { get; set; }

    public string AnalysisTime { get; set; }

    public bool? HomeCollect { get; set; }

    public int? UntilKm { get; set; }

    public decimal? UntilKmvalue { get; set; }

    public int? BetweenKm { get; set; }

    public int? AndKm { get; set; }

    public decimal? BetweenKmvalue { get; set; }

    public int? OutsideCoverageAreaAboveKm { get; set; }
}
