using Care.Api.Context;
using Care.Api.Models.Models;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Care.Api.Repository.Repositories
{
    public class IncidentRepository: CommonRepository<Incident>, IIncidentRepository
    {

        public IncidentRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<IncidentSubject> GetIncidentSubject(string programcode)
        {
            var healthProgramId = _careDbContext.HealthPrograms.FirstOrDefault(_ => _.Code == programcode);

            if (healthProgramId.Id != Guid.Empty)
            {

                var data = _careDbContext.IncidentSubjects.Where(_ => _.HealthProgramId == healthProgramId.Id).ToList();
                return data;
                
            }

            return null;
        }
    }
}

