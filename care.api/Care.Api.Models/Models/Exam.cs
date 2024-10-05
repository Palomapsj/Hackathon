using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Care.Api.Models;

public partial class Exam : BaseEntity
{

    public static int EntityTypeCode => 805;
    public static string EntityName => "Exam";


    public string? Name { get; set; }

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

    public string? Description { get; set; }

    public Guid? ExamStatusStringMapId { get; set; }

    public Guid? ScheduleSourceStringMapId { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    //public string? EntityOriginalValues { get; set; }

    public bool? VoucherByEmail { get; set; }

    public bool? ReportSent { get; set; }

    public DateTime? ExpectedDateToSend { get; set; }

    public string? Eticket { get; set; }

    public DateTime? DueEticket { get; set; }

    public Guid? WithdrawalPreferenceStringMapId { get; set; }

    public bool? DoctorHasFilterPaper { get; set; }

    public bool? ConsentTermReceived { get; set; }

    public bool? ConsentTermValidated { get; set; }

    public DateTime? ConsentTermReceivedDate { get; set; }

    public DateTime? ConsentTermValidatedDate { get; set; }

    public string? ConsentTermValidatedBy { get; set; }

    public Guid? LogisticsStuffId { get; set; }

    public bool? HaveDateReturnDoctor { get; set; }

    public DateTime? DateReturnDoctor { get; set; }

    public int NumberofTubes { get; set; }

    public DateTime? DateIssueReport { get; set; }

    public DateTime? DateOfApproval { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public string? Reason { get; set; }

    public Guid? LogisticsScheduleId { get; set; }

    public DateTime? WithdrawalDate { get; set; }

    public Guid? LogisticsScheduleId1 { get; set; }

    public Guid? ReschedulingReasonStringMapId { get; set; }

    public bool? VoucherReceived { get; set; }

    public bool? VoucherValidated { get; set; }

    public DateTime? VoucherValidatedDate { get; set; }

    public string? VoucherValidatedBy { get; set; }

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
    public bool? CustomBoolean { get; set; }
    public bool? CustomBoolean1 { get; set; }
    public bool? CustomBoolean2 { get; set; }

    public bool? CustomBoolean3 { get; set; }

    public bool? CustomBoolean4 { get; set; }
    public bool? CustomBoolean5 { get; set; }
    public string? CustomString { get; set; }
    public string? CustomString1 { get; set; }

    public string? CustomString2 { get; set; }

    public string? CustomString3 { get; set; }

    public string? CustomString4 { get; set; }

    public string? CustomString5 { get; set; }

    [NotMapped]
    public string? VoucherName { get; set; }
    [NotMapped]
    public Guid PatientId { get; set; }

    [NotMapped]
    public string? LocalEmailAddress { get; set; }


    public virtual Diagnostic? Diagnostic { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ExamDefinition? ExamDefinition { get; set; }

    public virtual StringMap? ExamStatusStringMap { get; set; }

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual Account? Local { get; set; }

    public virtual LogisticsSchedule? LogisticsSchedule { get; set; }

    public virtual LogisticsSchedule? LogisticsScheduleId1Navigation { get; set; }

    public virtual LogisticsScheduleItem? LogisticsScheduleItem { get; set; }

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual LogisticsStuff? LogisticsStuff { get; set; }

    public virtual StringMap? OwnershipLevelStringMap { get; set; }

    public virtual StringMap? ReschedulingReasonStringMap { get; set; }

    public virtual StringMap? ResultStringMap { get; set; }

    public virtual StringMap? ScheduleSourceStringMap { get; set; }

    public virtual ICollection<SchedulingHistory> SchedulingHistories { get; } = new List<SchedulingHistory>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual Treatment? Treatment { get; set; }

    public virtual ICollection<TreatmentPayment> TreatmentPayments { get; } = new List<TreatmentPayment>();

    public virtual Voucher? Voucher { get; set; }

    public virtual StringMap? WithdrawalPreferenceStringMap { get; set; }

    public virtual ICollection<ExamDefinition> ExamDefinitions { get; } = new List<ExamDefinition>();

}
