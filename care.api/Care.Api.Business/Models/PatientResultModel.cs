using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class PatientResultModel
    {
        public string? FullName { get; set; }
        public DateTime? Birthdate { get; set; }
        public Guid? GenderStringMapId { get; set; }
        public string? Telephone1 { get; set; }
        public string? Mobilephone1 { get; set; }
        public string? EmailAddress1 { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressComplement { get; set; }
        public string? LicenseNumber { get; set;}
        public string? LicenseState { get; set; }
        public string? DoctorName { get; set; }
        public Guid? DiseaseId { get; set; }
        public Guid? MedicamentId { get; set;}
    }
}
