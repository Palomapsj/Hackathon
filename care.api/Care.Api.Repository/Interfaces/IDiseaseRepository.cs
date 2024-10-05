using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IDiseaseRepository : ICommonRepository<Disease>
    {

        List<Disease> GetDiseasesByProgram(string programcode);

        List<Medicament> GetMedicationsByDisease (Guid diseaseid, string programcode);

    }
}
