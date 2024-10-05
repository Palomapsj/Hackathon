namespace Care.Api.Business.Models
{
    public class TemplateConfigurationModel
    {   
        public Guid RegardingEntityId { get; set; }
        public Guid HealthProgramId { get; set; }
        public Guid UserId { get; set; }
        public string TemplateConfigurationName { get; set; }
        public string EmailTo { get; set; }
        public string SmsNumber { get; set; }
        public string EntityName { get; set; }
        public Dictionary<string, string>? BodyReplace { get; set; }
    }
}
