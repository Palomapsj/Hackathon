using Care.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class RepresentativeCreateModel : CommonModel
    {
        public Guid NurseId { get; set; }
        public string? TypeProfessional { get; set; }
        public string? ProfessionalName { get; set; }
        public string? CPF{ get; set; }
        public string? LicenseNumberCoren { get; set; }
        public string? LicenseStateCoren { get; set; }
        public string? Telefone { get; set; }
        public string? Mobilephone { get; set; }
        public string? EmailAddress { get; set; }
        public string? DoctorLicenseNumber { get; set; }
        public string? DoctorLicenseState { get; set; }
        public bool? ProgramRegulation { get; set; }
        public string? ProgramCode { get; set; }
        public Guid? ProfessionalTypeStringMap { get; set; }
        public string? ProfessionalTypeStringMapFlag { get; set; }
        public string? Password { get; set; }

    }
}
