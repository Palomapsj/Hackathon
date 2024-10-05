using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories;

public sealed class RepresentativeDoctorByProgramRepository : CommonRepository<RepresentativeDoctorByProgram>, IRepresentativeDoctorByProgramRepository
{
    public RepresentativeDoctorByProgramRepository(CareDbContext careDbContext, IHealthProgramRepository healthProgramRepository) : base(careDbContext)
    { 
        
    }

    public RepresentativeDoctorByProgram GetRepresentativeDoctorByProgram(Guid representativeId, Guid doctorId, Guid healthProgramId)
    {

        return _careDbContext.RepresentativeDoctorByPrograms.OrderByDescending(r => r.RegisterDate).FirstOrDefault(r => r.RepresentativeId == representativeId && r.DoctorId == doctorId && r.HealthProgramId == healthProgramId);
    }

}

