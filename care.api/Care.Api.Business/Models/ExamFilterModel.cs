using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ExamFilterModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PatientName { get; set; }
        public string? NamePatient { get; set; }
        public string? CpfPatient { get; set; }
        public Guid? ExamStatusId { get; set; }
        public Guid? PatientStatus { get; set; }
        public Guid? ServiceType { get; set; }
        public Guid? ExamDefinitionId { get; set; }
    }
    
}

