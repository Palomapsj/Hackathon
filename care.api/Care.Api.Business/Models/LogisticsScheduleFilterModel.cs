namespace Care.Api.Business.Models
{
    public class LogisticsScheduleFilterModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public DateTime? RequestDate { get; set; }
        public string? Protocol { get; set; }
        public Guid? LogisticsScheduleStatus { get; set; }
        public List<Guid>? LogisticsScheduleStatusArray { get; set; }
        public Guid? TypeOfRequest { get; set; }
        public Guid? StatusId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCpf { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? DoctorName { get; set; }
        public Guid? Doctor { get; set; }
    }

    public class VisitsNurseFilterModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public Guid Id { get; set; }
        public string ProgramCode { get; set; }
        public DateTime? SolicitationDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int? Amount { get; set; }
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