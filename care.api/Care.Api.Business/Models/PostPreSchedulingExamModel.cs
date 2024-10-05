using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class PostPreSchedulingExamModel
    {
        public string HealthProgramCode { get; set; }
        public string TreatmentCpf { get; set; }
        public string PatientRg { get; set; }
        public string ExamDefinitionId { get; set; }
    }

}

