using Care.Api.Context;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class UserPasswordHistoryRepository : CommonRepository<UserPasswordHistory>, IUserPasswordHistoryRepository
    {
        public UserPasswordHistoryRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
    }
}
