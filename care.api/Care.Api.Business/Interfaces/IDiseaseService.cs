using Care.Api.Business.Models;

namespace Care.Api.Business.Interfaces
{
    public interface IDiseaseService
    {
        Task<List<DiseaseModel>> GetDiseasesByProgram(string programcode);
        Task<List<MedicationModel>> GetMedicationsByDisease(Guid diseaseId, string programcode);
    }
}
