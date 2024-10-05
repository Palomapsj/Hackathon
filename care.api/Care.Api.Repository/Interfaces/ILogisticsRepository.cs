using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface ILogisticsRepository : ICommonRepository<Logistics>
    {
        List<LogisticsAudit> GetLogisticAudit(Guid id);

        List<Logistics> GetLogisticsByTreatment(Guid treatmentid);
        Task<Logistics> GetLogisticsById(Guid Id);
        Task<List<Logistics>> GetLogisticsByProgramAndLogistic(Guid healthProgram, Guid userId);
        Task<List<Logistics>> GetLogisticsByProgramAndPatient(Guid healthProgram, Guid userId);
    }

}
