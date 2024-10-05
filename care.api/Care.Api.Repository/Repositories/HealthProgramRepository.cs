using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class HealthProgramRepository : CommonRepository<HealthProgram>, IHealthProgramRepository
    {
        public HealthProgramRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
        public List<HealthProgram> GetHealthProgramByMedicaments(Guid? Id)
        {
            try
            {
                var healthPrograms = _careDbContext.HealthPrograms.Include(m => m.Medicaments).ThenInclude(t => t.Diseases).ToList();

                 healthPrograms = healthPrograms.Where(h => h.Medicaments.Where(d => d.Id == Id).Any() == true).ToList();

                return healthPrograms;
            }
            catch (Exception ex)
            { Console.WriteLine("Error: " + ex.Message); return null; }
            finally
            { Console.WriteLine("Finally block GetMedicamentsByHealthProgram executed."); }
        }

        public List<HealthProgram> GetHealthProgramByMedicamentsId(Guid? Id)
        {
            try
            {
                var healthPrograms = _careDbContext.HealthPrograms.Include(m => m.Medicaments).ThenInclude(t => t.Diseases).ToList();

                healthPrograms = healthPrograms.Where(h => h.Medicaments.Where(d => d.Id == Id).Any() == true).ToList();

                return healthPrograms;
            }
            catch (Exception ex)
            { Console.WriteLine("Error: " + ex.Message); return null; }
            finally
            { Console.WriteLine("Finally block GetMedicamentsByHealthProgram executed."); }
        }
    }
}
