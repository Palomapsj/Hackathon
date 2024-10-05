using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IHealthProgramFileRepository : ICommonRepository<HealthProgramFile>
    {

        List<HealthProgramFile> GetFileByPath(string path);

    }
}
