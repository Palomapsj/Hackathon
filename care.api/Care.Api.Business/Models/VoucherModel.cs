namespace Care.Api.Business.Models
{
    public class VoucherModel
    {
        public Guid? Id { get; set; }
        public Guid? VoucherConfigurationId { get; set; }
        public Guid? StatusStringMapId { get; set; }
        public Guid? SourceStringMapId { get; set; }
        public Guid? TreatmentId { get; set; }
        public Guid? DiagnosticId { get; set; }
        public Guid? HealthProgramId { get; set; }
        public Guid? ExamDefinitionId { get; set; }
        public Guid? MedicamentId { get; set; }
        public string? Name { get; set; }
        public string? DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public int? DeadlineInDays { get; set; }
        public string? Note { get; set; }
        public string? ProgramCode { get; set; }
        public string? VoucherConfigurationCode { get; set; }
        public bool? ExamOrInfusion { get; set; }
        public bool? VoucherIsValid { get; set; }
        public string? DoctorLicenseNumber { get; set; }
        public string? DoctorLicenseState { get; set; }
        public string? DoctorName { get; set; }
        public Guid? DoctorId { get; set; }
        public string? Description { get; set; }
        public AttachmentModel? MedicalRequest { get; set; }
        public AttachmentModel? TransportDeclaration { get; set; }
    }
}
