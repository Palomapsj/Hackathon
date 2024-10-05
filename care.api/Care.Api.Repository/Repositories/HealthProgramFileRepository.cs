using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class HealthProgramFileRepository : CommonRepository<HealthProgramFile>, IHealthProgramFileRepository
    {
        public HealthProgramFileRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<HealthProgramFile> GetFileByPath(string path)
        {
            List<HealthProgramFile> ret = new List<HealthProgramFile>();



            return ret;
        }

    }
}
