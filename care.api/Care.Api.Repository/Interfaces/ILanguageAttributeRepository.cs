using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface ILanguageAttributeRepository : ICommonRepository<LanguageAttribute>
    {
        string GetAttributeLanguage(string entityName, string attributeName, Guid healthProgramId, int languageId);
        List<string> GetAttributiesNotAuditable(string entityName, Guid healthProgramId);
    }
}
