using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Models
{
    public class InfusionHistory
    {
        public DateTime? Data { get; set; }
        public DateTime? Status { get; set; }
        public string? ReasonCancellation { get; set; }
        public string? InfusionCode { get; set; }
        public string? Place { get; set; }
       
    }
    public class InfusionDosage
    {
        public Guid Id { get; set;}
        public string? Dose { get; set; }
    }
}
