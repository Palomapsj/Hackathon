using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class DiagnosticFilterModel
    {

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public string? NumberProtocol { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCPF { get; set; }
        public string? PatientEmail { get; set; }

        public Guid? PatientStatus { get; set; }
        public Guid? ExamStatus { get; set; }
        public Guid? ResultStatus { get; set; }
        public Guid? Doctor { get; set; }


        public string? TypeDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? StatusHistoryName { get; set; }
        public Guid? ServiceType { get; set; }
        public Guid? DiseaseId { get; set; }
        public Guid? DiagnosticId { get; set; }
    }

    public class DiagnosticServiceTypeResultModel
    {
        public string? ServiceTypeName { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? RealizationDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? StatusHistoryName { get; set; }
        public string? ReasonNotDone { get; set; }
        public string? ProcedureTypeName { get; set; }
        public string? ClinicName { get; set; }
        public string? PatientName { get; set; }
        public string? Voucher { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? ServiceTypeId { get; set; }
        public Guid? DiagnosticId { get; set; }
        public Guid? ExamId { get; set; }
        public Guid? InfusionId { get; set; }
        public Guid? LogisticId { get; set; }
        public Guid? VisitId { get; set; }
        public Guid? AnnotationId { get; set; }
        public string? ContentType { get; set; }
    }
}
