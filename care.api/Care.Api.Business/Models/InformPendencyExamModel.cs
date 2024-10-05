namespace Care.Api.Business.Models
{
    public class InformPendencyExamModel
    {
        public Guid Id { get; set; }

        public Guid PendencyId { get; set; }
        public Guid? PendencyDetailId { get; set; }
        public string? ProgramCode { get; set; }
    }
}
