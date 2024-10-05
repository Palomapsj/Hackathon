using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories;

public sealed class PhaseRepository : CommonRepository<Phase>, IPhaseRepository
{
    public PhaseRepository(CareDbContext careDbContext) : base(careDbContext)
    {

    }

    public string GetNamePhaseFromId(Guid? phaseId)
    {
        try
        {
            var phase = _careDbContext.Phases.Where(x => x.Id == phaseId && x.IsDeleted == false).FirstOrDefault();

            return phase.Name;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
