using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class DocumentLibraryResultModel
    {
        public Guid Id { get; set; }
        public DateTime? AvailableIn { get; set; }
        public string? Title { get; set; }
        public string? Status { get; set; }
        public string? Profile { get; set; }
        public DateTime? InactivationDate { get; set; }
        public string? ContentType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<Guid> AnnotationsId { get; set; }
        public Guid? DiseaseId { get; set; }
        public string? MedicamentId { get; set; }
        public DocumentLibraryResultModel()
        {
            AnnotationsId = new List<Guid>();
        }
    }
}
