namespace Care.Api.Business.Models
{
    public class CalendarAvailableItem
    {
        public Guid? Id { get; set; }
        public string? Day { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
        public string? PeriodMorning { get; set; }
        public string? PeriodAfternoon { get; set; }
        public string? PeriodNocturnal { get; set; }
        public string? NotAvailableHours { get; set; }
    }
}
