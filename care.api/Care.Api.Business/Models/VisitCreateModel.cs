namespace Care.Api.Business.Models
{
    public class VisitCreateModel
    {
        public string? Name { get; set; }
        public DateTime? ScheduleDateStart { get; set; }
        public string? Description { get; set; }
        public EyePrescriptionModel? EyePrescription { get; set; }
        public string? ProgramCode { get; set; }
        public string? AccountId { get; set; }
        public string? TreatmentId { get; set; }
        public Guid? ServiceTypeId { get; set; }

        public string? DoctorLicenseNumber { get; set; }
        public string? DoctorLicenseState { get; set; }
        public string? DoctorName { get; set; }


        public AttachmentModel? MedicalPrescriptionAttach { get; set; }

    }
}
