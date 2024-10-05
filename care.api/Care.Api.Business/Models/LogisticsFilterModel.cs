using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class LogisticsFilterModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public DateTime? RequestDate { get; set; }
        public string? Protocol { get; set; }
        public Guid? LogisticsStatus { get; set; }
        public List<Guid>? LogisticsStatusArray { get; set; }
        public Guid? LogisticsTypeStringMapId { get; set; }
        public Guid? SendStatusStringMapId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCpf { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? DoctorName { get; set; }
    }
}
