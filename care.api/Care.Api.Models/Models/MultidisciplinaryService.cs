using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Models
{
    public class MultidisciplinaryService
    {
        public DateTime? Data { get;  set; }
        public DateTime? Status { get;  set; }
        public string? Type { get;  set; }
        public string? Code { get;  set; }
    }
}
