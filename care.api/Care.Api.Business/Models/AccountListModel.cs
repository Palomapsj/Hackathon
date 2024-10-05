using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class AccountListModel
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 5;
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public string? MobilePhone { get; set; }
        public string? MainContact { get; set; }
        public string? Cnpj { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressCountry { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? EmailAddress { get; set; }
        public string? EmailAddress2 { get; set; }
        public string? Password { get; set; }
        public string? ProgramCode { get; set; }
        public string? FriendlyCode { get; set; }
        public Guid? AccountId { get; set; }
        public string? ProfileName { get; set; }
        public string? ProfileCode { get; set; }
        public string? CodeSap { get; set; }
    }
}