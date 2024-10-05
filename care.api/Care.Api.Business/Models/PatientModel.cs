namespace Care.Api.Business.Models
{
    public class PatientModel : CommonModel
    {
        public string? FullName { get; set; }
        public Guid? HealthProgramId { get; set; }
        public List<PhoneModel>? Phones { get; set; }
        public List<EmailModel>? Emails { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
