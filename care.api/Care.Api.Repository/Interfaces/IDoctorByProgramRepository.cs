using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IDoctorByProgramRepository : ICommonRepository<DoctorByProgram>
    {
        DoctorByProgram GetDoctorByUser(Guid? userId);
        Task<DoctorByProgram?> GetDoctorByUserAsync(Guid? userId);
        IQueryable<DoctorByProgram?> Queryable();
    }
}
