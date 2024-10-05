using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class UserUpdateModel
    {
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserOldEmail { get; set; }
        public DateTime? UserBirthdate { get; set; }
        public string? UserMobilephone { get; set; }
        public string? UserTelephone { get; set; }
        public string? UserCPF { get; set; }
        public string? UserPassword { get; set; }
        public string? UserNewPassword { get; set; }
        public string? ProgramCode { get; set; }
    }
}
