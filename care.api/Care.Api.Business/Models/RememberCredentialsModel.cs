using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class RememberCredentialsModel
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public bool AcceptCookies { get; set; }
    }
}
