using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

public partial class LogisticsSchedule : BaseEntity
{

    [NotMapped]
    public static int EntityTypeCode => 901;

    [NotMapped]
    public static string? EntityName => "LogisticsSchedule";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("F4E8DC63-E19C-4170-9FA5-6F7389E6AE65");

    public string? Name { get; set; }

    public Guid? LogisticsScheduleTypeStringMapId { get; set; }

    public Guid? ScheduleStatusStringMapId { get; set; }

    public DateTime? ScheduledStart { get; set; }

    public DateTime? ScheduledEnd { get; set; }

    public string? LogisticsPartnerCode { get; set; }

    public string? Cpfdoctor { get; set; }

    public string? Telephone { get; set; }

    public string? Cte { get; set; }

    public bool? SendRequestKit { get; set; }

    public int? Amount { get; set; }

    public Guid? DiseaseId { get; set; }

    public Guid? RequestDoctorId { get; set; }

    public Guid? DiagnosticId { get; set; }

    public Guid? LocalId { get; set; }

    public Guid? LogisticsPartnerId { get; set; }

    public Guid? ClientId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public string? AddressPostalCode { get; set; }

    public string? AddressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressComplement { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public Guid? ExamId { get; set; }

    public Guid? LogisticsStuffId { get; set; }

    public string? Action { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public bool? ConfirmWithdrawal { get; set; }

    public Guid? DeliveryLaboratoryId { get; set; }

    public string? ResponsibleForReceiving { get; set; }

    public string? Description { get; set; }

    public string? ResponsibleForCollecting { get; set; }

    public int? AmountUsed { get; set; }

    public int? AmountCanceled { get; set; }

    public int? CurrentBalance { get; set; }

    public DateTime? DateForReceiving { get; set; }

    public Guid? IncidentId { get; set; }

    public DateTime? DateForCollecting { get; set; }

    public Guid? KitTypeStringMapId { get; set; }

    public Guid? LocalTypeStringMapId { get; set; }

    public string? OtherPlace { get; set; }

    public Guid? LocalDeliveryWithdrawStringMapId { get; set; }

    public string? OtherLocalDeliveryWithdraw { get; set; }

    public string? ApprovedBy { get; set; }

    public string? RequestBy { get; set; }

    public string? Orientation { get; set; }

    public string? Reason { get; set; }

    public string? DeliveryPeriod { get; set; }

    public string? ResponsibleTelephoneWithdrawal { get; set; }

    public string? WithdrawalTime { get; set; }

    public string? Section { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public Guid? ConsultantId { get; set; }

    public Guid? ExamId1 { get; set; }

    public string? Cnpj { get; set; }

    public string? Temperature { get; set; }

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

    public string? ReasonsPendingCollection { get; set; }

    public DateTime? RecollectionDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime? DeliveryConfirmationDate { get; set; }

    public DateTime? DeliveryConfirmationPendingDate { get; set; }

    public string? ReasonsPendingDelivery { get; set; }

    public DateTime? CancelDate { get; set; }

    public string? ReasonsPendingAnalysis { get; set; }

    public DateTime? ResultDate { get; set; }

    public string? Result { get; set; }

    public DateTime? SchedulingPendencyDate { get; set; }

    public string? ReasonsSchedulingPendency { get; set; }

    public Guid? PreferredTimeStringMapId { get; set; }

    public Guid? AccountSettingsByProgramId { get; set; }

    public Guid? VoucherId { get; set; }

    public DateTime? ExpectedDeliveryDate { get; set; }

    public DateTime? PendingAnalysisDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? MainContact { get; set; }

    public string? ContactTelephoneExtension { get; set; }

    public DateTime? RecollectDate { get; set; }

    public bool? CustomBoolean1 { get; set; }
    public bool? CustomBoolean2 { get; set; }
    public bool? CustomBoolean3 { get; set; }
    public bool? CustomBoolean4 { get; set; }
    public bool? CustomBoolean5 { get; set; }
    public bool? CustomBoolean6 { get; set; }
    public bool? CustomBoolean7 { get; set; }
    public DateTime? CustomDateTime1 { get; set; }
    public DateTime? CustomDateTime2 { get; set; }
    public DateTime? CustomDateTime3 { get; set; }
    public DateTime? CustomDateTime4 { get; set; }
    public DateTime? CustomDateTime5 { get; set; }
    public DateTime? CustomDateTime6 { get; set; }
    public DateTime? CustomDateTime7 { get; set; }
    public string? CustomString1 { get; set; }
    public string? CustomString2 { get; set; }
    public string? CustomString3 { get; set; }
    public string? CustomString4 { get; set; }
    public string? CustomString5 { get; set; }
    public string? CustomString6 { get; set; }
    public string? CustomString7 { get; set; }

    public Guid? Custom1StringMapId { get; set; }

    public Guid? Custom2StringMapId { get; set; }

    public Guid? Custom3StringMapId { get; set; }

    public Guid? Custom4StringMapId { get; set; }

    public Guid? Custom5StringMapId { get; set; }

    public Guid? Custom6StringMapId { get; set; }

    public Guid? Custom7StringMapId { get; set; }

    public StringMap? Custom1StringMap { get; set; }

    public StringMap? Custom2StringMap { get; set; }

    public StringMap? Custom3StringMap { get; set; }

    public StringMap? Custom4StringMap { get; set; }

    public StringMap? Custom5StringMap { get; set; }

    public StringMap? Custom6StringMap { get; set; }

    public StringMap? Custom7StringMap { get; set; }

    public virtual AccountSettingsByProgram? AccountSettingsByProgram { get; set; }

    public virtual StringMap? ChosenExamTypeStringMap { get; set; }

    public virtual Account? Client { get; set; }

    public virtual User? Consultant { get; set; }

    public virtual Account? DeliveryLaboratory { get; set; }

    public virtual Diagnostic? Diagnostic { get; set; }

    public virtual Disease? Disease { get; set; }

    public virtual ExamDefinition? ExamDefinition { get; set; }

    public virtual Exam? ExamId1Navigation { get; set; }

    public virtual ICollection<Exam> ExamLogisticsScheduleId1Navigations { get; } = new List<Exam>();

    public virtual ICollection<Exam> ExamLogisticsSchedules { get; } = new List<Exam>();

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual Incident? Incident { get; set; }

    public virtual ICollection<IncidentItem> IncidentItems { get; } = new List<IncidentItem>();

    public virtual StringMap? IntegrationStatusStringMap { get; set; }

    public virtual StringMap? KitTypeStringMap { get; set; }

    public virtual Account? Local { get; set; }

    public virtual StringMap? LocalDeliveryWithdrawStringMap { get; set; }

    public virtual StringMap? LocalTypeStringMap { get; set; }

    public virtual Account? LogisticsPartner { get; set; }

    public virtual ICollection<LogisticsScheduleItem> LogisticsScheduleItems { get; } = new List<LogisticsScheduleItem>();

    public virtual StringMap? LogisticsScheduleTypeStringMap { get; set; }

    public virtual LogisticsStuff? LogisticsStuff { get; set; }

    public virtual ICollection<LogisticsStuff> LogisticsStuffs { get; } = new List<LogisticsStuff>();

    public virtual StringMap? PreferredTimeStringMap { get; set; }

    public virtual Doctor? RequestDoctor { get; set; }

    public virtual StringMap? ScheduleStatusStringMap { get; set; }

    public virtual ICollection<SchedulingHistory> SchedulingHistories { get; } = new List<SchedulingHistory>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual StringMap? StorageTubeTypeStringMap { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
