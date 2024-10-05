using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class RegardingEntityRepository : CommonRepository<RegardingEntity>, IRegardingEntityRepository
    {
        public RegardingEntityRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<RegardingEntity>? GetRegardingEntity(Guid targetId, string targetEntityName, int targetEntityTypeCode)
        {
            var regardingEntities = _careDbContext.RegardingEntities.Where(_ => _.RegardingObjectIdTarget == targetId
                                                                            && _.RegardingEntityNameTarget == targetEntityName
                                                                            && _.RegardingEntityTypeCodeTarget == targetEntityTypeCode
                                                                            && _.IsDeleted == false).ToList();

            if(regardingEntities is null)
            {
                return null;
            }

            return regardingEntities;
        }



    }
}
