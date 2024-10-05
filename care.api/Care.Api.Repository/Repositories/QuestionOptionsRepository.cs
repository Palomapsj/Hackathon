using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Care.Api.Repository.Repositories
{
    public class QuestionOptionsRepository : CommonRepository<QuestionOption>, IQuestionOptionsRepository
    {
        public QuestionOptionsRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<QuestionOptionsAudit> GetQuestionOptionsAudit(Guid id)
        {
            var questionOptionsAuditList = _careDbContext.QuestionOptionsAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return questionOptionsAuditList;
        }
    }

}
