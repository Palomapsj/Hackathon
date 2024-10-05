using Care.Api.Models;
using Care.Api.Models.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IVisitRepository : ICommonRepository<Visit>
    {
        Task<List<Visit>> GetVisitByDateRange(DateTime startDate, DateTime endDate, Guid VisitorId, String Code, Guid? TypeOfVisit, Guid? SituationOfVisit,  string? NameTreatment);
        Task<List<MultidisciplinaryService>> GetMultidisciplinaryServicesById(Guid id);
        List<Visit> GetVisitsByTreatment(Guid? id);
    }
}
