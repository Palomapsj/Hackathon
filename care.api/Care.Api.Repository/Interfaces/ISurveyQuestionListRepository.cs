using Care.Api.Models;
using Care.Api.Repository.Repositories;

namespace Care.Api.Repository.Interfaces
{
    public interface ISurveyQuestionListRepository : ICommonRepository<SurveyQuestionList>
    {
        List<SurveyQuestionListAudit> GetSurveyQuestionListAudit(Guid id);
    }
}
