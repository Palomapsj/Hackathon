using Care.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class VisitNurse
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public Guid Id { get; set; }
        public string ProgramCode { get; set; }
        public DateTime? SolicitationDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int? Amount { get; set; }
        public string? StatusVisit { get; set; }
        public Guid? StatusVisitId { get; set; }
        public string? StatusName { get; set; }
        public Guid? NurseId { get; set; }
        public string? NurseName { get; set; }
        public int FabryKit { get; set; }
        public int MpsKit { get; set; }
        public int GaucherKit { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressComplement { get; set; }
        public string? DiseaseName { get; set; }
        public Guid? DoctorId { get; set; } 
        public string? DoctorName { get; set; }
        public string? WithDrawalPreference { get; set; }
        public string? TypeRequest { get; set; }
    }
}
