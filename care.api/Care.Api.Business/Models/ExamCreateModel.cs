using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class ExamCreateModel
    {
        public Guid? DoctorId { get; set; }
        public Guid? VoucherId { get; set; }
        public string? VoucherName { get; set; }
        public Guid? ExamDefinition { get; set; }
        public Guid? Voucher { get; set; }
        public Guid? SourceConsent { get; set; }
        public Guid? Disease { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? CPF { get; set; }
        public string? Mobilephone { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? NameCaregiver { get; set; }
        public DateTime? BirthdateCaregiver { get; set; }
        public string? CPFCaregiver { get; set; }
        public bool? HasOPS { get; set; }
        public Guid? LaboratoryAnalysis { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressName { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressDistrict { get; set; }
        public string? ResponsibleName { get; set; }
        public string? Contact { get; set; }
        public string? Sector { get; set; }
        public bool? SaveAddress { get; set; }
        public Guid? GenderId { get; set; }
        public bool? ProgramRegulation { get; set; }
        public bool? PrivacyPolicy { get; set; }
        public bool? HadATransplant { get; set; }
        public bool? IsTransplanted { get; set; }
        public string? ProgramCode { get; set; }
      

        public User? User { get; set; }
        public string? ConfirmedPassword { get; set; }

        public AttachmentModel? TermConsentAttach { get; set; }
        public AttachmentModel? MedicalRequestAttach { get; set; }
        public AttachmentModel? ReportAnatomoAttach { get; set; }

    }
}