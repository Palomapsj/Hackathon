using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Care.Api.Repository.Repositories
{
    public class SurveyQuestionListRepository : CommonRepository<SurveyQuestionList>, ISurveyQuestionListRepository
    {
        public SurveyQuestionListRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<SurveyQuestionListAudit> GetSurveyQuestionListAudit(Guid id)
        {
            var surveyQuestionListAuditList = _careDbContext.SurveyQuestionListAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return surveyQuestionListAuditList;
        }
    }

}
