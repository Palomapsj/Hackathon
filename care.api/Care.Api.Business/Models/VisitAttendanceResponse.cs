using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class VisitAttendanceResponse
    {
        public Guid? VisitId { get; set; }
        public DateTime? ScheduleDateStart { get; set; }
        public string? SheduledHour { get; set; }
        public string? PatientName { get; set; }
        public string? FriendlyCode { get; set; }
        public string? AttendanceStatus { get; set; }
        public string? NameProfessional { get; set; }
    }
}
