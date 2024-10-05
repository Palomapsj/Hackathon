using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class LogisticsScheduleBkp01072022
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

    public DateTime? ReportDate { get; set; }

    public DateTime? ConfirmWithdrawalDate { get; set; }

    public DateTime? DateReceivingBlock { get; set; }

    public DateTime? ReportReleaseDate { get; set; }

    public bool? RetesteReleased { get; set; }

    public DateTime? ConsentTermRecivedDate { get; set; }

    public Guid? ExamDefinitionId { get; set; }

    public Guid? StorageTubeTypeStringMapId { get; set; }

    public bool? ShortSampleSupplyForTwoExams { get; set; }

    public Guid? ChosenExamTypeStringMapId { get; set; }

    public bool? FgfrthroughNgs { get; set; }

    public bool? AuthorizedByClient { get; set; }

    public bool? EnoughSampleSupplyForOneExam { get; set; }

    public DateTime? PendingCollectionDate { get; set; }

    public string ReasonsPendingCollection { get; set; }

    public DateTime? RecollectionDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime? DeliveryConfirmationDate { get; set; }

    public DateTime? DeliveryConfirmationPendingDate { get; set; }

    public string ReasonsPendingDelivery { get; set; }

    public DateTime? CancelDate { get; set; }

    public string ReasonsPendingAnalysis { get; set; }

    public DateTime? ResultDate { get; set; }

    public string Result { get; set; }

    public DateTime? SchedulingPendencyDate { get; set; }

    public string ReasonsSchedulingPendency { get; set; }

    public Guid? PreferredTimeStringMapId { get; set; }

    public Guid? AccountSettingsByProgramId { get; set; }

    public Guid? VoucherId { get; set; }

    public DateTime? ExpectedDeliveryDate { get; set; }

    public DateTime? PendingAnalysisDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string MainContact { get; set; }

    public string ContactTelephoneExtension { get; set; }

    public DateTime? RecollectDate { get; set; }
}
