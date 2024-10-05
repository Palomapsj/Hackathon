using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class ExamResultModel
    {
        public Guid Id { get; set; }
        public Guid ResultId { get; set; }

        public DateTime DateAnalisys { get; set; }

        public AttachmentModel? FileExamResultAttach { get; set; }
        public string? ProgramCode { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DevolutionDate { get; set; }
        public string? NamePatient { get; set; }
        public string? CpfPatient { get; set; }
        public string? ExamStatus { get; set; }
        public Guid? ExamStatusId { get; set; }
        public Guid? ExamDefinitionId { get; set; }
        public string? PatientStatus { get; set; }
        public string? PatientName { get; set; }
        public Guid? ServiceType { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorLicense { get; set; }
        public string? DoctorCpf { get; set; }
        public string? ExamDefinition { get; set; }
        public string? Voucher { get; set; }
        public string? LocalName { get; set; }
        public string? LocalAddress { get; set; }
        public DateTime? PatientBirthDate { get; set; }
        public string? Gender { get; set; }
        public List<string>? PendencyReason { get; set; }
        public Guid? TransportDeclarationId { get; set; }
        public Guid? ConsentFormId { get; set; }
        public Guid? MedicalReportId { get; set; }

        public List<SchedulingHistoryResultModel>? SchedulingHistories { get; set; }

        public class DiagnosticExamResultModel
        {
            internal string LicenseNumber;
            internal string? Cpf;
            internal string PatientStatus;
            internal string? ExamStatus;
            internal string? ExamDefinition;

            public Guid? ExamId { get; set; }
            public string? NamePatient { get; set; }
            public Guid? ExamDefinitionId { get; set; }
            public StringMap DiagnosticStatusDetailStringMap { get; set; }
            public DateTime? CreatedOn { get; set; }
            public string? PatientName { get; set; }
            public string? CrmUf { get; set; }

            public string? PatientCpf { get; set; }
            public string? DiagnosticStatusName { get; set; }
            public DateTime? ScheduledDate { get; set; }
            public DateTime? RealizationDate { get; set; }
            public string? ProcedureName { get; internal set; }
            public string? Voucher { get; internal set; }
            public string? DoctorName { get; internal set; }
            public string? LicenseName { get; internal set; }
            public string? ProcedureStatusName { get; internal set; }
            public string? ClinicName { get; internal set; }
            public string? ReasonNotDone { get; internal set; }
            public string? PatientPhase { get; internal set; }
            public string? NameDoctor { get; internal set; }
        }
        public class ExamAnalysisModel
        {
            public Guid Id { get; set; }
            public string? Reasonpending { get; set; }
            public DateTime? Date { get; set; }
            public string? ProgramCode { get; set; }
            public AttachmentModel? ExamReportAttach { get; set; }

        }
    }
}
