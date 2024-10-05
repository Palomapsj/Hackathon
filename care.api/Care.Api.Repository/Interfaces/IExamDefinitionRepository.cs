using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IExamDefinitionRepository : ICommonRepository<ExamDefinition>
    {
        List<ExamDefinition> GetExamDefinitionsByProgram(string progracode);
        Task<List<ExamDefinition>> GetExamDefinitionsByDisease(string programCode, Guid diseaseId);
        Task<List<ExamDefinition>> GetExamDefinitionByMedicament(Guid medicamentId);
    }
}
