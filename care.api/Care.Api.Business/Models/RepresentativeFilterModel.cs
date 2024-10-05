using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class RepresentativeFilterModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? NurseName { get; set; }
        public string? NurseCPF { get; set; }
        public string? NurseType { get; set; }
    }
}
