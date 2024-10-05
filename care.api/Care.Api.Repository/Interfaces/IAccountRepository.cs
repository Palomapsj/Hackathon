using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IAccountRepository : ICommonRepository<Account>
    {
        List<Account> ListByAddress(Guid healthProgramId, Guid codigoExame, string tipoProcedimento);
        Account? GetByHealthProgramCnpj(Guid healthProgramId, string cnpj);
    }
}
