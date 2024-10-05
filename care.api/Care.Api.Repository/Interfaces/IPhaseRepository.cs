using Care.Api.Models;
using Care.Api.Models.Models;

namespace Care.Api.Repository.Interfaces;

public interface IPhaseRepository : ICommonRepository<Phase>
{
    string GetNamePhaseFromId(Guid? phaseId);
}
