namespace Care.Api.Business.Models
{
    public class SendEmailModel
    {
        public Guid? OriginEntityId { get; set; }
        public string? OriginEmailAddress { get; set; }
        public string? ProgramCode { get; set; }
        public string? TemplateName { get; set; }
        public Dictionary<string, string> BodyPlaceHolders { get; set; }
    }
}
