namespace Care.Api.Business.Models.Message.Request
{
    public class PatientRequest
    {
        public Guid? Id { get; set; }
        public string? Name  { get; set; }
        public string? Cpf { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<PhoneRequest>? Phones { get; set; }
        public List<EmailRequest>? Emails { get; set; }
        public MedicationRequest? Medication { get; set; }
        public PathologyRequest? Pathology { get; set; }
        public DoctorRequest? Doctor { get; set; }
        public HealthProgramRequest? HealthProgram { get; set; }
        public List<ExamDefinitionRequest>? ExamsDefinition { get; set; }
        public List<AttachmentModel>? MedicalPrescriptionsAttach { get; set; }

    }
}
