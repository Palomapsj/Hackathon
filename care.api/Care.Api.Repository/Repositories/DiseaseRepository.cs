using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class DiseaseRepository : CommonRepository<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<Disease> GetDiseasesByProgram(string programcode)
        {
            var healthProgramId = _careDbContext.HealthPrograms.FirstOrDefault(_ => _.Code == programcode).Id;

            var diseases = _careDbContext.Diseases.Include(_ => _.HealthProgramDiseaseDiseases);

            var diseasesByProgram = diseases.Where(_ => _.HealthProgramDiseaseDiseases.Any(x => x.HealthProgramId == healthProgramId && x.IsDeleted == false)).ToList();

            return diseasesByProgram;

        }

        public List<Medicament> GetMedicationsByDisease(Guid diseaseId, string programcode)
        {
            List<Medicament> medicaments = new List<Medicament>();

            medicaments = _careDbContext.HealthPrograms.Include(m => m.Medicaments).ThenInclude(t => t.Diseases)
                                                        .FirstOrDefault(_ => _.Code == programcode).Medicaments.ToList();

            medicaments = medicaments.Where(h => h.Diseases.Where(d => d.Id == diseaseId).Any() == true && h.IsDeleted == false).ToList();

            return medicaments;
        }
    }
}
