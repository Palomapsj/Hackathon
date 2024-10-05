using Care.Api.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models.Models
{
    public partial class UrlShortener : BaseEntity, INotAudit
    {
        [NotMapped]
        public static int EntityTypeCode => 1311;
        [NotMapped]
        public static string EntityName => "UrlShortener";
        [NotMapped]
        public static Guid EntityId => Guid.Parse("FF93973E-95F6-4977-A8E0-87FFC17D30EB");

        public Guid? HealthProgramId { get; set; }
        public virtual HealthProgram? HealthProgram { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string? Url { get; set; }
        public string? ShortUrl { get; set; }
        public string? ShortCode { get; set; }
        public virtual StringMap? StatusCodeStringMap { get; set; }
    }
}
