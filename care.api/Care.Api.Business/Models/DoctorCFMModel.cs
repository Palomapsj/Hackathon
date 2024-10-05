using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class DoctorCFMModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MedicalSpecialty { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseState { get; set; }
        public string Status { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set;}
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
    }
}
