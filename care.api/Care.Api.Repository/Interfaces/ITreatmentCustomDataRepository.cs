using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface ITreatmentCustomDataRepository : ICommonRepository<TreatmentCustomData>
    {
        bool UpdateFunctional(Guid id, int? instructorRequest, int? unitDose, int? medicamentCod);
    }
}
