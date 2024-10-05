using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IActionConfigurationRepository : ICommonRepository<ActionConfiguration>
    {
        ActionConfiguration GetByActionCodeAndProgram(string actionCode, Guid healthProgramId);
    }
}
