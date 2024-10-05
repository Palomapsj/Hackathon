using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface ISurveyResponseRepository : ICommonRepository<SurveyResponse>
    {
        List<SurveyResponseAudit> GetSurveyAudit(Guid id);
    }
}
