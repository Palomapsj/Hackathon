namespace Care.Api.Repository.Dapper.Interface
{
    public interface IDapperReportRepository
    {
        IEnumerable<dynamic> GetReportDoctors(string patientName, string patientCpf, Guid healthProgramId, Guid doctorId, int page, int pageSize);
    }
}
