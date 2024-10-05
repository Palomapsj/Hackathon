using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Care.Api.Repository.Repositories
{
    public class QuestionRepository : CommonRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<QuestionAudit> GetQuestionAudit(Guid id)
        {
            var questionAuditList = _careDbContext.QuestionAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return questionAuditList;
        }
    }

}
