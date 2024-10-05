using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class VoucherConfigurationRepository : CommonRepository<VoucherConfiguration>, IVoucherConfigurationRepository
    {
        public VoucherConfigurationRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }
    }
}
