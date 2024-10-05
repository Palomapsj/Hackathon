using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class HealthProfessionalByProgramRepository : CommonRepository<HealthProfessionalByProgram>, IHealthProfessionalByProgramRepository
    {
        public HealthProfessionalByProgramRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
    }
}
