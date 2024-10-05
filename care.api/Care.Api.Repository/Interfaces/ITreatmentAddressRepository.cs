using Care.Api.Models;


namespace Care.Api.Repository.Interfaces
{
    public interface ITreatmentAddressRepository : ICommonRepository<TreatmentAddress>
    {
        Task<TreatmentAddress> GetByTreatmentId(Guid id);
        Task<TreatmentAddress> GetAddressByTreatmentId(Guid id);

    }
}
