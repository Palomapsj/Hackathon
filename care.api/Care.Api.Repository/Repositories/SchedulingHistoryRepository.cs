using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class SchedulingHistoryRepository : CommonRepository<SchedulingHistory>, ISchedulingHistoryRepository
    {
        public SchedulingHistoryRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
    }
}
