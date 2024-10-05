namespace Care.Api.Business.Models
{
    public class UnsubscribeModel
    {
        public Guid? TreatmentId { get; set; } 
        public string EmailUnsubscribed { get; set; }
        public string ProgramCode { get; set; }
    }
}