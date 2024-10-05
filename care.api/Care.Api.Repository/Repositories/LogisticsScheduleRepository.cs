using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class LogisticsScheduleRepository : CommonRepository<LogisticsSchedule>, ILogisticsScheduleRepository
    {
        public LogisticsScheduleRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndDoctor(Guid healthProgram, Guid userId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.RequestDoctorId == doctorByProgram.DoctorId)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.RequestDoctor)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }
        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndDoctorId(Guid healthProgram, Guid userId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.DoctorId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.RequestDoctorId == doctorByProgram.DoctorId)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.RequestDoctor)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndDoctorProfessional(Guid healthProgram, Guid? userId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.RequestDoctorId == doctorByProgram.DoctorId)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.RequestDoctor)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndLogistic(Guid healthProgram, Guid userId)
        {
            try
            {
                var accountSettingsByPrograms = _careDbContext.AccountSettingsByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.LogisticsPartnerId == accountSettingsByPrograms.AccountId)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.RequestDoctor)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndLogisticProfessional(Guid healthProgram, Guid? userId)
        {
            try
            {
                var accountSettingsByPrograms = _careDbContext.AccountSettingsByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.LogisticsPartnerId == accountSettingsByPrograms.AccountId)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.RequestDoctor)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleAdminFiltered(Guid healthProgram,
            int pageSize, int page)
        {
            try
            {
                return _careDbContext.LogisticsSchedules
                .Include(_ => _.LogisticsScheduleTypeStringMap)
                .Include(_ => _.ScheduleStatusStringMap)
                .Include(_ => _.Disease)
                .Include(_ => _.RequestDoctor).Select(s => new LogisticsSchedule
                {
                    Id = s.Id,
                    HealthProgramId = s.HealthProgramId,
                    IsDeleted = s.IsDeleted,
                    LogisticsScheduleTypeStringMapId = s.LogisticsScheduleTypeStringMapId,
                    ScheduleStatusStringMapId = s.ScheduleStatusStringMapId,
                    DiseaseId = s.DiseaseId,
                    FriendlyCode = s.FriendlyCode,
                    Amount = s.Amount,
                    CreatedOn = s.CreatedOn,
                    ExpectedDeliveryDate = s.ExpectedDeliveryDate,
                    DeliveryConfirmationDate = s.DeliveryConfirmationDate,
                    CustomBoolean1 = s.CustomBoolean1,
                    Disease = s.Disease != null ? new Disease { Id = s.Disease.Id, Name = s.Disease.Name } : null,
                    LogisticsScheduleTypeStringMap = s.LogisticsScheduleTypeStringMap != null ? new StringMap { StringMapId = s.LogisticsScheduleTypeStringMap.StringMapId, OptionName = s.LogisticsScheduleTypeStringMap.OptionName } : null,
                    ScheduleStatusStringMap = s.ScheduleStatusStringMap != null ? new StringMap { StringMapId = s.ScheduleStatusStringMap.StringMapId, OptionName = s.ScheduleStatusStringMap.OptionName } : null,
                    RequestDoctor = s.RequestDoctor != null ? new Doctor { Id = s.RequestDoctor.Id, Name = s.RequestDoctor.Name } : null,
                })
                .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false).OrderByDescending(_ => _.CreatedOn).ToList();

            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleLaboratoryFiltered(Guid healthProgram,
            int pageSize, int page, Guid userId)
        {
            try
            {
                var skip = (pageSize * (page - 1));

                var account = _careDbContext.AccountSettingsByPrograms.Where(a => a.SystemUserId == userId && a.HealthProgramId == healthProgram).FirstOrDefault();

                if (pageSize < 1)
                {
                    pageSize = 1;
                }

                var a =  _careDbContext.LogisticsSchedules
                .Include(_ => _.LogisticsScheduleTypeStringMap)
                .Include(_ => _.ScheduleStatusStringMap)
                .Include(_ => _.Disease)
                .Include(_ => _.RequestDoctor).Select(s => new LogisticsSchedule
                {
                    Id = s.Id,
                    HealthProgramId = s.HealthProgramId,
                    IsDeleted = s.IsDeleted,
                    LogisticsScheduleTypeStringMapId = s.LogisticsScheduleTypeStringMapId,
                    ScheduleStatusStringMapId = s.ScheduleStatusStringMapId,
                    DiseaseId = s.DiseaseId,
                    FriendlyCode = s.FriendlyCode,
                    Amount = s.Amount,
                    CreatedOn = s.CreatedOn,
                    ExpectedDeliveryDate = s.ExpectedDeliveryDate,
                    DeliveryConfirmationDate = s.DeliveryConfirmationDate,
                    CustomBoolean1 = s.CustomBoolean1,
                    DeliveryLaboratoryId = s.DeliveryLaboratoryId,
                    DiagnosticId = s.DiagnosticId,
                    DeliveryDate = s.DeliveryDate,
                    Disease = s.Disease != null ? new Disease { Id = s.Disease.Id, Name = s.Disease.Name } : null,
                    LogisticsScheduleTypeStringMap = s.LogisticsScheduleTypeStringMap != null ? new StringMap { StringMapId = s.LogisticsScheduleTypeStringMap.StringMapId, OptionName = s.LogisticsScheduleTypeStringMap.OptionName } : null,
                    ScheduleStatusStringMap = s.ScheduleStatusStringMap != null ? new StringMap { StringMapId = s.ScheduleStatusStringMap.StringMapId, OptionName = s.ScheduleStatusStringMap.OptionName } : null,
                    RequestDoctor = s.RequestDoctor != null ? new Doctor { Id = s.RequestDoctor.Id, Name = s.RequestDoctor.Name, FullName = s.RequestDoctor.FullName } : null,
                })
                .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.DeliveryLaboratoryId == account.AccountId).Take(page).OrderByDescending(_ => _.CreatedOn).ToList();

                if (pageSize > 1)
                {
                    a = a.Skip(skip).ToList();
                }

                return a;
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<LogisticsSchedule>> GetLogisticsSchedulePendencyAdminFiltered(Guid healthProgram,
            int pageSize, int page)
        {
            try
            {
                var skip = (pageSize - 1) * page;

                return _careDbContext.LogisticsSchedules
                .Include(_ => _.LogisticsScheduleTypeStringMap)
                .Include(_ => _.ScheduleStatusStringMap)
                .Include(_ => _.Disease)
                .Include(_ => _.RequestDoctor).Select(s => new LogisticsSchedule
                {
                    Id = s.Id,
                    HealthProgramId = s.HealthProgramId,
                    IsDeleted = s.IsDeleted,
                    LogisticsScheduleTypeStringMapId = s.LogisticsScheduleTypeStringMapId,
                    ScheduleStatusStringMapId = s.ScheduleStatusStringMapId,
                    DiseaseId = s.DiseaseId,
                    FriendlyCode = s.FriendlyCode,
                    Amount = s.Amount,
                    CreatedOn = s.CreatedOn,
                    ExpectedDeliveryDate = s.ExpectedDeliveryDate,
                    DeliveryConfirmationDate = s.DeliveryConfirmationDate,
                    CustomBoolean1 = s.CustomBoolean1,
                    Disease = s.Disease != null ? new Disease { Id = s.Disease.Id, Name = s.Disease.Name } : null,
                    LogisticsScheduleTypeStringMap = s.LogisticsScheduleTypeStringMap != null ? new StringMap { StringMapId = s.LogisticsScheduleTypeStringMap.StringMapId, OptionName = s.LogisticsScheduleTypeStringMap.OptionName } : null,
                    ScheduleStatusStringMap = s.ScheduleStatusStringMap != null ? new StringMap { StringMapId = s.ScheduleStatusStringMap.StringMapId, OptionName = s.ScheduleStatusStringMap.OptionName } : null,
                    RequestDoctor = s.RequestDoctor != null ? new Doctor { Id = s.RequestDoctor.Id, Name = s.RequestDoctor.Name } : null,
                })
                .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false
                && (
                _.ScheduleStatusStringMapId == new Guid("864B1445-857B-4ABD-A6B9-95EFBDFC178B") ||
                _.ScheduleStatusStringMapId == new Guid("BF3C9F8F-FBAC-45A3-89F8-B22D589191D4") ||
                _.ScheduleStatusStringMapId == new Guid("8E5F4D85-CCDC-466D-BF2B-DD5B272CEFD8"))

                ).OrderByDescending(_ => _.CreatedOn).
                Skip(skip).Take(page).ToList();

            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleAdmin(Guid healthProgram)
        {
            try
            {

                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.HealthProgram)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<LogisticsSchedule> GetLogisticsScheduleById(Guid id)
        {
            try
            {
                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.Id == id)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.RequestDoctor)
                    .Include(_ => _.SchedulingHistories)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.DeliveryLaboratory)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.PreferredTimeStringMap)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<LogisticsSchedule> GetLogisticsScheduleByDiagnostic(Guid diagnosticId)
        {
            try
            {
                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.DiagnosticId == diagnosticId)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.RequestDoctor)
                    .Include(_ => _.SchedulingHistories)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.HealthProgram)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }
        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleByDiagnosticList(Guid diagnosticId)
        {
            try
            {
                return  _careDbContext.LogisticsSchedules
                           .Where(_ => _.DiagnosticId == diagnosticId)
                           .Include(_ => _.Diagnostic)
                           .Include(_ => _.LogisticsScheduleTypeStringMap)
                           .Include(_ => _.ScheduleStatusStringMap)
                           .Include(_ => _.LocalTypeStringMap)
                           .Include(_ => _.Local)
                           .Include(_ => _.Disease)
                           .Include(_ => _.RequestDoctor)
                           .Include(_ => _.SchedulingHistories)
                           .Include(_ => _.KitTypeStringMap)
                           .Include(_ => _.HealthProgram).ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<LogisticsSchedule>> GetLogisticsScheduleByExamList(Guid examId)
        {
            try
            {
                return _careDbContext.LogisticsSchedules
                           .Where(_ => _.ExamId == examId)
                           .Include(_ => _.Diagnostic)
                           .Include(_ => _.LogisticsScheduleTypeStringMap)
                           .Include(_ => _.ScheduleStatusStringMap)
                           .Include(_ => _.LocalTypeStringMap)
                           .Include(_ => _.Local)
                           .Include(_ => _.Disease)
                           .Include(_ => _.RequestDoctor)
                           .Include(_ => _.SchedulingHistories)
                           .Include(_ => _.KitTypeStringMap)
                           .Include(_ => _.HealthProgram).ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<LogisticsSchedule> GetLogisticsScheduleByTreatment(Guid treatmentId)
        {
            try
            {
                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.DiagnosticId == treatmentId)
                    .Include(_ => _.LogisticsScheduleTypeStringMap)
                    .Include(_ => _.ScheduleStatusStringMap)
                    .Include(_ => _.LocalTypeStringMap)
                    .Include(_ => _.Local)
                    .Include(_ => _.Disease)
                    .Include(_ => _.RequestDoctor)
                    .Include(_ => _.SchedulingHistories)
                    .Include(_ => _.KitTypeStringMap)
                    .Include(_ => _.HealthProgram)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<LogisticsSchedule> GetExamsByLogisticsScheduleId(Guid id)
        {
            try
            {
                return _careDbContext.LogisticsSchedules
                    .Where(_ => _.Id == id)
                    .Include(_ => _.ExamLogisticsSchedules).ThenInclude(_ => _.ExamDefinition)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.Diagnostic).ThenInclude(_ => _.GenderStringMap)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }
    }
}
