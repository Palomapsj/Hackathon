using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class TreatmentByPatientModel
    {
        public string? ClinicName { get;  set; }
        public DateTime? ExamDate { get;  set; }
        public DateTime? InfusionDate { get;  set; }
        public string? Exam { get;  set; }
        public string? ClinicNameInfusion { get;  set; }
        public bool? Cycle { get;  set; }
        public string? ServiceExam { get;  set; }
        public string? ExamType { get;  set; }
    }
}
