using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class DiagnosticRepository : CommonRepository<Diagnostic>, IDiagnosticRepository
    {
        public DiagnosticRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<Diagnostic> GetDiagnosticsByDoctor(Guid doctorId, Guid healthProgramId)
        {
            var diagnosticsByDoctor = _careDbContext.Diagnostics.Where(_ => _.HealthProgramId == healthProgramId
                                                                         && _.DoctorId == doctorId
                                                                         && _.IsDeleted == false)
                                                                         .Include(_ => _.StatusCodeStringMap)
                                                                         .Include(_ => _.Disease)
                                                                         .Include(_ => _.Custom1StringMap)
                                                                         .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.ExamDefinition)
                                                                         .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.Voucher)
                                                                         .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.ExamStatusStringMap)
                                                                         .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.ResultStringMap)
                                                                        .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.ReschedulingReasonStringMap);

            return diagnosticsByDoctor.ToList();
        }

        public List<Diagnostic> GetDiagnosticsByLaboratory(Guid accountId, Guid healthProgramId)
        {
            var diagnosticsByLab = _careDbContext.Diagnostics.Where(_ => _.HealthProgramId == healthProgramId
                                                                         && _.IsDeleted == false
                                                                         && _.Exams.Any(s => s.LocalId == accountId))
                                                                         .Include(_ => _.StatusCodeStringMap)
                                                                         .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.ExamDefinition)
                                                                         .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.Voucher)
                                                                         .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.ExamStatusStringMap)
                                                                         .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.ResultStringMap)
                                                                        .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.Doctor)
                                                                        .Include(_ => _.Exams.Where(_ => _.IsDeleted == false))
                                                                            .ThenInclude(_ => _.ReschedulingReasonStringMap); ;

            return diagnosticsByLab.ToList();
        }

        public async Task<List<Diagnostic>> GetDiagnosticsByProgram(Guid healthProgram)
        {
            try
            {
                return _careDbContext.Diagnostics
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false)
                    .Include(_ => _.Doctor)
                        .ThenInclude(_ => _.DoctorByPrograms)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.ExamStatusStringMap)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.ReschedulingReasonStringMap)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.ResultStringMap)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.Voucher)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.ExamDefinition)
                        .Include(_=> _.Disease)
                    .Include(_ => _.StatusCodeStringMap).Select(s => new Diagnostic
                    {
                        Id = s.Id,
                        FullName = s.FullName,
                        Name = s.Name,
                        Cpf = s.Cpf,
                        StatusCodeStringMapId = s.StatusCodeStringMapId,
                        DiseaseId = s.DiseaseId,
                        DoctorId = s.DoctorId,
                        CreatedOn = s.CreatedOn
                    })
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public List<DiagnosticAudit> GetDiagnosticAudit(Guid id)
        {
            var diagnosticAuditList = _careDbContext.DiagnosticAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return diagnosticAuditList;
        }

        public async Task<Diagnostic> GetDiagnosticByProgramAndPatient(Guid healthProgram, Guid userId)
        {
            try
            {
                var patient = _careDbContext.Patients.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Diagnostics
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.PatientId == patient.Id)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.ExamStatusStringMap)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.Voucher)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Exams)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.StatusCodeStringMap)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<Diagnostic>> GetDiagnosticByProgramAndDoctor(Guid healthProgram, Guid? userId)
        {
            try
            {
                var doctor = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Diagnostics
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.DoctorId == doctor.DoctorId)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.ExamStatusStringMap)
                    .Include(_ => _.Exams.Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false))
                        .ThenInclude(_ => _.Voucher)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Exams)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.StatusCodeStringMap)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<Diagnostic> GetDiagnosticById(Guid id)
        {
            try
            {
                return _careDbContext.Diagnostics
                    .Where(_ => _.Id == id)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Exams)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.Custom2StringMap)
                    .Include(_ => _.StatusCodeStringMap)
                    .Include(_ => _.LogisticsSchedules).ThenInclude(_ => _.ScheduleStatusStringMap)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<Diagnostic?> GetDiagnosticByCpfProgram(string cpf, Guid healthProigramId)
        {
            var result = await _careDbContext.Diagnostics
                .Where(_ => _.IsDeleted == false && (_.Cpf == cpf || _.Cpf == cpf.Replace(".", "").Replace("-", "")) && _.HealthProgramId == healthProigramId)
                .Include(_ => _.Doctor)
                .Include(_ => _.Disease)
                .Include(_ => _.Custom1StringMap)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Diagnostic?> GetByCPF(string cpf)
        {
            var patient = await _careDbContext.Diagnostics
                                .Where(_ => _.Cpf != null && _.Cpf.Replace(".", "").Replace("-", "") == cpf.Replace(".", "").Replace("-", "") && _.IsDeleted == false)
                                .Include(_ => _.Patient)
                                .FirstOrDefaultAsync();

            return patient;
        }

        public async Task<Diagnostic?> GetDiagnosticByCpfProgram(string cpf, string programCode)
        {
            var healthProgram = await _careDbContext.HealthPrograms.FirstOrDefaultAsync(hp => hp.Code == programCode) ?? throw new Exception("Programa não encontrado para o código informado...");

            var result = await _careDbContext.Diagnostics
                .Where(_ => _.IsDeleted == false && (_.Cpf == cpf || _.Cpf == cpf.Replace(".", "").Replace("-", "")) && _.HealthProgramId == healthProgram.Id)
                .Include(_ => _.Doctor)
                .Include(_ => _.Disease)
                .Include(_ => _.Custom1StringMap)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync();

            return result;
        }

        public IQueryable<Diagnostic>? Queryable()
        {
            try
            {
                return _careDbContext.Set<Diagnostic>().AsQueryable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
                return null;
            }
        }
    }
}
