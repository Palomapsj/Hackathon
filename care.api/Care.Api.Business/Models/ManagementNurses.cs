using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ManagementNurses
    {
        public Guid? NurseId { get; set; }
        public string? StatusCode { get; set; }
        public bool? Status { get; set; }
        public string? ProgramCode { get; set; }
    }
}
