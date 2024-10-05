using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class UserForgotPassword
    {
        public string? UserEmail { get; set; }
        public string? TemplateName { get; set; }
        public string? ProgramCode { get; set; }
    }
}
