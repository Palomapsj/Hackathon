using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ExamBkp190422
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? ExamDefinitionId { get; set; }

    public Guid? VoucherId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? DiagnosticId { get; set; }

    public Guid? LocalId { get; set; }

    public Guid? DoctorId { get; set; }

    public DateTime? ScheduleDate { get; set; }

    public DateTime? RealizationDate { get; set; }

    public bool? NeedCaptation { get; set; }

    public string Description { get; set; }

    public Guid? ExamStatusStringMapId { get; set; }

    public Guid? ScheduleSourceStringMapId { get; set; }

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

    public bool? VoucherByEmail { get; set; }

    public bool? ReportSent { get; set; }

    public DateTime? ExpectedDateToSend { get; set; }

    public string Eticket { get; set; }

    public DateTime? DueEticket { get; set; }

    public Guid? WithdrawalPreferenceStringMapId { get; set; }

    public bool? DoctorHasFilterPaper { get; set; }

    public bool? ConsentTermReceived { get; set; }

    public bool? ConsentTermValidated { get; set; }

    public DateTime? ConsentTermReceivedDate { get; set; }

    public DateTime? ConsentTermValidatedDate { get; set; }

    public string ConsentTermValidatedBy { get; set; }

    public Guid? LogisticsStuffId { get; set; }

    public bool? HaveDateReturnDoctor { get; set; }

    public DateTime? DateReturnDoctor { get; set; }

    public int NumberofTubes { get; set; }

    public DateTime? DateIssueReport { get; set; }

    public DateTime? DateOfApproval { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public string Reason { get; set; }

    public Guid? LogisticsScheduleId { get; set; }

    public DateTime? WithdrawalDate { get; set; }

    public Guid? LogisticsScheduleId1 { get; set; }

    public Guid? ReschedulingReasonStringMapId { get; set; }

    public bool? VoucherReceived { get; set; }

    public bool? VoucherValidated { get; set; }

    public DateTime? VoucherValidatedDate { get; set; }

    public string VoucherValidatedBy { get; set; }

    public Guid? LogisticsScheduleItemId { get; set; }

    public bool? HasDiagnosis { get; set; }

    public decimal? Distance { get; set; }

    public DateTime? MedicationUseDate { get; set; }

    public bool? ConsentEligibilityCriteria { get; set; }

    public bool? ConsentResponsibility { get; set; }

    public bool? ConsentSample { get; set; }

    public bool? ConsentCloseDiagnostic { get; set; }

    public bool? ConsentUseImatinibNilotinib { get; set; }

    public Guid? ResultStringMapId { get; set; }

    public Guid? OwnershipLevelStringMapId { get; set; }
}
