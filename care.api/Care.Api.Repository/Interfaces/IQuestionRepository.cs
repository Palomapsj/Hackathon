using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IQuestionRepository : ICommonRepository<Question>
    {
        List<QuestionAudit> GetQuestionAudit(Guid id);
    }
}
