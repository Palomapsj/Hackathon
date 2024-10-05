using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IHealthProgramRepository : ICommonRepository<HealthProgram>
    {
        public List<HealthProgram> GetHealthProgramByMedicaments(Guid? Id);
    }
}
