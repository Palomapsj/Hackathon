using Care.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models.Message.Request
{
    public class PhoneRequest
    {
        public string Ddd  { get; set; }
        public string Number { get; set; }
    }
}
