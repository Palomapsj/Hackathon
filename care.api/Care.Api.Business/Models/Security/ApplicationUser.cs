using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ApplicationUser
    {
        public string Password { get; set; }
        public Enums.UserType UserType { get; set; }
        public Guid Code { get; set; }
        public Guid? ProgramId { get; set; }
        public int? ProgramCode { get; set; }
        public int FirstAccess { get; set; }
        public string Email { get; set; }
    }
}
