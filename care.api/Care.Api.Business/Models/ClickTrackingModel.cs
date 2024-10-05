namespace Care.Api.Business.Models
{
    public class ClickTrackingModel
    {
        public string DestinationUrl { get; set; }
        public Guid HealthProgramId { get; set; }
        public Guid? EmailId { get; set; }
        public Guid? TemplateEmailId { get; set; }
        public Guid? SmsId { get; set; }
        public Guid? TemplateSmsId { get; set; }
        public Guid UserId { get; set; }
    }
}
