namespace Care.Api.Business.Models
{
    public class AccountSettingsByProgramFilterModel
    {

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public string? City { get; set; }
        public string? ClinicName { get; set; }
        public string? ProgramCode { get; set; }

        public string? Service { get; set; }
        public Guid? ServiceId { get; set; }
       
    }

    public class AccountServiceTypeFilterModel
    {

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public string? City { get; set; }
        public string? ClinicName { get; set; }
        public string? ProgramCode { get; set; }
        public string? Service { get; set; }
    }
}
