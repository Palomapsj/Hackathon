using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class ExamDefinitionSettingsByProgramRepository : CommonRepository<ExamDefinitionSettingsByProgram>, IExamDefinitionSettingsByProgramRepository
    {
        public ExamDefinitionSettingsByProgramRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }

        public List<ExamDefinitionSettingsByProgram> GetExamDefinitionByProgram(string programcode)
        {
            var healthProgramId = _careDbContext.HealthPrograms.FirstOrDefault(_ => _.Code == programcode).Id;

            var examDefinitionByProgram = _careDbContext.ExamDefinitionSettingsByPrograms.Where(_ => _.HealthProgramId == healthProgramId).ToList();

            return examDefinitionByProgram;
        }
    }
}
