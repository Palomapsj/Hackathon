using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories;

public sealed class RepresentativeRepository : CommonRepository<Representative>, IRepresentativeRepository
{
    public RepresentativeRepository(CareDbContext careDbContext, IHealthProgramRepository healthProgramRepository) : base(careDbContext)
    { 
        
    }
    public Representative GetProfessionalByLicense(Guid id, Guid? userid)
    {
        try
        {
            var professional = _careDbContext.Representatives
                .Where(_ => _.Id == id && _.UserId == userid && _.IsDeleted == false)
                .Include(_ => _.User)
                .FirstOrDefault();

            return professional;
        }
        catch (Exception ex)
        {
           return null;
        }

    }
}

