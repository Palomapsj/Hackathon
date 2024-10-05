using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Care.Api.Repository.Repositories
{
    public class VisitRepository : CommonRepository<Visit>, IVisitRepository
    {
 
        public VisitRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
        public async Task<List<Visit>> GetVisitByDateRange(DateTime startDate, DateTime endDate, Guid VisitorId,String Code,Guid? TypeOfVisit,Guid? SituationOfVisit, string? NameTreatment )
        {
            try
            {
                 
                var list = _careDbContext.Visits.Where(v => v.HealthProgram.Code == Code
                && v.IsDeleted == false
                && v.ScheduleDateStart >= startDate
                && v.ScheduleDateEnd <= endDate
                && v.HealthProfessionalId == VisitorId
                && v.StatusCodeStringMapId == SituationOfVisit
                && NameTreatment != ""
                    ? v.Treatment.Name == NameTreatment : v.HealthProfessionalId == VisitorId
                && TypeOfVisit != null
                    ? v.ServiceTypeId == TypeOfVisit : v.HealthProfessionalId == VisitorId
                
                )   
               .Include(v => v.Doctor)
               .Include(v => v.HealthProgram)
               .Include(v => v.Treatment)
               .Include(v => v.Treatment.TreatmentAddresses)
               .Include(v => v.HealthProfessional)
               .Include(v => v.Treatment.Caregiver)
               .Include(v => v.ServiceType)
               .Include(v => v.StatusCodeStringMap)
               .OrderByDescending(v => v.ScheduleDateStart)
               .ToList();
                List<Visit> visitData = new List<Visit>();


               

                return  list;
               

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

        public List<Visit> GetVisitsByTreatment(Guid? id)
        {

            var visit = _careDbContext.Visits
                                    .Where(_ => _.TreatmentId == id)
                                    .Include(_ => _.Voucher)
                                    .Include(_ => _.Treatment)
                                    .Include(_ => _.HealthProgram)
                                    .ToList();

            return visit;
        }


    }
}

