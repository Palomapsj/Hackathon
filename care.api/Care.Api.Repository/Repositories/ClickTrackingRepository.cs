using Care.Api.Context;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class ClickTrackingRepository : CommonRepository<ClickTracking>, IClickTrackingRepository
    {
        public ClickTrackingRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }
    }
}
