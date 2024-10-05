using Care.Api.Business.Models;
using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Care.Api.Models.Models;
using Care.Api.Business.Models;
using Care.Api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace Care.Api.Repository.Repositories
{
    public class TreatmentRepository : CommonRepository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public Treatment? GetFullTreatmentByPredicate(Expression<Func<Treatment, bool>> predicate)
        {
            return _careDbContext.Treatments.Where(predicate)
                .Include(x => x.Phase)
                .Include(x=>x.Exams)
                .Include(x=>x.Caregiver)
                .FirstOrDefault();
        }

        public List<TreatmentAudit> GetTreatmentAudit(Guid id)
        {
            var treatmentAuditList = _careDbContext.TreatmentAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return treatmentAuditList;
        }

        public async Task<List<Treatment>> GetTreatmentByProgramAndDoctor(Guid healthProgram, Guid? userId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Treatments
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.DoctorId == doctorByProgram.DoctorId)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Phase)
                    .Include(_ => _.TreatmentSituation)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.Medicament)
                    .Include(_ => _.InfusionPlace)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<Treatment>> GetTreatmentsWithDisease(Guid? userId, Guid diseaseId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Treatments
                    .Where(_ => _.DiseaseId == diseaseId && _.IsDeleted == false && _.DoctorId == doctorByProgram.DoctorId)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<Treatment>> GetAllInactiveTreatmentsByDoctor(Guid? userId, Guid inactiveStatusId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Treatments
                    .Where(_ => _.StateCode == false && _.IsDeleted == false && _.DoctorId == doctorByProgram.DoctorId).Include(t => t.TreatmentStatusDetail)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }
        public async Task<List<Treatment>> GetAllInactiveTreatmentsByDoctorAndProgram(Guid? userId, Guid inactiveStatusId, Guid? healthProgramId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Treatments
                    .Where(_ => _.TreatmentStatusId == inactiveStatusId && _.IsDeleted == false && _.DoctorId == doctorByProgram.DoctorId && _.HealthProgramId == healthProgramId)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }
        public async Task<List<Treatment>> GetAllAcessTreatmentsByDoctor(Guid? userId, Guid? healthprogramid)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Treatments
                    .Where(_ => _.StatusCodeStringMapId == new Guid("9412E000-A534-E411-992D-00155DFB9409") && _.IsDeleted == false && _.DoctorId == doctorByProgram.DoctorId && _.HealthProgramId == healthprogramid)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }
        public async Task<Treatment> GetTreatmentByProgramAndPatient(Guid healthProgram, Guid userId)
        {
            try
            {
                var patient = _careDbContext.Patients.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Treatments
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.PatientId == patient.Id)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Phase)
                    .Include(_ => _.TreatmentSituation)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.Medicament)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<Treatment> GetById(Guid? id)
        {
            try
            {
                return _careDbContext.Treatments
                    .Where(_ => _.Id == id)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Phase)
                    .Include(_ => _.TreatmentSituation)
                    .Include(_ => _.TreatmentAddresses)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.Medicament)
                    .Include(_ => _.InfusionPlace)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<Treatment> GetByPatientId(Guid id)
        {
            try
            {
                return _careDbContext.Treatments
                    .Where(_ => _.PatientId == id)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Phase)
                    .Include(_ => _.TreatmentSituation)
                    .Include(_ => _.TreatmentAddresses)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.Medicament)
                    .Include(_ => _.InfusionPlace)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<Treatment>> GetTreatmentByDoctorRepresentative(Guid healthProgram, Guid? userId)
        {
            try
            {
                var doctorByProgram = _careDbContext.DoctorByPrograms.Where(d => d.SystemUserId == userId && d.IsDeleted == false).FirstOrDefault();

                return _careDbContext.Treatments
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false && _.DoctorId == doctorByProgram.DoctorId)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Phase)
                    .Include(_ => _.TreatmentSituation)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.Medicament)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }
        public TreatmentAddress GetByCPF(Guid treatmentId)
        {
            try
            {
                var patient = _careDbContext.TreatmentAddresses
                                    .Where(_ => _.TreatmentId == treatmentId && _.IsDeleted == false)
                                    .Include(_ => _.Treatment)
                                    .FirstOrDefault();


                return patient;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Treatment GetMedicamentById(Guid? treatmentId, Guid? medicamentId)
        {
            try{
                var medicaments = _careDbContext.Treatments
                                    .Where(_ => _.Id == treatmentId && _.IsDeleted == false && _.MedicamentId == medicamentId)
                                    .Include(_ => _.Medicament)
                                    .FirstOrDefault();
                return medicaments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }   
        public async Task<List<ByDateRangeModel>> GetByDateRange(DateTime startDate, DateTime endDate, Guid doctorId, string healthProgramCode)
        {
            try
            {
                return await (from t in _careDbContext.Treatments
                              join m in _careDbContext.Medicaments on t.MedicamentId equals m.Id
                              join h in _careDbContext.HealthPrograms on t.HealthProgramId equals h.Id
                              where t.CreatedOn >= startDate && t.CreatedOn <= endDate
                                    && t.DoctorId == doctorId
                                    && h.Code == healthProgramCode
                              select new ByDateRangeModel
                              {
                                  FullName = t.FullName,
                                  CreatedOn = t.CreatedOn,
                                  Birthdate = t.Birthdate,
                                  MedicamentName = m.Name,
                                  StateCode = t.StateCode,

                                  PatientId = t.PatientId,
                                  PhaseId = t.PhaseId,
                                  TreatmentStartDate = t.TreatmentStartDate,
                                  TreatmentStatusId = t.TreatmentStatusId,
                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> GetTreatmentByMedicamentId(Guid medicamentId)
        {
            try
            {
                var fullNames = await _careDbContext.Treatments
                    .Where(t => t.MedicamentId == medicamentId && t.FullName != null && t.IsDeleted == false)
                    .Select(t => t.FullName)
                    .ToListAsync();

                return fullNames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Treatment>> GetTreatmentsByPatientId(Guid patientId)
        {
            try
            {
                return await _careDbContext.Treatments
                    .Where(t => t.PatientId == patientId && t.IsDeleted == false)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MultidisciplinaryService>> GetMultidisciplinaryServicesById(Guid id)
        {
            try
            {
                return await (from v in _careDbContext.Visits
                              join t in _careDbContext.Treatments on v.TreatmentId equals t.Id
                              where t.Id == id
                              select new MultidisciplinaryService
                              {
                                  Data = v.ScheduleDateStart,
                                  Status = v.ConclusionDateStart,
                                  Type = v.Name,
                                  Code = v.FriendlyCode
                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<InfusionHistory>> GetTreatmentHistoryByInfusion(Guid id)
        {
            try
            {
                return await (from i in _careDbContext.Infusions
                              join t in _careDbContext.Treatments on i.TreatmentId equals t.Id
                              where t.Id == id
                              select new InfusionHistory
                              {
                                  Data = i.ScheduledDate,
                                  Status = i.ActualDate,
                                  Place = i.Name,
                                  ReasonCancellation = i.Observations,
                                  InfusionCode = i.FriendlyCode
                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<StrengthMedicament>> GetDosageById(Guid? id)
        {
            try
            {
                return await _careDbContext.StrengthMedicaments
                    .Where(t => t.Id == id && t.IsDeleted == false)
                    .ToListAsync();

                //return await _careDbContext.StrengthMedicaments
                //              join t in _careDbContext.Treatments on i.Id equals t.StrengthMedicamentId
                //              where t.StrengthMedicamentId == id
                //              select new StrengthMedicament
                //              {
                //                  //Id = i.Id,
                //                  Name = i.Name,
                  
                //              }).ToList();
            }
            catch (Exception ex) { }

            return null;
        }


        public async Task<Treatment> GetTreatmentByCpfProgram(string cpf, Guid healthProigramId)
        {
            try
            {
                return _careDbContext.Treatments
                    .Where(_ => _.IsDeleted == false && (_.Cpf == cpf || _.Cpf == cpf.Replace(".", "").Replace("-", "")) && _.HealthProgramId == healthProigramId)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Phase)
                    .Include(_ => _.TreatmentSituation)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.Medicament)
                    .FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<List<Treatment>> GetTreatmentByProgramAdmin(Guid healthProgram)
        {
            try
            {
                return _careDbContext.Treatments
                    .Where(_ => _.HealthProgramId == healthProgram && _.IsDeleted == false)
                    .Include(_ => _.Doctor)
                    .Include(_ => _.Phase)
                    .Include(_ => _.TreatmentSituation)
                    .Include(_ => _.Disease)
                    .Include(_ => _.Custom1StringMap)
                    .Include(_ => _.Medicament)
                    .Include(_ => _.Vouchers)
                    .Include(_ => _.Exams)
                    .ToList();
            }
            catch (Exception ex) { }

            return null;
        }
        
     
    }

}
