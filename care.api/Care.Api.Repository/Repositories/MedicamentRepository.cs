using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Care.Api.Repository.Repositories
{
    public class MedicamentRepository : CommonRepository<Medicament>, IMedicamentRepository
    {
        public MedicamentRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<Medicament> GetMedicationsByProgram(string programcode)
        {
            List<Medicament> medicaments = new List<Medicament>();

            Guid pgrCode = Guid.Parse("2dee1985-6c2a-e511-9bc5-00155d001f02");

            medicaments = _careDbContext.HealthPrograms.Include(m => m.Medicaments)
                                                       .FirstOrDefault(_ => _.Code == programcode).Medicaments.ToList();

            return medicaments;
        }

        public List<MedicamentAudit> GetMedicamentAudit(Guid id)
        {
            var MedicamentAuditList = _careDbContext.MedicamentAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return MedicamentAuditList;
        }

        public List<Medicament> GetMedicamentsByTreatment(Guid id)
        {

            var Medicament = _careDbContext.Medicaments
                                    .Where(_ => _.Id == id)
                                    .Include(_ => _.Name)
                                    .Include(_ => _.FriendlyCode)
                                    .Include(_ => _.StatusCodeStringMap)
                                    .Include(_ => _.StateCode)
                                    .Include(_ => _.IsDeleted)
                                    .ToList();

            return Medicament;
        }

        public List<Medicament> GetMedicamentsByHealthProgram(Guid? Id)
        {
            try
            {
                //Todo Marker


                List<Medicament> lista = (from MEDICAMENTO in _careDbContext.Medicaments
                                          where MEDICAMENTO.HealthPrograms.Where(r => r.Id == Id).FirstOrDefault().Id == Id
                                          select MEDICAMENTO).ToList();

                lista = lista.OrderBy(L => L.Name).ToList();
                return lista;
            }
            catch (Exception ex)
            { Console.WriteLine("Error: " + ex.Message); return null; }
            finally
            { Console.WriteLine("Finally block GetMedicamentsByHealthProgram executed."); }
        }

    }

}
