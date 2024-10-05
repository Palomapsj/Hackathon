using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    
    public class CountTreatmentExamAndPatientModel
    {
        public string programcode { get; set; }
        public Guid medicamentId { get; set; }
        public Guid phaseId { get; set; }

    }

}
