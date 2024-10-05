using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Care.Api.Repository.Repositories
{
    public class SurveyResponseRepository : CommonRepository<SurveyResponse>, ISurveyResponseRepository
    {
        public SurveyResponseRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<SurveyResponseAudit> GetSurveyAudit(Guid id)
        {
            var surveyResponseAuditList = _careDbContext.SurveyResponseAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return surveyResponseAuditList;
        }

    }

}
