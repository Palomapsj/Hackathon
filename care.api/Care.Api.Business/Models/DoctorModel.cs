using Care.Api.Models;
namespace Care.Api.Business.Models
{
    public class DoctorModel : CommonModel
    {
        public Guid? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseState { get; set; }
        public string? Telephone1 { get; set; }
        public string? EmailAddress { get; set; }
        public string? EmailAddress1 { get; set; }
        public string? MedicalSpecialty { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressName { get; set; }
        public string? HealthProgramCode { get; set; }
        public Guid? SystemUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? StateCode { get; set; }
        public Guid? DoctorByProgramId { get; set; }
        public List<string>? ProgramsCode { get; set; }
        public string? Password { get; set; }
        public string? NewPassword { get; set; }
        public string? Username { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? Cpf { get; set; }
        public bool? ProgramParticipationConsent { get; set; }
        public bool? ConsentToReceiveEmail { get; set; }
        public bool? ConsentToReceiveSms { get; set; }
        public bool? ConsentToReceivePhonecalls { get; set; }
        public User? SystemUser { get; set; }
        public bool? ConsentTermTreat { get; set; }
        public bool? ConsentTermDiag { get; set; }
    }

    public class DoctorInfos
    {
        public string? DoctorName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicensesState { get; set; }
    }
}
