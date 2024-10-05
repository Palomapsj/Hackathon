namespace Care.Api.Business.Models
{
    public class AccountCreateModel
    {
        public string? AccountTypeStringMapFlag { get; set; }
        public string? Name { get; set; } // razão social
        public string? Telephone1 { get; set; }
        public string? MobilePhone { get; set; }
        public string? EmailAddress { get; set; }
        public string? EmailAddress2 { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressCountry { get; set; }
        public string? Cnpj { get; set; }
        public string? MainContact { get; set; } // nome do responsável
        public string? Password { get; set; }
        public string? ProgramCode { get; set; }
        public string? SapCode { get; set; }
    }
}
