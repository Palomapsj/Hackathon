
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class PostSettleVisit
    {
        public string HealthProgramCode { get; set; }
        public Guid VisitId { get; set; }
        
        public Guid SituationOfVisit { get; set; }
        public Guid ReasonSettleStringMapId { get; set; }

        public string MinutesOfVisite { get; set; }

        public string NumberOfParticipants {get;set; }

    }

}

