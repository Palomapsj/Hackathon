namespace Care.Api.Business.Models
{
    public class ExamPendingResolveModel
    {
        public Guid Id { get; set; }

        public List<AttachmentModel> Attachments { get; set; }
    }
}
