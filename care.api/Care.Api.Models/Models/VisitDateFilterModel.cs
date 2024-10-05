using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class VisitDateFilterModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? NameTreatment { get; set; } = string.Empty;
        public Guid? typeofvisit { get; set; } = null;
        public Guid? situationofVisit { get; set; } = null;
        public Guid? period { get; set; } = null;
    }

}
