using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Care.Api.Repository.Repositories
{
    public class AccountSettingsByProgramRepository : CommonRepository<AccountSettingsByProgram>, IAccountSettingsByProgramRepository
    {
        public AccountSettingsByProgramRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<AccountSettingsByProgram> GetAccountsByProgram(string programcode)
        {
            var healthProgramId = _careDbContext.HealthPrograms.FirstOrDefault(_ => _.Code == programcode).Id;

            var accountsByProgram = _careDbContext.AccountSettingsByPrograms.Include(a => a.Account)
                .Include(a => a.ExamDefinition)
                .Include(a => a.Medicament)
                .Include(a => a.HealthProgram)
                .Where(_ => _.HealthProgramId == healthProgramId).ToList();

            return accountsByProgram;
        }

        public IQueryable<AccountSettingsByProgram>? Queryable()
        {
            try
            {
                return _careDbContext.Set<AccountSettingsByProgram>().AsQueryable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
                return null;
            }
        }

        public List<AccountSettingsByProgram> GetAccountsByProgramAndAccountId(string programcode, Guid accountId)
        {
            var healthProgramId = _careDbContext.HealthPrograms.FirstOrDefault(_ => _.Code == programcode).Id;

            var examDefinitionByProgram = _careDbContext.ExamDefinitionSettingsByPrograms.Where(_ => _.HealthProgramId == healthProgramId).Select(x => x.ExamDefinitionId).ToList();

            var medicaments = _careDbContext.HealthPrograms.Include(m => m.Medicaments)
                                                       .FirstOrDefault(_ => _.Code == programcode).Medicaments.Select(x => x.Id ).ToList();

            var accountsByProgram = _careDbContext.AccountSettingsByPrograms.Include(a => a.Account)
                .Include(a => a.ExamDefinition)
                .Include(a => a.Medicament)
                .Where(_ => _.HealthProgramId == healthProgramId && _.AccountId == accountId && _.StateCode == true
                && (examDefinitionByProgram.Contains(_.ExamDefinitionId) || medicaments.Contains((Guid)_.MedicamentId))).ToList();

            return accountsByProgram;
        }
    }
}
