using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ExamRequestModel
    {
        public Guid Id { get; set; }
        public Guid? TreatmentId { get; set; }
        public Guid? DiagnosticId { get; set; }
        public string ProgramCode { get; set; }
        public string? Description { get; set; }
        public AttachmentModel? MedicalPrescriptionAttach { get; set; }
        public AttachmentModel? TransportDeclarationAttach { get; set; }
        public AttachmentModel? ConsentTermAttach { get; set; }
        public AttachmentModel? MedicalRequestAttach { get; set; }
    }
}
