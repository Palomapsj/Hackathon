using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class ResourceWorkSettingRepository : CommonRepository<ResourceWorkSetting>, IResourceWorkSettingRepository
    {
        public ResourceWorkSettingRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }
    }
}
