using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Business.Models
{
    public class AccountSettingsByProgramResultModel
    {
        public string? ClinicName { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressComplement { get; set; }
        public string? Services { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ClinicLowerCase { get; set; }
        public Guid? ServiceId { get; set; }

    }

    public class AccountServiceTypeResultModel
    {
        public string? ClinicName { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressComplement { get; set; }
        public string? Services { get; set; }
        public Guid? ServiceId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ClinicLowerCase { get; set; }

    }
}
