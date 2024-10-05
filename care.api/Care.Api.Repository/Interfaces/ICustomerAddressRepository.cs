using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface ICustomerAddressRepository : ICommonRepository<CustomerAddress>
    {
        List<CustomerAddress> GetAddressByDoctor(Guid userId, string programcode);
    }
}
