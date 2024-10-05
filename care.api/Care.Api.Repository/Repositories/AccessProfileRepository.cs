using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Care.Api.Repository.Repositories
{
    public class AccessProfileRepository : CommonRepository<AccessProfile>, IAccessProfileRepository
    {
        public AccessProfileRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
    }
}
