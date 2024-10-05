namespace Care.Api.Business.Models
{
    public class ResourceWorkSettingCreateModel
    {
        public string? PeriodMorning { get; set; }
        public string? PeriodAfternoon { get; set; }
        public string? PeriodNocturnal { get; set; }
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public int? ServiceDuration { get; set; }
        public DateTime? ValityStart { get; set; }
        public DateTime? ValityEnd { get; set; }

        public string? ProgramCode { get; set; }
        public Guid? AccountId { get; set; }
    }
}
