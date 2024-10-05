using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpDeletar
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? LogisticsScheduleTypeStringMapId { get; set; }

    public Guid? ScheduleStatusStringMapId { get; set; }

    public DateTime? ScheduledStart { get; set; }

    public DateTime? ScheduledEnd { get; set; }

    public string LogisticsPartnerCode { get; set; }

    public string Cpfdoctor { get; set; }

    public string Telephone { get; set; }

    public string Cte { get; set; }

    public bool? SendRequestKit { get; set; }

    public int? Amount { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? RequestDoctorId { get; set; }

    public Guid? DiagnosticId { get; set; }

    public Guid? LocalId { get; set; }

    public Guid? LogisticsPartnerId { get; set; }

    public Guid? ClientId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public string AddressPostalCode { get; set; }

    public string AddressName { get; set; }

    public string AddressNumber { get; set; }

    public string AddressComplement { get; set; }

    public string AddressDistrict { get; set; }

    public string AddressCity { get; set; }

    public string AddressState { get; set; }

    public string AddressCountry { get; set; }

    public Guid? ExamId { get; set; }

    public Guid? LogisticsStuffId { get; set; }

    public string Action { get; set; }

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

    public bool? ConfirmWithdrawal { get; set; }

    public Guid? DeliveryLaboratoryId { get; set; }

    public string ResponsibleForReceiving { get; set; }

    public string Description { get; set; }

    public string ResponsibleForCollecting { get; set; }

    public int? AmountUsed { get; set; }

    public int? AmountCanceled { get; set; }

    public int? CurrentBalance { get; set; }

    public DateTime? DateForReceiving { get; set; }

    public Guid? IncidentId { get; set; }

    public DateTime? DateForCollecting { get; set; }

    public Guid? KitTypeStringMapId { get; set; }

    public Guid? LocalTypeStringMapId { get; set; }

    public string OtherPlace { get; set; }

    public Guid? LocalDeliveryWithdrawStringMapId { get; set; }

    public string OtherLocalDeliveryWithdraw { get; set; }

    public string ApprovedBy { get; set; }

    public string RequestBy { get; set; }

    public string Orientation { get; set; }

    public string Reason { get; set; }

    public string DeliveryPeriod { get; set; }

    public string ResponsibleTelephoneWithdrawal { get; set; }

    public string WithdrawalTime { get; set; }

    public string Section { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public Guid? ConsultantId { get; set; }

    public Guid? ExamId1 { get; set; }

    public string Cnpj { get; set; }

    public string Temperature { get; set; }

    public Guid? IntegrationStatusStringMapId { get; set; }

    public bool? IsLegacy { get; set; }

    public Guid? LegacyId { get; set; }
}
