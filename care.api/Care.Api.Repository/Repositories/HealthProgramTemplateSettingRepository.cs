using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class HealthProgramTemplateSettingRepository : CommonRepository<HealthProgramTemplateSetting>, IHealthProgramTemplateSettingRepository
    {
        public HealthProgramTemplateSettingRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }
    }
}
