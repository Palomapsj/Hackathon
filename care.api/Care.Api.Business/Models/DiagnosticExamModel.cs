using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class DiagnosticExamModel
    {
        public Guid? Id { get; set; }
        public Guid? DoctorId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? NumberProtocol { get; set; }
        public string? NamePatient { get; set; }
        public string? DiseaseName { get; set; }
        public Guid? DiseaseId { get; set; }

        public string? NameDoctor { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseState { get; set; }


        public string? CPF { get; set; }
        public string? PatientPhase { get; set; }
        public string? PatientStatus { get; set; }
        public Guid? PatientStatusId { get; set; }
        public string? PatientEmail { get; set; }
        public DateTime? PatientBirthDate { get; set; }
        public string? PatientMobilephone { get; set; }
        public string? PatientUserPassword { get; set; }
        public string? ExamDefinition { get; set; }
        public string? Voucher { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public string? ExamStatus { get; set; }
        public Guid? ExamStatusId { get; set; }
        public string? ReasonPendingCanceled { get; set; }
        public string? FileReport { get; set; }
        public string? Result { get; set; }
        public Guid? ResultId { get; set; }

        public bool? ExamAudit { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressName { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressDistrict { get; set; }
        public string? StatusDetail { get; set; }
        public string? StatusPhase { get; set; }
        public bool? IsOnboardingAnswered { get; set; }
    }
}

