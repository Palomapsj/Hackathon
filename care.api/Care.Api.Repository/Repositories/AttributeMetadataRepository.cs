using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class AttributeMetadataRepository : CommonRepository<AttributeMetadata>, IAttributeMetadataRepository
    {
        public AttributeMetadataRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public string GetAttributeTypeByEntityNameAttributeName(string entityName, string attributeName)
        {

            var attributeMetadata = _careDbContext.AttributeMetadata.Where(_ => _.EntityMetadataIdName == entityName
                                                                             && _.AttributeName == attributeName).FirstOrDefault();

            if(attributeMetadata is not null)
                return attributeMetadata.AttributeType;

            return string.Empty;
        }

        



    }
}
