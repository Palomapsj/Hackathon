using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class VisitListTreatment
    {

        public string? PatientName { get; set; }
        public DateTime? ScheduleDateStart { get; set; }
        public DateTime? CreatedOn { get; set; }   
        public string? FriendlyCode { get; set; }
        public string? CustomString1 { get; set; }
        public string? DoctorName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseState { get; set; }
        public string? PatientCPF { get; set; } 
        public string? Phase { get; set; }
        public string? StatusPatient { get; set; }
        public string? StatusVisit { get; set; }
    }
}
