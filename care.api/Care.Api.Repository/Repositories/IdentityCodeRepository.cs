using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class IdentityCodeRepository : CommonRepository<IdentityCode>, IIdentityCodeRepository
    {
        public IdentityCodeRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<IdentityCode> GetIdentityCode(Guid regardingObjectId)
        {
            var identityCodeList = _careDbContext.IdentityCodes.Where(_ => _.Id == regardingObjectId).ToList();

            return identityCodeList;
        }

        public void SetIdentityCode(Guid regardingObjectId, string newIdentityValue)
        {
            var identityCode = _careDbContext.IdentityCodes.FirstOrDefault(_ => _.Id == regardingObjectId);

            if(identityCode is not null) { 
            
                identityCode.SequentialValue = newIdentityValue;

                _careDbContext.IdentityCodes.Update(identityCode);
            }
        }



    }
}
