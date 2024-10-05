using Care.Api.Models;

namespace Care.Api.Repository.Interfaces;

public interface IInfusionRepository : ICommonRepository<Infusion>
{
    List<InfusionAudit> GetInfusionAudit(Guid id);
    List<Infusion> GetInfusionsByTreatment(Guid? id);
    Task<int> GetPatientInfusionCountByMedicamentId(Guid medicamentId, string programCode);
    Task<List<Infusion>> GetAllInfusionByDoctor(Guid? userId, Guid? healthprogramId);
}
