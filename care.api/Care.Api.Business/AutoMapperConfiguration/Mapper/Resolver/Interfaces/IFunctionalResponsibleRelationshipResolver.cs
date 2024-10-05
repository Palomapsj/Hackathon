using Care.Api.Models;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Interfaces
{
    public interface IFunctionalResponsibleRelationshipResolver
    {
        int Resolve(Treatment source);
    }
}
