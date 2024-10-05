using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Dapper;
using Care.Api.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Care.Api.Repository.Repositories
{
    public class TreatmentCustomDataRepository : CommonRepository<TreatmentCustomData>, ITreatmentCustomDataRepository
    {
        private readonly IConfiguration _config;

        public TreatmentCustomDataRepository(CareDbContext careDbContext, IConfiguration config) : base(careDbContext)
        {
            _config = config;
        }

        public bool UpdateFunctional(Guid id, int? instructorRequest, int? unitDose, int? medicamentCod)
        {
            var coreDapper = new CoreDapperRepository(_config);

            return coreDapper.UpdateFunctional(id, instructorRequest, unitDose, medicamentCod);           
        } 
    }
}
