using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class VisitAttendanceModel
    {
        public Guid? OriginEntityId { get; set; }
        public string? ProgramCode { get; set; }
    }
}
