using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class ConfigurationRepository : CommonRepository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }
    }
}
