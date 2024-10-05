using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models.Message.Request
{
    public class MedicationRequest
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }

    }
}
