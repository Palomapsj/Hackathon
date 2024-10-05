using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class VivaRepository : CommonRepository<Treatment>, IVivaRepository
    {
        public VivaRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public async Task<Treatment> GetPacientByGUID(Guid? TreatmentId)
        {
            Treatment treatment = await _careDbContext.Treatments.Where(v => v.Id == TreatmentId).FirstOrDefaultAsync();

            return treatment;
        }
    }
}
