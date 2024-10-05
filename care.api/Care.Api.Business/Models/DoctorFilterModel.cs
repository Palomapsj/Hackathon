namespace Care.Api.Business.Models;

public class DoctorFilterModel
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? DoctorName { get; set; }
    public string? DoctorCRMUF { get; set; }
    public string? DoctorSpecialty { get; }
}
