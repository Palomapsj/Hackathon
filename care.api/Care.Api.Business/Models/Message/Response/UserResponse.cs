using Care.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Care.Api.Business.Models.Enums;

namespace Care.Api.Business.Models.Messages.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public Guid Code { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int role { get; set; }
        public int ProgramCode { get; set; }
        public Guid? ProgramId { get; set; }

        public bool EmailConfirmed { get; set; }
        public int FirstAccess { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public int UserType { get; set; }

        public string? InternalControl { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<AccessProfile> AccessProfiles { get; } = new List<AccessProfile>();

    }
}
