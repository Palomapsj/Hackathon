using Care.Api.Business.Enums;

namespace Care.Api.Business.Models
{
    public class WhatsAppScheduleModel
    {
        public int ScheduleType { get; set; }
        public string ScheduleTypeDescription { get; set; }
        public int DayOfWeek { get; set; }
        public string DayOfWeekDescription { get; set; }
        public int Period { get; set; }
        public string PeriodDescription { get; set; }
        public bool MedicalRequest { get; set; }
        public AddressModel Address { get; set; }
        public TreatmentResultModel Treatment { get; set; }
        public WhatsAppAttachmentModel MedicalRequestFile { get; set; }
        public string ProgramCode { get; set; }
    }
}
