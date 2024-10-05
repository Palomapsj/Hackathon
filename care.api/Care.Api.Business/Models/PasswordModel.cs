using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class PasswordModel
    {
        public string? Email { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Programcode { get; set; }
    }

    public class PasswordPersonalizedModel
    {
        public string? Email { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Telephone { get; set; }
        public string? OldEmail { get; set; }
        public string? Login { get; set; }
        public string? ProgramCode { get; set; }
    }
}