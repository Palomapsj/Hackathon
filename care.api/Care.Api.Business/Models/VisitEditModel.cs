namespace Care.Api.Business.Models
{
    public class VisitEditModel
    {
        public string? Name { get; set; }
        public DateTime? ScheduleDateStart { get; set; }
        public string? Description { get; set; }
        public EyePrescriptionModel? EyePrescription { get; set; }

        public string? ProgramCode { get; set; }
        public string? AccountId { get; set; }
    }
}
