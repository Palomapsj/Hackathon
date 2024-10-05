using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Care.Api.Repository.Repositories
{
    public class ActionConfigurationRepository : CommonRepository<ActionConfiguration>, IActionConfigurationRepository
    {
        public ActionConfigurationRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public ActionConfiguration GetByActionCodeAndProgram(string actionCode, Guid healthProgramId)
        {
            var actionConfiguration = _careDbContext.ActionConfigurations
                .Include(i => i.ActionRules)
                .Where(a => a.ActionCode == actionCode && a.HealthProgramId == healthProgramId).FirstOrDefault();

            return actionConfiguration;
        }
    }
}
