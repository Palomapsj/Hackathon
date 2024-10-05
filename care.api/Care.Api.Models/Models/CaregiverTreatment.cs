namespace Care.Api.Models.Models
{
    public class CaregiverTreatment
    {
        public Guid TreatmentId { get; set; }
        public Guid CaregiverId { get; set; }
        public virtual Caregiver? Caregiver { get; set; }
        public virtual Treatment? Treatment { get; set; }
    }
}
