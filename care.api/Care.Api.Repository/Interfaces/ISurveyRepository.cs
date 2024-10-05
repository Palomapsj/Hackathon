using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface ISurveyRepository : ICommonRepository<Survey>
    {
        List<SurveyAudit> GetSurveyAudit(Guid id);

        Survey GetSurveyByNameAndProgram(string name, string programcode);
    }
}
