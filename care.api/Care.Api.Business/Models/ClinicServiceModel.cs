namespace Care.Api.Business.Models
{
    public class ClinicServiceModel
    {
        public Guid? ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string? ClinicName { get; set; }
    }

    public class ClinicServicesListModel : List<ClinicServiceModel> { }
}
