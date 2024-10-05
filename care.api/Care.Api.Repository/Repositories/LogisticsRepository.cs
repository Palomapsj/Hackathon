using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class LogisticsRepository : CommonRepository<Logistics>, ILogisticsRepository
    {
        public LogisticsRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<LogisticsAudit> GetLogisticAudit(Guid id)
        {
            var logisticsAuditList = _careDbContext.LogisticsAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return logisticsAuditList;
        }

        public List<Logistics> GetLogisticsByTreatment(Guid treatmentid)
        {
            var logisticsAuditList = _careDbContext.Logistics.Include(_ => _.SendStatusStringMap).Where(_ => _.TreatmentId == treatmentid && _.IsDeleted == false).ToList();

            return logisticsAuditList;
        }
        public async Task<List<Logistics>> GetLogisticsByProgramAndLogistic(Guid healthProgram, Guid userId)
        {
            try
            {
                var accountSettingsByPrograms = _careDbContext.AccountSettingsByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Logistics
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.LogisticsPartnerId == accountSettingsByPrograms.AccountId)
                    .Include(_ => _.SendStatusStringMap)
                    .Include(_ => _.HealthProgram)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<Logistics> GetLogisticsById(Guid Id)
        {
            try
            {

                return _careDbContext.Logistics
                    .Where(_ => _.IsDeleted == false && _.Id == Id)
                    .Include(_ => _.SendStatusStringMap)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.LogisticsStuff)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<Logistics>> GetLogisticsByIdList(Guid Id)
        {
            try
            {

                return _careDbContext.Logistics
                    .Where(_ => _.IsDeleted == false && _.Id == Id)
                    .Include(_ => _.SendStatusStringMap)
                    .Include(_ => _.HealthProgram)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<Logistics>> GetLogisticsByProgramAndPatient(Guid healthProgram, Guid userId)
        {
            try
            {
                var patient = _careDbContext.Patients.Where(p => p.SystemUserId == userId && p.IsDeleted == false).FirstOrDefault();

                var treatment = _careDbContext.Treatments.Where(t => t.PatientId == patient.Id && t.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Logistics
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.TreatmentId == treatment.Id)
                    .Include(_ => _.SendStatusStringMap)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.LogisticsPartner)
                    .Include(_ => _.LogisticsTypeStringMap)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }


    }
}
