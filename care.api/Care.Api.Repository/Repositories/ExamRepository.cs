using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class ExamRepository : CommonRepository<Exam>, IExamRepository
    {
        public ExamRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<ExamAudit> GetExamAudit(Guid id)
        {
            var examAuditList = _careDbContext.ExamAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return examAuditList;
        }

        public Exam GetExamComplete(Guid id)
        {

            var exam = _careDbContext.Exams
                                    .Where(_ => _.Id == id)
                                    .Include(_ => _.Voucher)
                                    .Include(_ => _.Diagnostic)
                                    .Include(_ => _.HealthProgram)
                                    .Include(_ => _.ExamDefinition)
                                    .Include(_ => _.Local)
                                    .Include(_ => _.Treatment)
                                    .Include(_ => _.Doctor)
                                    .FirstOrDefault();

            exam.LogisticsSchedule = _careDbContext.LogisticsSchedules.FirstOrDefault(_ => _.ExamId == exam.Id);

            return exam;
        }
        public Exam GetExamById(Guid id)
        {
            try { 
            var exam = _careDbContext.Exams
                                    .Where(_ => _.Id == id)
                                    .Include(_ => _.Voucher)
                                    .Include(_ => _.Diagnostic)
                                    .Include(_ => _.HealthProgram)
                                    .Include(_ => _.ExamDefinition)
                                    .Include(_ => _.Local)
                                    .Include(_ => _.Treatment)
                                    .Include(_ => _.Doctor)
                                    .FirstOrDefault();

            

            return exam;
            }
            catch (Exception ex)
            {
                return null;
            }
        }           
    public List<Exam> GetExamsByTreatment(Guid? id)
        {
            try
            {

                var exam = _careDbContext.Exams
                                        .Where(_ => _.TreatmentId == id && _.IsDeleted == false)
                                        .Include(_ => _.Voucher)
                                        .Include(_ => _.Doctor)
                                        .Include(_ => _.Treatment)
                                        .Include(_ => _.HealthProgram)
                                        .Include(_ => _.ExamStatusStringMap)
                                        .Include(_ => _.ExamDefinition)
                                        .Include(_ => _.Local)
                                        .Include(_ => _.ReschedulingReasonStringMap)
                                        .ToList();

                return exam;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Exam> GetExamsByDiagnostic(Guid id)
        {

            var exam = _careDbContext.Exams
                                    .Where(_ => _.DiagnosticId == id && _.IsDeleted == false)
                                    .Include(_ => _.Voucher)
                                    .Include(_ => _.Treatment)
                                    .Include(_ => _.HealthProgram)
                                    .Include(_ => _.ExamStatusStringMap)
                                    .Include(_ => _.ExamDefinition)
                                    .Include(_ => _.Local)
                                    .Include(_ => _.ReschedulingReasonStringMap)
                                    .Include(_ => _.LogisticsSchedule)
                                    .ToList();

            return exam;
        }
        public async Task<List<ExamHistory>> GetExamHistory(Guid id)
        {
            try
            {
                return await (from e in _careDbContext.Exams
                              join t in _careDbContext.Treatments on e.TreatmentId equals t.Id
                              where t.Id == id
                              select new ExamHistory
                              {
                                  Data = e.ScheduleDate,
                                  Status = e.RealizationDate,
                                  Type = e.Name,
                                  ExamCode = e.FriendlyCode
                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Exam>> GetAllExamsByDoctor(Guid? userId, Guid? healthprogramId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Exams
                    .Where(_ => _.HealthProgramId == healthprogramId && _.IsDeleted == false && _.DoctorId == doctorByProgram.DoctorId)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<Exam>> GetAllExamsByProgramAndLogistic(Guid healthProgram, Guid userId)
        {
            try
            {
                var accountSettingsByPrograms = _careDbContext.AccountSettingsByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Exams
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.LocalId == accountSettingsByPrograms.AccountId)
                    .Include(_ => _.Treatment)
                    .Include(_ => _.ExamStatusStringMap)
                    .Include(_ => _.Voucher)
                    .Include(_ => _.Local)
                    .Include(_ => _.ExamDefinition)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.Doctor)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<Exam>> GetAllExamsByProgramAndPatient(Guid healthProgram, Guid userId)
        {
            try
            {
                var patient = _careDbContext.Patients.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                var treatment = _careDbContext.Treatments.Where(t => t.PatientId == patient.Id && t.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Exams
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.TreatmentId == treatment.Id)
                    .Include(_ => _.Treatment)
                    .Include(_ => _.ExamStatusStringMap)
                    .Include(_ => _.Voucher)
                    .Include(_ => _.Local)
                    .Include(_ => _.ExamDefinition)
                    .Include(_ => _.HealthProgram)
                    .Include(_ => _.Doctor)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }


    }
}
