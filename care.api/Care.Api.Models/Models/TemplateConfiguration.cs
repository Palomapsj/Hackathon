using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models.Models
{
    public class TemplateConfiguration : BaseEntity
    {
        [NotMapped]
        public static int EntityTypeCode => 1309;
        [NotMapped]
        public static string EntityName => "TemplateConfiguration";
        [NotMapped]
        public static Guid EntityId => Guid.Parse("B9AD9A98-0871-4D05-B3A9-3FB09AA9C0EE");
        public string? Name { get; set; }
        public string? Description { get; set; }        
        public Guid? HealthProgramId { get; set; }        
        public virtual HealthProgram? HealthProgram { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
        public Guid? TemplateEmailId { get; set; }
        public virtual Template? TemplateEmail { get; set; }
        public Guid? TemplateSmsId { get; set; }
        public virtual Template? TemplateSms { get; set; }
        public string? ParametersLinkSMS { get; set; }
        public string? ParametersLinkEmail { get; set; }
        public DateTime? ScheduledSend { get; set; }
        public virtual StringMap? StatusCodeStringMap { get; set; }
    }
}
