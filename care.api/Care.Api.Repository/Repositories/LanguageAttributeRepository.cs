using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class LanguageAttributeRepository : CommonRepository<LanguageAttribute>, ILanguageAttributeRepository
    {
        public LanguageAttributeRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public string GetAttributeLanguage(string entityName, string attributeName, Guid healthProgramId, int languageId)
        {

            if (attributeName.Contains("StringMap"))
                attributeName = attributeName.Replace("Id", "");

            var languageAttribute = _careDbContext.LanguageAttributes
                                                        .Where(_ => _.EntityMetadataIdName == entityName
                                                                 && _.AttributeMetadataIdName == attributeName
                                                                 && _.ProgramId == healthProgramId
                                                                 && _.LangId == languageId).FirstOrDefault();

            return languageAttribute.Label;
        }

        public List<string> GetAttributiesNotAuditable(string entityName, Guid healthProgramId)
        {
            var languagesAttributies = _careDbContext.LanguageAttributes
                                .Where(_ => _.EntityMetadataIdName == entityName
                                         && _.ProgramId == healthProgramId
                                         && _.InternalControl.Equals("[NOT_AUDITABLE]")).ToList();

            return languagesAttributies.Select(_ => _.AttributeMetadataIdName).ToList();

        }


    }
}
