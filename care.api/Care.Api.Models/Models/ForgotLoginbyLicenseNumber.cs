using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ForgotLoginbyLicenseNumber
    {
        public string licenseNumber { get; set; }
        public string licenseState { get; set; }
        public string healthProgramCode { get; set; }
        public string flag { get; set; }
    }
}
