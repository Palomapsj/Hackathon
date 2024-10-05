using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Care.Api.Repository.Repositories
{
    public class InfusionRepository : CommonRepository<Infusion>, IInfusionRepository
    {
        public InfusionRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<InfusionAudit> GetInfusionAudit(Guid id)
        {
            var infusionAuditList = _careDbContext.InfusionAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return infusionAuditList;
        }

        public List<Infusion> GetInfusionsByTreatment(Guid? id)
        {

            var infusion = _careDbContext.Infusions
                                    .Where(_ => _.TreatmentId == id && _.IsDeleted == false)
                                    .Include(_ => _.Voucher)
                                    .Include(_ => _.Treatment)
                                    .Include(_ => _.HealthProgram)
                                    .Include(_ => _.InfusionStatusStringMap)
                                    .Include(_ => _.Medicament)
                                    .Include(_ => _.Place)
                                    .Include(_ => _.ReasonInfusionNotDoneStringMap)
                                    .ToList();

            return infusion;
        }
        public async Task<int> GetPatientInfusionCountByMedicamentId(Guid medicamentId, string programCode)
        {
            // Consulta para buscar o HealthProgramId
            var healthProgramId = await _careDbContext.HealthPrograms
                                  .Where(hp => hp.Code == programCode)
                                  .Select(hp => hp.Id)
                                  .FirstOrDefaultAsync();

            // Consulta para contar os registros
            int count = await _careDbContext.Treatments
                         .Where(t => t.HealthProgramId == healthProgramId &&
                                     t.MedicamentId == medicamentId)
                         .CountAsync();

            return count;
        }
        public async Task<List<Infusion>> GetAllInfusionByDoctor(Guid? userId, Guid? healthprogramId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Infusions
                    .Where(_ => _.HealthProgramId == healthprogramId && _.IsDeleted == false && _.DoctorId == doctorByProgram.DoctorId)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }
    }

}
