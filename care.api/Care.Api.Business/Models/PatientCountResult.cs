using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class PatientCountResult
    {
        public string? DiseaseName { get; set; }
        public int? ActivePatientCount { get; set; }
        public int? InactivePatientCount { get; set; }
        public int? ChildAge { get; set; }
        public int? TeenagerAge { get; set; }
        public int? AdultAge { get; set; }
        public string? ReasonInactive { get; set; }
        public string? PatientName { get; set; }
        public int? ExamCount { get; set; }
        public int? InfusionCount { get; set; }
        public int? TreatmentCount { get; set; }
    }
}
