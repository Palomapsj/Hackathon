using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IAttributeMetadataRepository : ICommonRepository<AttributeMetadata>
    {

        string GetAttributeTypeByEntityNameAttributeName(string entityName, string attributeName);

        

    }
}
