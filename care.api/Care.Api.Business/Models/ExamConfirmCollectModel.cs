namespace Care.Api.Business.Models;

public class ExamConfirmCollectModel
{
    public Guid Id { get; set; }
    public DateTime CollectionDate { get; set; }
    public DateTime ReceiptDate { get; set; }
    public Guid TermStatus { get; set; }
    public Guid? TermFailedReason { get; set; }
    public Guid AnatomoReportState { get; set; }
    public Guid? AnatomoFailedReason { get; set; }
    public Guid MedicalRequestStatus { get; set; }
    public Guid? MedicalRequestFailedReason { get; set; }
    public bool ConfirmReceipt { get; set; }
    public AttachCreateModel? TermConsentAttach { get; set; }
    public AttachCreateModel? MedicalRequestAttach { get; set; }
    public AttachCreateModel? ReportAnatomoAttach { get; set; }
}
