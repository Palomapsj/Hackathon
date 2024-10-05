using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Models
{
    public class PostalCodeEntity
    {

        public string AddressPostalCode { get; set; }
        public string AddressType { get; set; }
        public string AddressName { get; set; }
        public string AddressDistrict { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressCountry { get; set; }
        public string AddressComplement { get; set; }        
        public string AddressFull  { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class PostalCodeStateEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class PostalCodeCityEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class PostalCodeTypeEntity
    {
        public Guid Id { get; set; }
    }
}

