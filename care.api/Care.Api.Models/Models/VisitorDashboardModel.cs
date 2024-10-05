

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Models
{
    public class VisitorDashboardModel
    {
        public Guid? VisitId { get; set; }
        public string? VisitSchedulingType { get; set; }
        public DateTime? InitialHour { get; set; }
        public DateTime? FinalHour { get; set; }
        public DateTime? DateVisit { get; set; }
        public string? HealthProgramName { get; set; }
        public string? TypeOfVisit { get; set; }
        public string? TreatmentName { get; set; }
        public string? CaregiverName { get; set; }
        public string? TreatmentAge { get; set; }
        public string? TreatmentTelephone { get; set; }
        public string? TreatmentAdress { get; set; }
        public string? VisitStatus { get; set; }
        public string? JustificationVisit { get; set; }
        public string? ObservationVisit { get; set;}
        public string? VisitorName { get;set; }
        public string? MedicName { get; set; }
        public string? MedicLicenseNumber { get;set; }
        public string? MedicLicenseState { get; set; }
        public string? QuantityofVisit { get; set; }
        public string? LastVisit { get; set; }
    }
}
