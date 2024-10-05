using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class TreatmentModel
    {
        public Guid? Id { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? MedicamentId { get; set; }
        public Guid? DiseaseId { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? CPF { get; set; }
        public string? Mobilephone { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? NameCaregiver { get; set; }
        public DateTime? BirthdateCaregiver { get; set; }
        public string? CPFCaregiver { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressDistrict { get; set; }
        public Guid? GenderId { get; set; }
        public bool? ProgramRegulation { get; set; }
        public bool? PrivacyPolicy { get; set; }
        public string? OperadoraSaude { get; set; }
        public string? ProgramCode { get; set; }
        public bool ? ConsentToSendDataToDoctor { get; set; }

        public Guid? PreferredTimeId { get; set; }
        public Guid? PreferredContactId { get; set; }

        #region Custom
        public DateTime? CustomDateTime1 { get; set; }
        #endregion

        public AttachmentModel? MedicalPrescriptionAttach { get; set; }
    }
}