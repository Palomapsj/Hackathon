using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IQuestionOptionsRepository : ICommonRepository<QuestionOption>
    {
        List<QuestionOptionsAudit> GetQuestionOptionsAudit(Guid id);
    }
}
