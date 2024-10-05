using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IIdentityCodeRepository : ICommonRepository<IdentityCode>
    {
        List<IdentityCode> GetIdentityCode(Guid regardingObjectId);
        void SetIdentityCode(Guid regardingObjectId, string newIdentityValue);
    }
}
