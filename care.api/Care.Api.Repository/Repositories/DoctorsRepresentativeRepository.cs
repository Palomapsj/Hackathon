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
    public class DoctorsRepresentativeRepository : CommonRepository<DoctorsRepresentative>, IDoctorsRepresentativeRepository
    {
        private readonly IHealthProgramRepository _healthProgramRepository;

        public DoctorsRepresentativeRepository(CareDbContext careDbContext, IHealthProgramRepository healthProgramRepository) : base(careDbContext)
        {
            _healthProgramRepository = healthProgramRepository;
        }
        public DoctorsRepresentative GetProfessionalByLicense(Guid Id)
        {
            try
            {
                var professional = _careDbContext.DoctorsRepresentatives
                                    .Where(_ => _.Id == Id && _.IsDeleted == false)
                                    .Include(_ => _.Representative)
                                    .FirstOrDefault();


                return professional;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
