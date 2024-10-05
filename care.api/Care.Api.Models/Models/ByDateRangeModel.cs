using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ByDateRangeModel
    {
        public string? FullName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? MedicamentName { get; set; }
        public bool? StateCode { get; set; }

        public Guid? TreatmentStatusId { get; set; }
        public Guid? PhaseId { get; set; }
        public DateTime? TreatmentStartDate { get; set; }
        public DateTime? TreatmentStopDate { get; set; }
        public string? InfusionStatus { get; set; }
        public Guid? PatientId { get; set; }
    }
}
