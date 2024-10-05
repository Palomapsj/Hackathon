using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class DoctorsRepresentativeModel : CommonModel
    {
       // public Guid? RepresentativeId { get; set; }
        public string? RepresentativeName { get; set; }
        public string? LicenseNumberCoren { get; set; }
        public string? LicenseStateCoren { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? DoctorLicenseNumber { get; set; }
        public string? DoctorLicenseState { get; set; }
        public string? ProgramCode { get; set; }
    }
}
