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

public sealed class PatientRepository : CommonRepository<Patient>, IPatientRepository
{
    public PatientRepository(CareDbContext careDbContext) : base(careDbContext)
    {

    }


    public Patient GetPatientByCpf(string Cpf)
    {
        try
        {
            var patient = _careDbContext.Patients.Where(x => x.Cpf == Cpf)
                               //&& _.IsDeleted == false)
                               //            .Include(_ => _.DoctorByPrograms)
                               //            .Include(_ => _.MedicalSpecialties)
                               .FirstOrDefault();


            return patient;
        }
        catch (Exception ex)
        {
            return null;
        }

    }

    public async Task<List<MultidisciplinaryService>> GetMultidisciplinaryServicesByFullName(Guid Id)
    {
        try
        {
            return await (from v in _careDbContext.Visits
                          join t in _careDbContext.Treatments on v.TreatmentId equals t.Id
                          where t.Id == Id
                          select new MultidisciplinaryService
                          {
                              Data = v.ScheduleDateStart,
                              Status = v.ConclusionDateStart,
                              Type = v.Name,
                              Code = v.Code
                          }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IQueryable<Patient>? Queryable()
    {
        try
        {
            return _careDbContext.Set<Patient>().AsQueryable();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
            return null;
        }
    }
}
