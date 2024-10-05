using Care.Api.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models.Models
{
    public partial class ClickTracking : BaseEntity, INotAudit
    {
        [NotMapped]
        public static int EntityTypeCode => 1310;
        [NotMapped]
        public static string EntityName => "ClickTracking";
        [NotMapped]
        public static Guid EntityId => Guid.Parse("3049B95A-B67C-41E9-B94D-FC2999827DE7");

        public Guid? HealthProgramId { get; set; }
        public virtual HealthProgram? HealthProgram { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
        public string? DestinationUrl { get; set; }
        public DateTime ClickDate { get; set; }

        public Guid? EmailId { get; set; }
        public virtual Email? Email { get; set; }
        public Guid? TemplateEmailId { get; set; }
        public virtual Template? TemplateEmail { get; set; }

        public Guid? SmsId { get; set; }
        public virtual Sms? Sms { get; set; }
        public Guid? TemplateSmsId { get; set; }
        public virtual Template? TemplateSms { get; set; }

        public virtual StringMap? StatusCodeStringMap { get; set; }
    }
}
