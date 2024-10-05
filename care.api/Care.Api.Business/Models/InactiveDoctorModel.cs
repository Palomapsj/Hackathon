namespace Care.Api.Business.Models;

public class InactiveDoctorModel
{
    public required Guid DoctorByProgramId { get; set; }
    public string? InactiveType { get; set; }
    public required string ProgramCode { get; set; }
}