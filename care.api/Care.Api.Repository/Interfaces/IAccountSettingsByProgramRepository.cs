using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IAccountSettingsByProgramRepository : ICommonRepository<AccountSettingsByProgram>
    {

        List<AccountSettingsByProgram> GetAccountsByProgram(string programcode);
        IQueryable<AccountSettingsByProgram>? Queryable();

        List<AccountSettingsByProgram> GetAccountsByProgramAndAccountId(string programcode, Guid accountId);
    }
}
