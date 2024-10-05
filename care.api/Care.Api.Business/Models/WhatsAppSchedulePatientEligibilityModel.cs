namespace Care.Api.Business.Models
{
    public class WhatsAppSchedulePatientEligibilityModel
    {
        public bool IsPatientElegible { get; set; }
        public TreatmentResultModel? Treatment { get; set; }
        public string MessageNotElegible { get; set; }
    }
}
