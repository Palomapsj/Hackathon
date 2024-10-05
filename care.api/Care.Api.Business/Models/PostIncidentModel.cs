using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{

    public class PostIncidentModel
    {
        public string? HealthProgramCode { get; set; }
        public string? TreatmentCpf { get; set; }
        public string? TypeServiceName { get; set; }
        public string? ActionCode { get; set; }
    }

}
