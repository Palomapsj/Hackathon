using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IRegardingEntityRepository : ICommonRepository<RegardingEntity>
    {

        List<RegardingEntity>? GetRegardingEntity(Guid targetId, string targetEntityName, int targetEntityTypeCode);
    }
}
