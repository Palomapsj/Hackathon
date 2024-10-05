using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Models
{
    public class StockAudit
    {
        public Guid Id { get; set; }

        public string Fields { get; set; }

        public string Message { get; set; }

        public Guid? RegardingObjectId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? UserId { get; set; }

        public string XmlnewValues { get; set; }

        public string XmloldValues { get; set; }

        public byte[] Version { get; set; }
    }
}
