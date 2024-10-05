namespace Care.Api.Models.Models
{
    public class ExamReport
    {
        public DateTime? SolicitationDate { get; set; }
        public string? PatientName { get; set; }
        public string? Cpf { get; set; }
        public bool? PatientState { get; set; }
        public string? DiagnosticHypothesis { get; set; }
        public string? Voucher { get; set; }
        public string? Exam { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string? ExamStatus { get; set; }
        public string? ExamReason { get; set; }
        public DateTime? RealizationDate { get; set; }
    }
}
