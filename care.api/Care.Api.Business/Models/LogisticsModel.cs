using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class LogisticsModel : CommonModel
    {
        public Guid? TreatmentId { get; set; }
        public string? ProgramCode { get; set; }
        public Guid? Id { get; set; }
        public Guid? LogisticsStuffId { get; set; }     
    }
}
