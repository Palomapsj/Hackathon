namespace Care.Api.Business.Models
{
    public class ShortLinkModel
    {
        public string Url { get; set; }
        public Guid UserId { get; set; }
        public Guid HealthProgramId { get; set; }      
        public string? ShortUrl { get; set; }
        public string? ShortCode { get; set; }
    }
}
