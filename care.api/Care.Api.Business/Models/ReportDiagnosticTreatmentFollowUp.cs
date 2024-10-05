namespace Care.Api.Business.Models
{
    public class ReportDiagnosticTreatmentFollowUp
    {
        public string? ProgramCode { get; set; }
        public string? Voucher { get; set; }
        public string? PatientName { get; set; }
        public bool? PatientStatus { get; set; }
        public DateTime? InitialDateSolicitation { get; set; }
        public DateTime? EndDateSolicitation { get; set; }
        public DateTime? InitialDateScheduling { get; set; }
        public DateTime? EndDateScheduling { get; set; }
        public Guid? PathologyId { get; set; }
        public Guid? ExamDefinitionId { get; set; }
        public string? ExamStatus { get; set; }
        public string? Cpf { get; set; }
    }
}
