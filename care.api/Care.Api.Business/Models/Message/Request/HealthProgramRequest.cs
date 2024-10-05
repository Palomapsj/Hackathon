using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models.Message.Request
{
    public class HealthProgramRequest : CommonModel
    {
        public Guid? Id { get; set; }
        public string? Code { get; set; }
    }
}
