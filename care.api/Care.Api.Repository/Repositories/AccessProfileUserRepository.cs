using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Care.Api.Repository.Repositories
{
    public class AccessProfileUserRepository : CommonRepository<AccessProfileUser>, IAccessProfileUserRepository
    {
        public AccessProfileUserRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
    }
}
