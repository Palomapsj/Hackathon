using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class AccountRepository : CommonRepository<Account>, IAccountRepository
    {
        public AccountRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<Account> ListByAddress(Guid healthProgramId, Guid codigoExame, string tipoProcedimento)
        {
            var accounts = new List<Account>();

            if (tipoProcedimento == "EXAME")
            {
                accounts = _careDbContext.Accounts
                    .Include(_ => _.AccountSettingsByPrograms)
                    .Where(_ => _.AccountSettingsByPrograms.Any(x => x.HealthProgramId == healthProgramId && x.ExamDefinitionId == codigoExame))
                    .ToList();
            }
            else
            {
                accounts = _careDbContext.Accounts
                    .Include(_ => _.AccountSettingsByPrograms)
                    .Where(_ => _.AccountSettingsByPrograms.Any(x => x.HealthProgramId == healthProgramId && x.MedicamentId == codigoExame))
                    .ToList();
            }

            return accounts;
        }

        public Account? GetByHealthProgramCnpj(Guid healthProgramId, string cnpj)
        {
            return _careDbContext.Accounts
                .Include(x => x.HealthPrograms)
                .Where(x => x.HealthPrograms.Any(y => y.Id == healthProgramId) && x.Cnpj == cnpj)
                .FirstOrDefault();
        }
    }
}
