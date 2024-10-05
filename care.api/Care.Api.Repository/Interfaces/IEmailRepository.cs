using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IEmailRepository : ICommonRepository<Email>
    {
        new Email Update(Email email);
    }
}
