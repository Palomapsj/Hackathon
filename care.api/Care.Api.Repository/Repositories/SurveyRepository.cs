using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class SurveyRepository : CommonRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<SurveyAudit> GetSurveyAudit(Guid id)
        {
            var surveyAuditList = _careDbContext.SurveyAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return surveyAuditList;
        }

        public Survey GetSurveyByNameAndProgram(string name, string programcode)
        {
            var healthProgramId = _careDbContext.HealthPrograms.FirstOrDefault(_ => _.Code == programcode).Id;

            var survey = _careDbContext.Surveys.Where(_ => _.Name == name && _.HealthProgramId == healthProgramId && _.IsDeleted == false).FirstOrDefault();

            return survey;
        }

    }

}
