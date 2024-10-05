using Care.Api.Context;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class TemplateConfigurationRepository : CommonRepository<TemplateConfiguration>, ITemplateConfigurationRepository
    {
        public TemplateConfigurationRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
    }
}
