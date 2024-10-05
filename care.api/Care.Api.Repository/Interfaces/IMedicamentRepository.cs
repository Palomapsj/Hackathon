using Care.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Interfaces
{
    public interface  IMedicamentRepository :  ICommonRepository<Medicament>
    {
        List<Medicament> GetMedicationsByProgram(string programcode);
        List<MedicamentAudit> GetMedicamentAudit(Guid id);
        List<Medicament> GetMedicamentsByTreatment(Guid id);
        public List<Medicament> GetMedicamentsByHealthProgram(Guid? Id);
    }
  
}
