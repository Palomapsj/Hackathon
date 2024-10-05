using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class RequestDiagnosticExamModel
    {
        public Guid DiagnosticId { get; set; }
        public string? ProgramCode { get; set; }
        public List<Guid> examsid { get; set; }
        public AttachmentModel? MedicalRequestAttach { get; set; }
    }
}
