using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class TreatmentFilterModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCpf { get; set; }
        public Guid? ExamStatus { get; set; }
        public Guid? PatientStatus { get; set; }
        public Guid? ServiceType { get; set; }
        public Guid? TreatmentId { get; set; }
        public string? StatusHistoryName { get; set; }
        public Guid? MedicamentId { get; set; }
        public Guid? TypeProfessional { get; set; }
        public Guid? Doctor { get; set; }
        public string? IdentificationCode { get; set; }
    }
}