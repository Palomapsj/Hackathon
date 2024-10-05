using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IExamDefinitionSettingsByProgramRepository : ICommonRepository<ExamDefinitionSettingsByProgram>
    {
        List<ExamDefinitionSettingsByProgram> GetExamDefinitionByProgram(string programcode);
    }
}
