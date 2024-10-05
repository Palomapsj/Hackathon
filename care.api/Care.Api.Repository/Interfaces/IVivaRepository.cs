using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IVivaRepository : ICommonRepository<Treatment>
    {
        Task<Treatment> GetPacientByGUID(Guid? TreatmentId);
    }
}
