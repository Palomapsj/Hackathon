using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class SmsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TemplateName { get; set; }
        public string Mobilephone { get; set; }
        public string Message { get; set; }
        public DateTime ScheduledSendDate { get; set; }
        public Guid HealthProgramId { get; set; }
        public string ProgramCode { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool StateCode { get; set; }
        public Guid SmsStatusStringMapId { get; set; }
        public string InternalControl { get; set; }
    }
}
