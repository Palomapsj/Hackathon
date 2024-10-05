using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IEntityMetadataRepository
    {

        EntityMetadata? GetEntityMetadata(string entityName);

    }
}
