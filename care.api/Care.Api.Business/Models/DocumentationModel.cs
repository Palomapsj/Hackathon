using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class DocumentationModel
    {
        public Guid Id { get; set; }
        public string ProgramCode { get; set; }
        public string? Title { get; set; }
        public bool Profile { get; set; }
        public Guid? StatusCodeStringMapId { get; set; }
        public DateTime? StartDate { get; set; }
        public bool Status { get; set; }
        public DateTime? InactivationDate { get; set; }
        public bool? SameAttachment { get; set; }
        public Guid? DiseaseId { get; set; }
        public Guid? MedicamentId { get; set; }

        public AttachmentModel? DocumentationAttach { get; set; }
    }
}