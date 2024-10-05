using AutoMapper;
using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Care.Api.Business.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseService(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public async Task<List<DiseaseModel>> GetDiseasesByProgram(string programcode)
        {
            var diseases = _diseaseRepository.GetDiseasesByProgram(programcode);

            var mapperConfig = new MapperConfiguration(c => c.CreateMap<Disease, DiseaseModel>());
            var mapper = mapperConfig.CreateMapper();

            var result = mapper.Map<List<DiseaseModel>>(diseases);

            return await Task.FromResult(result);
        }
        public async Task<List<MedicationModel>> GetMedicationsByDisease(Guid diseaseId, string programcode)
        {
            var medicationsByDisease = _diseaseRepository.GetMedicationsByDisease(diseaseId, programcode);

            var mapperConfig = new MapperConfiguration(c => c.CreateMap<Medicament, MedicationModel>());
            var mapper = mapperConfig.CreateMapper();

            var result = mapper.Map<List<MedicationModel>>(medicationsByDisease);

            return await Task.FromResult(result);
        }
    }
}
