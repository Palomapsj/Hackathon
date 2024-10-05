using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class UserSystemLogRepository : CommonRepository<UserSystemLog>, IUserSystemLogRepository
    {

        public UserSystemLogRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

    }
}
