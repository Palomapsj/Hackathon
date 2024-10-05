using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class DoctorByProgramRepository : CommonRepository<DoctorByProgram>, IDoctorByProgramRepository
    {
        private readonly IHealthProgramRepository _healthProgramRepository;

        public DoctorByProgramRepository(CareDbContext careDbContext, IHealthProgramRepository healthProgramRepository) : base(careDbContext)
        {
            _healthProgramRepository = healthProgramRepository;
        }

        public DoctorByProgram GetDoctorByUser(Guid? userId)
        {
            try
            {
                var doctor = _careDbContext.DoctorByPrograms
                                    .Where(_ => _.SystemUserId == userId && _.IsDeleted == false)
                                    .FirstOrDefault();


                return doctor;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<DoctorByProgram?> GetDoctorByUserAsync(Guid? userId)
        {
            var doctorByProgram = await _careDbContext.DoctorByPrograms.Where(_ => _.SystemUserId == userId && _.IsDeleted == false).FirstOrDefaultAsync();

            return doctorByProgram;
        }

        public IQueryable<DoctorByProgram>? Queryable()
        {
            try
            {
                return _careDbContext.Set<DoctorByProgram>().AsQueryable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
                return null;
            }
        }
    }
}
