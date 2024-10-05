using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class SmsTokenValidationModel
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public string MobilePhone { get; set; }
        public string ProgramCode { get; set; }
    }
}
