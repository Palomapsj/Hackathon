namespace Care.Api.Business.Models
{
    public class ExamPendingModel
    {
        public Guid Id { get; set; }
        public Guid DiagnosticId { get; set; }
        public string NumberProtocol { get; set; }
        public string Voucher { get; set; }

        public List<AttachmentModel> Attachments { get; set; }
    }
}
